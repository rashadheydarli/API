using System;
using Common.Entitties;

namespace DataAccess.Repository.Base
{
	public interface IRepository<T> where T : BaseEntity
	{
		Task<List<T>> GetAllAsync();
		Task<T> GetAsync(int id);
		Task CreateAsync(T entity);  //voidi (cunki yalniz bazaya elave edirem return yoxdu ) acync e cevirende Task yaziriq
		void Update(T entity);
		void Delete(T entity);
		//Task CommitAsync();
	}
}

