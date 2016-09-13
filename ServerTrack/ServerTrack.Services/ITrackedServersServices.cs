
namespace ServerTrack.Services
{
	using System;

	using Domain.Entities;


	/// <summary>
	/// This is the interface for the <see cref="TrackedServersServices"/> 
	/// class.
	/// </summary>
	public interface ITrackedServersServices
	{
		void WriteServerLoadTrackingRecord(ServerDataDto serverLoadData);
	}
}
