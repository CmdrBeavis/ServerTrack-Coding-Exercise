
namespace ServerTrack.Data.Infrastructure
{
	using System;
	using System.Collections.Generic;
	using Domain.Entities;

	/// <summary>
	/// Repository interface.
	/// </summary>
	/// <remarks>
	/// Genericness removed due to the scope of this exercise.
	/// </remarks>
	public interface IRepository
	{
		void Add(ServerTrackModel entity);

		// Updating and Deleting not supported for this exercise.
		//void Update(T entity);
		//void Delete(T entity);
		//void Delete(Expression<Func<T, bool>> where);

		ServerTrackModel GetById(Guid Id);

		ServerTrackModel Get(Func<ServerTrackModel, bool> where);

		IEnumerable<ServerTrackModel> GetAll();

		IEnumerable<ServerTrackModel> GetMany(Func<ServerTrackModel, bool> where);

		// Unnecessary due to using an in-memory data store.
		//void SaveChanges();
	}
}
