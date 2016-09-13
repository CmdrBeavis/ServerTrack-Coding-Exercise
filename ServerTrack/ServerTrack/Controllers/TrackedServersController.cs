
namespace ServerTrack.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using System.Web.Http;

	using Domain.Entities;
	using Services;


	/// <summary>
	/// This is the Web API controller for the <c>clcTrackedServers</c> 
	/// endpoints.
	/// </summary>
	/// <seealso cref="System.Web.Http.ApiController" />
	[RoutePrefix("api/v1/clcTrackedServers")]
	public class TrackedServersController : ApiController
	{
		private ITrackedServersServices _services;

		public TrackedServersController(
			ITrackedServersServices services)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}

			_services = services;
		}

		/// <summary>
		/// GET api/v1/clcTrackedServers/AvgLast60m
		/// </summary>
		/// <returns>
		/// An IEnumerable&lt;ServerTrackModel&gt;
		/// </returns>
		[HttpGet]
		[Route("AvgLast60m")]
		public async Task<IHttpActionResult> GetAvgLast60m()
		{
			// IEnumerable<ServerTrackModel>
			List<ServerTrackModel> results = null;

			try
			{
				// the super-fun query goes here
				//results = _services.GetAvgOfLast60MinAsync();
			}
			catch (Exception oEx)
			{
				return InternalServerError(oEx);
			}

			return Ok(results);
		}

		/// <summary>
		/// GET api/v1/clcTrackedServers/AvgLast24h
		/// </summary>
		/// <returns>
		/// An IEnumerable&lt;ServerTrackModel&gt;
		/// </returns>
		[HttpGet]
		[Route("AvgLast24h")]
		public async Task<IHttpActionResult> GetAvgLast24h()
		{
			// IEnumerable<ServerTrackModel>
			List<ServerTrackModel> results = null;

			try
			{
				// the super-fun query goes here
				//results = _services.GetAvgLast24HrAsync();
			}
			catch (Exception oEx)
			{
				return InternalServerError(oEx);
			}

			return Ok(results);
		}

		/// <summary>
		/// Posts the specified server data.
		/// <para>
		/// POST api/v1/clcTrackedServers/{serverDataDTO}
		/// </para>
		/// </summary>
		/// <param name="serverData">
		/// An instance of the server load tracking data in the form of 
		/// </param>
		[HttpPost]
		[Route("{serverData}")]
		public async Task<IHttpActionResult> PostServerLoadTrackingData([FromBody]ServerDataDto serverData)
		{
			if (serverData == null)
			{
				return BadRequest("Invalid Server Tracking data.");
			}

			await Task.Run(() => _services.WriteServerLoadTrackingRecord(serverData));

			return Ok();
		}
	}
}
