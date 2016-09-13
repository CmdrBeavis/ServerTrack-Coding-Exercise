
namespace ServerTrack.Data.Repositories
{
	using System;

	using Infrastructure;


	/// <summary>
	/// This is the interface for the <see cref="ServerTrackRepository"/> class.
	/// </summary>
	/// <seealso cref="ServerTrack.Data.Infrastructure.IRepository{ServerTrack.Domain.Entities.ServerTrackModel}" />
	public interface IServerTrackRepository : IRepository
	{ }

	/// <summary>
	/// This is the repository that wraps the <c>ServerTrack</c> in-memory 
	/// 'db' table.
	/// </summary>
	/// <seealso cref="ServerTrack.Data.Infrastructure.RepositoryBase{ServerTrack.Domain.Entities.ServerTrackModel}" />
	/// <seealso cref="ServerTrack.Data.Repositories.IServerTrackRepository" />
	public class ServerTrackRepository : RepositoryBase, IServerTrackRepository
	{
		public ServerTrackRepository(ServerTrack_InMemDb inMemDbStore) 
			: base(inMemDbStore)
		{
		}
	}
}
