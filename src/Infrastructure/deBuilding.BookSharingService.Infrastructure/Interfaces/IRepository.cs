using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Infrastructure.Interfaces
{
	/// <summary>
	/// Интерфейс репозиторий. Будет изменяться со временем. Добавление еще асинхронных полей.
	/// </summary>
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAllAsync();

		Task<T> GetAsyncById(Guid id);

		void CreateAsync(T entity);

		void DeleteAsync(T entity);

		void Update(T entity);
	}
}
