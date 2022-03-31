using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace deBuilding.BookSharingService.WebMVC
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
			services.AddMvc();
			services.AddHttpClient();

			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

			var clientId = Configuration["ClientId"]; 
			var authority = Configuration["AuthorityServer"];
			var clientSecret = Configuration["ClientSecret"];
			var responseType = Configuration["ResponseType"];

			services.AddAuthentication(options =>
			{
				options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
			})
			.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
			.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
			{
				options.Authority = authority;
				options.ClientId = clientId;
				options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.ClientSecret = clientSecret;
				options.ResponseType = responseType;
				options.SaveTokens = true;
				options.GetClaimsFromUserInfoEndpoint = true;
				options.Scope.Add("profile");
				options.Scope.Add("openid");
				options.Scope.Add("WebApiScope");
			});

			services.AddHttpClient();

			services.AddSingleton<IAuthorizationHandler, SuperUserRequirementHandler>();
			services.AddSingleton<IAuthorizationPolicyProvider, SuperUserAuthorizationPolicyProvider>();

			services.AddControllersWithViews()
				.AddRazorRuntimeCompilation(); // Рантайм компиляция для упрощения разработки.
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
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");

			});
		}
	}

	public class SuperUserAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
	{
		private readonly AuthorizationOptions _options;

		public SuperUserAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) 
			: base(options)
		{
			_options = options.Value;
		}

		public async override Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
		{
			var policyExist = await base.GetPolicyAsync(policyName);

			if (policyExist == null)
			{
				policyExist = new AuthorizationPolicyBuilder()
					.AddRequirements(new SuperUserRequirement("true"))
					.Build(); 
				_options.AddPolicy(policyName, policyExist);
			}

			return policyExist;
		}
	}

	public class SuperUserRequirement : IAuthorizationRequirement
	{
		public bool IsSuperUser { get; set; }

		public SuperUserRequirement(string isSuperUser)
		{
			IsSuperUser = Convert.ToBoolean(isSuperUser);
		}
	}

	public class SuperUserRequirementHandler : AuthorizationHandler<SuperUserRequirement>
	{
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SuperUserRequirement requirement)
		{
			var hasClaim = context.User.HasClaim(x => x.Type == "IsSuperUser");

			if (!hasClaim)
			{
				return Task.CompletedTask;
			}

			var isSuperUserStr = context.User.FindFirst(x => x.Type == "IsSuperUser").Value;
			var isSuperUser = Convert.ToBoolean(isSuperUserStr);
			
			if (isSuperUser)
			{
				context.Succeed(requirement);
			}

			return Task.CompletedTask;
		}
	}
}
