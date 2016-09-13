
namespace ServerTrack.Tests.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net.Http;
	using System.Text;
	using System.Web.Http;
	using Data;
	using Data.Repositories;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using ServerTrack;
	using ServerTrack.Controllers;
	using ServerTrack.Services;


	[TestClass]
	public class TrackedServersControllerTests
	{
		private ServerTrack_InMemDb _inMemDataStore;
		private IServerTrackRepository _repository;
		private ITrackedServersServices _services;

		/// <summary>
		/// Initializes items needed for the tests.
		/// </summary>
		[TestInitialize()]
		public void InitializeForTests()
		{
			_inMemDataStore = new ServerTrack_InMemDb();

			var mockRepoBuilder = new FakeServerTrackRepositoryBuilder(_inMemDataStore);
			_repository = mockRepoBuilder.SetupMockedServerTrackRepository();

			_services = new TrackedServersServices(_repository);
		}

		// TODO: Need to test the following Controller methods
		// async Task<IHttpActionResult> PostServerLoadTrackingData([FromBody]ServerDataDto serverData)
		// async Task<IHttpActionResult> GetAvgLast60m()
		// async Task<IHttpActionResult> GetAvgLast24h()

	}
}
