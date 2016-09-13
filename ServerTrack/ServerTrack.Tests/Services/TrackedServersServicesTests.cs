
namespace ServerTrack.Tests.Services
{
	using System;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Collections.Generic;

	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;

	using Domain.Entities;
	using ServerTrack.Services;
	using Data.Repositories;
	using Data;


	/// <summary>
	/// Summary description for TrackedServersServicesTests
	/// </summary>
	[TestClass]
	public class TrackedServersServicesTests
	{
		private ServerTrack_InMemDb _inMemDataStore;
		private IServerTrackRepository _repository;
		private ITrackedServersServices _services;

		/// <summary>
		/// Use TestInitialize to run code before running each test 
		/// </summary>
		[TestInitialize()]
		public void MyTestInitialize()
		{
			_inMemDataStore = new ServerTrack_InMemDb();

			var mockRepoBuilder = new FakeServerTrackRepositoryBuilder(_inMemDataStore);
			_repository = mockRepoBuilder.SetupMockedServerTrackRepository();

			_services = new TrackedServersServices(_repository);
		}

		/// <summary>
		/// Given valid data, the service's WriteServerLoadTrackingRecord 
		/// method creates a record.
		/// </summary>
		[TestMethod]
		public void GivenValidData_WriteServerLoadTrackingRecord_CreatesARecord()
		{
			// Arrange
			var expectedDateTimeRecorded = DateTime.Now;

			ServerDataDto serverData = new ServerDataDto()
			{
				ServerName = "Carter",
				CpuLoad = 32.56,
				RamLoad = 6.78,
				RecordedDateTime = expectedDateTimeRecorded
			};

			// Act
			_services.WriteServerLoadTrackingRecord(serverData);

			var createdRecord = _repository.Get(x => x.ServerName.Equals("Carter"));

			// Assert
			Assert.IsNotNull(createdRecord);
			Assert.AreEqual("Carter", createdRecord.ServerName);
		}
	}
}
