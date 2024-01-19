using DomainService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ubuntu.Server.API.Controllers
{
	[ApiController]
	[Route("api/ionos/ssl")]
	public class CertificateController : ControllerBase
	{
		private readonly ICertificateContract sslContract;

		public CertificateController(ICertificateContract sslContract)
		{
			this.sslContract = sslContract;
		}

		[HttpGet]
		[Route("get_certificates")]
		public async Task<IActionResult> GetCertificates()
		{
			var certificates = await sslContract.GetCertificates();
			return new ObjectResult(certificates);
		}
		
		[HttpGet]
		[Route("get_certificate_Details")]
		public async Task<IActionResult> GetCertificateDetails(string certificateId)
		{
			var certificates = await sslContract.GetCertificateDetails(certificateId);
			return new ObjectResult(certificates);
		}
		
		[HttpGet]
		[Route("get_quota_certificate")]
		public async Task<IActionResult> GetQuotaCertificate()
		{
			var certificates = await sslContract.GetQuotaCertificate();
			return new ObjectResult(certificates);
		}
	}
}

