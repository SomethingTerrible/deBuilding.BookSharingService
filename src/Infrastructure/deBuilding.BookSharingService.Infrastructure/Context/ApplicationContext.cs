using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Context
{
	public class ApplicationContext : DbContext
	{
		//todo В дальнейшем добавим DbSet<T> T - наши таблицы. Пока оставим так.
		public ApplicationContext(DbContextOptions<ApplicationContext> options) 
			: base(options)
		{

		}
	}
}
