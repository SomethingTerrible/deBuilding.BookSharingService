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
		Task<IEnumerable<T>> GetAllAsync();

		Task<T> GetAsyncById(Guid id);

		void Create(T entity);

		void Deleate(T entity);

		void Update(T entity);
	}
}
