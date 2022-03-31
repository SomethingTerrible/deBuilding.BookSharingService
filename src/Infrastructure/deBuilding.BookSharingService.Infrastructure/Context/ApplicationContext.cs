using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using deBuilding.BookSharingService.Infrastructure.Models;

namespace deBuilding.BookSharingService.Infrastructure.Context
{
	public class ApplicationContext : DbContext
	{
		//todo В дальнейшем добавим DbSet<T> T - наши таблицы. Пока оставим так.
		public DbSet<UserAddress> UserAddress { get; set; }

		public DbSet<Autor> Autor { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) 
			: base(options)
		{

		}
	}
}
