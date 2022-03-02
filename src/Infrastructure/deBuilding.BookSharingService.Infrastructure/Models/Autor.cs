using System;
using System.Collections.Generic;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// Авторы произведений.
	/// </summary>
	public class Autor
	{
		public Guid AutorId { get; set; }	

		public string LastName { get; set; }	

		public string FirstName { get; set; }	

	}
}
