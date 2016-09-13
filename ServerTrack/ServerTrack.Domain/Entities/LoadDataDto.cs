
namespace ServerTrack.Domain.Entities
{
	using System;

	/// <summary>
	/// This class wraps the data retrieved from the 'database'
	/// </summary>
	public class LoadDataDto
	{
		/// <summary>
		/// Gets or sets the time period of the associated data. If it's a 
		/// given date, then simply a time on the hour, this data represents
		/// the data recorded for that hour. If it's a time on the minute, 
		/// then it represents the data recorded for that minute [for the 
		/// server specified in the retrieval request].
		/// </summary>
		/// <value>
		/// The time period.
		/// </value>
		public DateTime TimePeriod { get; set; }

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
	}
}
