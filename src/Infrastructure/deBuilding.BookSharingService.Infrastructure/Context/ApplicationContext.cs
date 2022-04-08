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
		public DbSet<Author> Autor { get; set; }
		
		public DbSet<BookLiterary> BookLiterary { get; set;}

		public DbSet<BookResponse> BookResponse { get; set; }

		public DbSet<Category>	Category { get; set; }

		public DbSet<ExchangeList> ExchangeList { get; set; }

		public DbSet<OfferList> OfferList { get; set; }

		public DbSet<Status> Status { get; set; }	


		public DbSet<UserAddress> UserAddress { get; set; }

		public DbSet<UserBase> UserBase { get; set; }

		public DbSet<UserExchangeList> UserExchangeList { get; set; }

		public DbSet<UserList> UserList { get; set; }

		public DbSet<UserMsg> UserMsg { get; set; }		

		public DbSet<UserValueCategory> UserValueCategory { get; set; }

		public DbSet<WishList> WishList { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) 
			: base(options)
		{

		}
	}
}
