
namespace ServerTrack.Data
{
	using System;
	using System.Collections.Generic;

	using Domain.Entities;


	/// <summary>
	/// This class encapsulates the in-memory data store for this application.
	/// </summary>
	public class ServerTrack_InMemDb
    {
		/// <summary>
		/// Used in the <see cref="SetupCardHoldersRepository()"/> method.
		/// </summary>
		List<ServerTrackModel> _serverTrackDataStore;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServerTrack_InMemDb"/> class.
		/// </summary>
		public ServerTrack_InMemDb()
		{
			_serverTrackDataStore = new List<ServerTrackModel>();
		}

		/// <summary>
		/// Sets up some fake 'ServerTrack' records.
		/// </summary>
		/// <returns>
		/// List&lt;ServerTrackModel&gt;
		/// </returns>
		public List<ServerTrackModel> InitializeServerTrackDataStore()
		{
			this._serverTrackDataStore = new List<ServerTrackModel>
			{
				new ServerTrackModel
				{
					id = new Guid("{35EBC5E8-931C-42A0-9D56-6F649A0171FE}"),
					ServerName = "ONeill",
					CpuLoad = 26.83,
					RamLoad = 5.2,
					RecordedDateTime = new DateTime(2016,9,12, 14, 15, 02)
				},
				new ServerTrackModel
				{
					id = new Guid("{128F65ED-1139-4DD8-8349-D6A91D015BF7}"),
					ServerName = "ONeill",
					CpuLoad = 26.9,
					RamLoad = 5.24,
					RecordedDateTime = new DateTime(2016,9,12, 14, 15, 12)
				},
				new ServerTrackModel
				{
					id = new Guid("{362BE8D6-3896-4A24-8428-CD6B54B4D7BB}"),
					ServerName = "ONeill",
					CpuLoad = 27.04,
					RamLoad = 5.26,
					RecordedDateTime = new DateTime(2016,9,12, 14, 15, 22)
				},
				new ServerTrackModel
				{
					id = new Guid("{510EFF6B-E0E6-4696-B771-48778C2DFA55}"),
					ServerName = "ONeill",
					CpuLoad = 25.23,
					RamLoad = 6,
					RecordedDateTime = new DateTime(2016,9,12, 14, 15, 32)
				},
				new ServerTrackModel
				{
					id = new Guid("{F3190CA4-611C-43C3-880A-ADFAA1B53111}"),
					ServerName = "ONeill",
					CpuLoad = 25.23,
					RamLoad = 6,
					RecordedDateTime = new DateTime(2016,9,12, 14, 15, 42)
				},
				new ServerTrackModel
				{
					id = new Guid("{A886D31F-C062-49CC-8673-279DFB6D027D}"),
					ServerName = "ONeill",
					CpuLoad = 25.23,
					RamLoad = 6,
					RecordedDateTime = new DateTime(2016,9,12, 14, 15, 52)
				}
			};

			return _serverTrackDataStore;
		}

		/// <summary>
		/// Gets the server track data store.
		/// <para>
		/// Accessor
		/// </para>
		/// </summary>
		public List<ServerTrackModel> ServerTrackDataStore
		{
			// TODO: Do I actually need this?
			get
			{
				if (_serverTrackDataStore.Count <= 0)
				{
					InitializeServerTrackDataStore();
				}

				return _serverTrackDataStore;
			}
		}
	}
}
