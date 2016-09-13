
namespace ServerTrack.Services
{
	using System;
	using System.Threading.Tasks;

	using Data.Repositories;
	using Domain.Entities;


	/// <summary>
	/// This class implements the service layer for the TrackedServers 
	/// Controller.
	/// </summary>
	/// <seealso cref="ServerTrack.Services.ITrackedServersServices" />
	public class TrackedServersServices : ITrackedServersServices
    {
		private IServerTrackRepository _repository;

		public TrackedServersServices(
			IServerTrackRepository repo)
		{
			// Note: I normally have a Guard class in my Utilities layer that
			// does this check.
			if (repo == null)
			{
				throw new ArgumentNullException("repo");
			}

			_repository = repo;
		}

		/// <summary>
		/// Writes the server load tracking record.
		/// </summary>
		/// <param name="serverLoadData">The server load data.</param>
		public async void WriteServerLoadTrackingRecord(ServerDataDto serverLoadData)
		{
			// convert to a ServerTrackModel - normally, I'd do this with AutoMapper
			var newServerTrackingDataRecord = new ServerTrackModel()
			{
				ServerName = serverLoadData.ServerName,
				CpuLoad = serverLoadData.CpuLoad,
				RamLoad = serverLoadData.RamLoad,
				RecordedDateTime = serverLoadData.RecordedDateTime
			};
			
			// then write to the in-memory data store
			await Task.Run(() => _repository.Add(newServerTrackingDataRecord));
		}
	}
}
