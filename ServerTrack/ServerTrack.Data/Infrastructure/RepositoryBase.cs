
namespace ServerTrack.Data.Infrastructure
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading.Tasks;

	using Domain.Entities;


	/// <summary>
	/// This is an abstract base-class for a generic Repository pattern, 
	/// except that the generic-ness has been removed due to this being part
	/// of an exercise and I've only got one in-memory database/store.
	/// </summary>
	public abstract class RepositoryBase
	{
		private List<ServerTrackModel> _serverTrackDataStore;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="inMemDbStore">
		/// An instance of the <see cref="ServerTrack_InMemDb"/>
		/// </param>
		protected RepositoryBase(
			ServerTrack_InMemDb inMemDbStore)
		{
			if (inMemDbStore == null)
			{
				throw new ArgumentNullException("inMemDbStore");
			}

			_serverTrackDataStore = inMemDbStore.InitializeServerTrackDataStore();
		}

		public virtual void Add(ServerTrackModel entity)
		{
			// get a new GUID and add to new record as its 'row id.'
			if (entity.id == Guid.Empty)
			{
				entity.id = Guid.NewGuid();
			}

			_serverTrackDataStore.Add(entity);
		}

		public virtual ServerTrackModel GetById(Guid id)
		{
			return _serverTrackDataStore.Where(obj => obj.id == id).SingleOrDefault();
		}

		public virtual IEnumerable<ServerTrackModel> GetAll()
		{
			return _serverTrackDataStore.ToList();
		}

		public virtual IEnumerable<ServerTrackModel> GetMany(Func<ServerTrackModel, bool> where)
		{
			return _serverTrackDataStore.Where(where);
		}

		public ServerTrackModel Get(Func<ServerTrackModel, bool> where)
		{
			return _serverTrackDataStore.Where(where).FirstOrDefault<ServerTrackModel>();
		}
	}
}
