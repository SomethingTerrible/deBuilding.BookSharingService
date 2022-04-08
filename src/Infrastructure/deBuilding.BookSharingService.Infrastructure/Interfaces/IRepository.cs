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
		IEnumerable<T> GetAll();

		Task<T> GetByIdAsync(Guid id);

		Task CreateAsync(T entity);

		Task DeleteAsync(Guid id);

		Task UpdateAsync(T entity);
	}
}
