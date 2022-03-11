using System;
using System.Collections.Generic;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Interfaces
{
	/// <summary>
	/// Паттерн UnitOfWork.
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		//todo По мере разработки будем добавлять сюда репозитории. Пока добавим основыне.

		// IRepository<UserBase> как пример.
		void Save();
	}
}
