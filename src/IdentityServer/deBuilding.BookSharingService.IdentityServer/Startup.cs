using deBuilding.BookSharingService.IdentityServer.Configuration;
using deBuilding.BookSharingService.IdentityServer.Data;
using deBuilding.BookSharingService.IdentityServer.Models.AspNetIdentityCustomModels;
using deBuilding.BookSharingService.IdentityServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using IdentityServer4.Models;
using deBuilding.BookSharingService.ServicesCommon;
using Microsoft.Extensions.Logging;

namespace deBuilding.BookSharingService.IdentityServer
{
	public class Startup
	{
		private IConfiguration _configuration { get; }

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			var assembly = typeof(Program).Assembly.GetName().Name;
			var connectionString = _configuration.GetRequiredConnectionString("IdentityDb");

			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(connectionString, sqlOptions =>
				{
					sqlOptions.EnableRetryOnFailure(maxRetryCount: 5);
				});
			});

			services.AddIdentity<ApplicationUser, IdentityRole>(config =>
			{
				config.User.RequireUniqueEmail = false;
				// àáâãäå¸æçèéêëìíîïğñòóôõö÷øùúûüışÿÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏĞÑÒÓÔÕÖ×ØÙÚÛÜİŞß-._@+
				config.User.AllowedUserNameCharacters = "àáâãäå¸æçèéêëìíîïğñòóôõö÷øùúûüışÿÀ";
				config.Password.RequiredUniqueChars = 1;
				config.Password.RequireUppercase = true;
				config.Password.RequireDigit = true;
				config.Password.RequireNonAlphanumeric = false;
				config.Password.RequireLowercase = true;
				config.Password.RequiredLength = 8;
			})
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.ConfigureApplicationCookie(config =>
			{
				config.Cookie.Name = "IdentityServer.Cookie";
				config.LoginPath = "/Account/Login";
			});

			services.AddIdentityServer(optinons =>
            {
				optinons.Csp.Level = CspLevel.Two;
				optinons.Csp.AddDeprecatedHeader = true;
            })
				.AddAspNetIdentity<ApplicationUser>()
				.AddInMemoryClients(Confi.GetClients(_configuration))
				.AddInMemoryIdentityResources(Confi.GetResourses)
				.AddInMemoryApiScopes(Confi.GetScopes)
				.AddInMemoryApiResources(Confi.GetApis)
				.AddDeveloperSigningCredential()
				.AddProfileService<ProfileService>();
				

			services.AddEventBus(_configuration);

			services.AddLogging(config =>
			{
				config.ClearProviders();
				config.AddConsole();
			});
			
			services.AddMvc();
			services.AddControllersWithViews()
				.AddRazorRuntimeCompilation();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseForwardedHeaders();
			app.UseRouting();
			app.UseIdentityServer();
			app.UseAuthorization();

			app.UseCookiePolicy(new CookiePolicyOptions {
				MinimumSameSitePolicy = SameSiteMode.Lax 
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}
	}
}
