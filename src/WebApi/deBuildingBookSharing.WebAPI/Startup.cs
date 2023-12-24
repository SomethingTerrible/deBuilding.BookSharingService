using deBuilding.BookSharingService.Domain.Interfaces;
using deBuilding.BookSharingService.Domain.Services;
using deBuilding.BookSharingService.EventBus.Abstraction;
using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.UnitOfWork;
using deBuilding.BookSharingService.ServicesCommon;
using deBuildingBookSharing.WebAPI.IntegrationEvents.EventHandlers;
using deBuildingBookSharing.WebAPI.IntegrationEvents.Events;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
			this.configuration = configuration;
		}

		public IConfiguration configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Добавление базы данных
			var connectionString = configuration.GetConnectionString("DefaultConnetion");

			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(connectionString, x=> x.MigrationsAssembly("deBuildingBookSharing.WebAPI")));

			/*JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

			var authority = configuration["Authority"];
			var audience = configuration["Audience"];

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

			services.AddEventBus(configuration);
			services.AddTransient<IdentityUserCreatedEventHandler>();

			services.AddTransient<IUnitOfWork, EFUnitOfWork>();
			services.AddTransient<IUserBaseService, UserBaseService>();
			services.AddTransient<IUserAddressService, UserAddressService>();
			services.AddTransient<ICategoryService, CategoryService>();
			services.AddTransient<IStatusService, StatusService>();	
			services.AddTransient<IUserMessageService, UserMessageService>();


			
			var serviceProvider = services.BuildServiceProvider();
			var eventBus = serviceProvider.GetRequiredService<IEventBus>();

			eventBus.Subscribe<IdentityUserCreatedEvent, IdentityUserCreatedEventHandler>();

			services.AddControllers()
				.AddNewtonsoftJson(options =>
				options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseRouting();
			/*app.UseAuthentication();*/
			app.UseAuthorization();

			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseEndpoints(configure =>
			{
				configure.MapControllers();
			});
		}
	}
}
