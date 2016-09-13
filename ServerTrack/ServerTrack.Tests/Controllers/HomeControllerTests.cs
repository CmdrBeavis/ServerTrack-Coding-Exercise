using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerTrack;
using ServerTrack.Controllers;

namespace ServerTrack.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTests
	{
		[TestMethod]
		public void Index()
		{
			// Arrange
			HomeController controller = new HomeController();

			// Act
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("Home Page", result.ViewBag.Title);
		}
	}
}
