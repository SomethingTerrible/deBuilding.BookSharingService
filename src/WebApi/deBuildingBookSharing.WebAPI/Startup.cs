using deBuilding.BookSharingService.Domain.Interfaces;
using deBuilding.BookSharingService.Domain.Services;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace deBuildingBookSharing.WebAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			/*JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

			var authority = Configuration["Authority"];
			var audience = Configuration["Audience"];

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
			{
				options.Authority = authority;
				options.Audience = audience;
				options.RequireHttpsMetadata = false;

				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateAudience = false
				};
			});*/

			services.AddTransient<IUnitOfWork, EFUnitOfWork>();
			services.AddTransient<IUserBaseService, UserBaseService>();
			services.AddTransient<ICategoryService, CategoryService>();
			services.AddTransient<IStatusService, StatusService>();	
			services.AddTransient<IUserMessageService, UserMessageService>();

			services.AddControllers()
				.AddNewtonsoftJson(options =>
				options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseRouting();
			/*app.UseAuthentication();*/
			app.UseAuthorization();

			app.UseEndpoints(configure =>
			{
				configure.MapControllers();
			});
		}
	}
}
