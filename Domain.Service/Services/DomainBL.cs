using DataAccess.DataAccess.Interfaces;
using DataAccess.Entities.Domains;
using DomainService.Contracts;

namespace Domain.Service.Services
{
    public class DomainBL : IDomainContract
    {
        private readonly IDomain iDomain;

        public DomainBL(IDomain iDomainInterface)
        {
            iDomain = iDomainInterface;
        }

        public async Task<List<IonosDomain>> UpdateAllDomains(string publicIP)
        {
            var domainZone = await iDomain.GetTheZoneID();
            List<IonosDomain> domainsZone = await iDomain.GetAllDomainsForZoneID(domainZone.Id);
            var filteredDomains = domainsZone.Where(x => x.Content != publicIP).ToList();
            List<IonosDomain> updateDomains = await iDomain.UpdateDomains(publicIP, domainZone, filteredDomains);
            return updateDomains;
        }

        public async Task<IonosDomain> CreateSubdomain(string subdomainName)
        {
            var domainZone = await GetTheZoneID();
            string ipOnIonos = await GetIpOnIonos();
            IonosDomain ionosDomain = new()
            {
                Name = subdomainName,
                Type = "A",
                Content = ipOnIonos,
                Ttl = 3600,
                Priority = "0",
                Disabled = false
            };

            var subDomainCreated = await iDomain.CreateSubdomain(domainZone, ionosDomain);
            return subDomainCreated;
        }

        public async Task<IonosZone> GetTheZoneID()
        {
            IonosZone domainZone = await iDomain.GetTheZoneID();
            return domainZone;
        }

        public async Task<List<IonosDomain>> GetAllDomainsForZoneID(string zoneID)
        {
            List<IonosDomain> domainsZone = await iDomain.GetAllDomainsForZoneID(zoneID);
            return domainsZone;
        }

        public async Task<string> GetIpOnIonos()
        {
            var domainZone = await iDomain.GetTheZoneID();
            List<IonosDomain> domainsZone = await iDomain.GetAllDomainsForZoneID(domainZone.Id);
            var filteredDomain = domainsZone.Where(x => x.Name == "vpn.carloscurtido.es").FirstOrDefault();

            return filteredDomain.Content;
        }
    }
}
