using DataAccess.DataAccess.RESTServices.IONOS.Interfaces;
using DataAccess.Entities.IONOSEntities;
using Domain.Service.Services.IONOS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Ubuntu.Server.API.Tests.DomainLayerTests
{
	[TestClass]
	public class IonosServiceTest
	{
		private Mock<IDomain> IonosQueryService;
		private DomainBL ionosService;
		private List<IonosZone> ionosZoneList;

		[TestInitialize]
		public void Setup()
		{
			IonosQueryService = new Mock<IDomain>();
			ionosService = new(IonosQueryService.Object);

			ionosZoneList = new List<IonosZone>()
			{
				new IonosZone { Name = "carloscurtido.es", Id = "f537c70e-1801-11ec-814c-0a586444433b", Type = "NATIVE" },
				new IonosZone { Name = "lostrofollos.com", Id = "f334c70e-1801-22gh-814c-0a586444433d", Type = "NATIVE" },
				new IonosZone { Name = "vivaespania.es", Id = "f080c70e-1801-11ec-814c-0a586444433b", Type = "NATIVE" },
				new IonosZone { Name = "catalunaisespain.es", Id = "f554c70e-1801-11ec-814c-0a586444433b", Type = "NATIVE" },
				new IonosZone { Name = "midominio.com", Id = "f521c70e-1801-11ec-814c-0a5864444336", Type = "NATIVE" },
			};
		}

		[TestMethod]
		public void Test_GetTheZoneID()
		{
			var expectedResult = ionosZoneList.Single(x => x.Id == "f537c70e-1801-11ec-814c-0a586444433b");
			IonosQueryService.Setup(x => x.GetTheZoneID()).ReturnsAsync(expectedResult);

			var result = ionosService.GetTheZoneID().Result;

			Assert.IsNotNull(result); // asdasdsa
			Assert.IsNotNull(expectedResult);
			Assert.AreEqual(result, expectedResult);
		}
	}
}