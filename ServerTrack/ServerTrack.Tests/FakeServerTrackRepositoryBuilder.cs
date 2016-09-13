
namespace ServerTrack.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using Moq;

	using Data;
	using Data.Repositories;
	using Domain.Entities;


	/// <summary>
	/// Encapsulates a function to create a mocked version of the 
	/// ServerTrack repository.
	/// </summary>
	public class FakeServerTrackRepositoryBuilder
	{
		private ServerTrack_InMemDb _serverTrackDataStore;

		/// <summary>
		/// Initializes a new instance of the <see cref="FakeServerTrackRepositoryBuilder"/> class.
		/// </summary>
		/// <param name="serverTrackDataStore">The server track data store.</param>
		/// <exception cref="System.ArgumentNullException">serverTrackDataStore</exception>
		public FakeServerTrackRepositoryBuilder(
			ServerTrack_InMemDb serverTrackDataStore)
		{
			if (serverTrackDataStore == null)
			{
				throw new ArgumentNullException("serverTrackDataStore");
			}

			_serverTrackDataStore = serverTrackDataStore;
		}

		/// <summary>
		/// Sets up a MOCK ServerTrackRepository so that we can test...
		/// </summary>
		/// <returns>
		/// An <see cref="IServerTrackRepository"/> instance.
		/// </returns>
		public IServerTrackRepository SetupMockedServerTrackRepository()
		{
			// create a mock repository
			var repo = new Mock<IServerTrackRepository>();

			// void Add(T entity);
			repo.Setup(r => r.Add(It.IsAny<ServerTrackModel>()))
				.Callback(new Action<ServerTrackModel>(newSvrTrackingRow =>
				{
					newSvrTrackingRow.id = Guid.NewGuid();
					newSvrTrackingRow.RecordedDateTime = DateTime.Now;

					_serverTrackDataStore.ServerTrackDataStore.Add(newSvrTrackingRow);
				}));

			// ServerTrackModel GetById(Guid Id);
			repo.Setup(r => r.GetById(It.IsAny<Guid>()))
				.Returns(new Func<Guid, ServerTrackModel>(
					id => _serverTrackDataStore.ServerTrackDataStore.Where(a => a.id.Equals(id)).FirstOrDefault()));

			// ServerTrackModel Get(Func < ServerTrackModel, bool > where);
			repo.Setup(r => r.Get(It.IsAny<Func<ServerTrackModel, bool>>()))
				.Returns(new Func<Func<ServerTrackModel, bool>, ServerTrackModel>(
					expr => _serverTrackDataStore.ServerTrackDataStore.Where(expr).FirstOrDefault()));

			// IEnumerable<ServerTrackModel> GetAll();
			repo.Setup(r => r.GetAll()).Returns(_serverTrackDataStore.ServerTrackDataStore);

			// IEnumerable<ServerTrackModel> GetMany(Func<ServerTrackModel, bool> where);
			repo.Setup(r => r.GetMany(It.IsAny<Func<ServerTrackModel, bool>>()))
				.Returns(new Func<Func<ServerTrackModel, bool>, IEnumerable<ServerTrackModel>>(
					expr => _serverTrackDataStore.ServerTrackDataStore.Where(expr).ToList()));

			return repo.Object;
		}
	}
}
