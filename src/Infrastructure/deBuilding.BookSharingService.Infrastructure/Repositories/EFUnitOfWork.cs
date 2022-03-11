using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
	public class EFUnitOfWork : IUnitOfWork
	{
		private readonly ApplicationContext _db;

		public EFUnitOfWork()
		{
			var builder = new ConfigurationBuilder();
			var appSetingsJsonFilePath = Directory.GetCurrentDirectory() + "/appsettings.json";
			builder.AddJsonFile(appSetingsJsonFilePath);
			var config = builder.Build();

			var connectionString = config.GetConnectionString("DefaultConnetion");
			var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
			var options = optionBuilder
				.UseSqlServer(connectionString)
				.Options;

			_db = new ApplicationContext(options);
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}
	}
}
