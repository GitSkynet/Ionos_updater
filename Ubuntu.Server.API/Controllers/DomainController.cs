using DomainService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ubuntu.Server.API.Controllers
{
    [ApiController]
    [Route("api/ionos")]
    public class DomainController : ControllerBase
    {
        private readonly IDomainContract ionosDomainContract;

        public DomainController(IDomainContract ionosDomainContract) 
        {
            this.ionosDomainContract = ionosDomainContract;
        }

        [HttpGet]
        [Route("update_all_domains")]
        public async Task<IActionResult> UpdateAllDomains(string publicIP)
        {
            var updater = await ionosDomainContract.UpdateAllDomains(publicIP);
            return new ObjectResult(updater);
        }

		[HttpGet]
		[Route("create_subdomain")]
		public async Task<IActionResult> CreateSubdomain(string subdomainName)
		{
			var domainCreated = await ionosDomainContract.CreateSubdomain(subdomainName);
			return new ObjectResult(domainCreated);
		}

		[HttpGet]
        [Route("get_ip_on_ionos")]
        public async Task<IActionResult> GetIpOnIonos()
        {
            var ipUpdater = await ionosDomainContract.GetIpOnIonos();
            return new ObjectResult(ipUpdater);
        }

        [HttpGet]
        [Route("get_zone")]
        public async Task<IActionResult> GetTheZoneID()
        {
            return new ObjectResult(await ionosDomainContract.GetTheZoneID());
        }

        [HttpGet]
        [Route("get_domains_for_zoneid")]
        public async Task<IActionResult> GetAllDomainsForZoneID(string zondeID)
        {
            return new ObjectResult(await ionosDomainContract.GetAllDomainsForZoneID(zondeID));
        }
        
    }
}
