using deBuilding.BookSharingService.IdentityServer.Configuration;
using deBuilding.BookSharingService.IdentityServer.Data;
using deBuilding.BookSharingService.IdentityServer.Interfaces;
using deBuilding.BookSharingService.IdentityServer.Models.AspNetIdentityCustomModels;
using deBuilding.BookSharingService.IdentityServer.Repositories;
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
using IdentityServer4.Services;

namespace deBuilding.BookSharingService.IdentityServer
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			var assembly = typeof(Program).Assembly.GetName().Name;
			var connectionString = Configuration["ConnectionString"];

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
				config.User.AllowedUserNameCharacters = "àáâãäå¸æçèéêëìíîïğñòóôõö÷øùúûüışÿÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏĞÑÒÓÔÕÖ×ØÙÚÛÜİŞß _";
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
				.AddInMemoryClients(Confi.GetClients())
				.AddInMemoryIdentityResources(Confi.GetResourses)
				.AddInMemoryApiScopes(Confi.GetScopes)
				.AddInMemoryApiResources(Confi.GetApis)
				.AddDeveloperSigningCredential()
				.AddProfileService<ProfileService>();
				
			services.AddTransient<IUnitOfWork, EFUnitOfWork>();
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IUserAddressService, UserAddressService>();

			// Äîáàâëåíèå Cors
			/*services.AddSingleton<ICorsPolicyService>((container) =>
			{
				var logger = container.GetRequiredService<ILogger<DefaultCorsPolicyService>>();
				return new DefaultCorsPolicyService(logger)
				{
					AllowAll = true
				};
			});*/

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
			app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}
	}
}
