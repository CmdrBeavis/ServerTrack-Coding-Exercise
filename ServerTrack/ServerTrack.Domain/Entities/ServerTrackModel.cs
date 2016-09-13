
namespace ServerTrack.Domain.Entities
{
	using System;


	public class ServerTrackModel
	{
		/// <summary>
		/// Gets or sets the row identifier.
		/// </summary>
		/// <value>
		/// A GUID that will represent this 'row' in an in-memory table.
		/// </value>
		/// [Key] - if this were an Entity Framework POCO/Model class
		public Guid id { get; set; }

		/// <summary>
		/// Gets or sets the name of the server.
		/// </summary>
		/// <value>
		/// The name of the server.
		/// </value>
		public string ServerName { get; set; }

		/// <summary>
		/// Gets or sets the cpu load.
		/// </summary>
		/// <value>
		/// The cpu load.
		/// </value>
		public double CpuLoad { get; set; }

		/// <summary>
		/// Gets or sets the ram load.
		/// </summary>
		/// <value>
		/// The ram load.
		/// </value>
		public double RamLoad { get; set; }

		/// <summary>
		/// Gets or sets the recorded date time of the associated data 
		/// recorded for the server who's name is stored in the 
		/// <c>ServerName</c> property of this class.
		/// </summary>
		/// <value>
		/// The recorded date time.
		/// </value>
		public DateTime RecordedDateTime { get; set; }
	}
}
