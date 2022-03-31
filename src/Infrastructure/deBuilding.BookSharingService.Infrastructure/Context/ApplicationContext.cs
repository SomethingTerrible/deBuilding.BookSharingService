using deBuilding.BookSharingService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Context
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Autor> Autor { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) 
			: base(options)
		{

		}
	}
}
