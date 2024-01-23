using DataAccess.DataAccess.Interfaces;
using DataAccess.Entities.Domains;
using Infraestructure.Factories;
using log4net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace DataAccess.DataAccess.Services
{
    public class DomainDA : IDomain
    {
        private readonly ILog logger;
        private readonly HttpClient client;
        private readonly TelegramService telegramService;
        private readonly string getZoneURL = "https://api.hosting.ionos.com/dns/v1/zones/";

        public DomainDA(IConfiguration apiKeysFactory)
        {
            client = HttpClientFactory.BaseConfigClient(apiKeysFactory);
            telegramService = new TelegramService(apiKeysFactory);
            logger = LogManager.GetLogger(typeof(DomainDA));
        }

        public async Task<List<IonosDomain>> UpdateDomains(string publicIP, IonosZone domainZone, List<IonosDomain> filteredDomains)
        {
            List<IonosDomain> ionosDomains = new();
            try
            {
                foreach (IonosDomain domain in filteredDomains)
                {
                    var url = getZoneURL + domainZone.Id + "/records/" + domain.Id;
                    var request = new HttpRequestMessage(HttpMethod.Put, url);
                    request = HttpClientFactory.ConfigRequestIONOS(request);
                    var domainToUpdate = new
                    {
                        name = domain.Name,
                        type = domain.Type,
                        content = publicIP,
                        ttl = 300,
                        prio = 0,
                        disbaled = false
                    };
                    var jsonDomain = JsonConvert.SerializeObject(domainToUpdate);
                    request.Content = new StringContent(jsonDomain, Encoding.UTF8, "application/json");
                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        ionosDomains.Add(JsonConvert.DeserializeObject<IonosDomain>(jsonResponse!)!);
                        var message = $"Domain {domain.Name} updated with IP: {publicIP}";
                        await telegramService.SendMessage(message);
                    }
                    else
                    {
                        throw new Exception(string.Concat("Error: ", response.StatusCode.ToString()));
                    }
                }
                if (!ionosDomains.Any())
                {
                    await telegramService.SendMessage("Skynet API DNS UPDATER");
                    await telegramService.SendMessage("No DNS update required, all domains are updated");
                }
                return ionosDomains;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Failure: ", ex));
            }
        }

        public async Task<IonosZone> GetTheZoneID()
        {
            try
            {
                List<IonosZone> zones = new();
                var request = new HttpRequestMessage(HttpMethod.Get, getZoneURL);
                request = HttpClientFactory.ConfigRequestIONOS(request);
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    zones = JsonConvert.DeserializeObject<List<IonosZone>>(jsonResponse!)!;
                }
                else
                {
                    throw new Exception(string.Concat("Error: ", response.StatusCode.ToString()));
                }
                return zones.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Failure: ", ex));
            }
        }

        public async Task<IonosDomain> CreateSubdomain(IonosZone domainZone, IonosDomain ionosDomain)
        {
            try
            {
                IonosDomain domainCreated = new();
                var url = getZoneURL + domainZone.Id + "/records/";
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request = HttpClientFactory.ConfigRequestIONOS(request);
                var jsonArray = new[] { ionosDomain };
                var jsonString = JsonConvert.SerializeObject(jsonArray);
                request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    domainCreated = JsonConvert.DeserializeObject<IonosDomain[]>(jsonResponse!)![0];
                    var message = $"Domain {domainCreated.Name} created with IP: {domainCreated.Content}";
                    await telegramService.SendMessage(message);
                }
                else
                {
                    throw new Exception(string.Concat("Error: ", response.StatusCode.ToString()));
                }
                return domainCreated;

            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Domain creation failed: ", ex));
            }
        }

        public async Task<List<IonosDomain>> GetAllDomainsForZoneID(string zoneID)
        {
            try
            {
                DomainsData domainsData = new();
                var request = new HttpRequestMessage(HttpMethod.Get, getZoneURL + zoneID);
                request = HttpClientFactory.ConfigRequestIONOS(request);
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    domainsData = JsonConvert.DeserializeObject<DomainsData>(jsonResponse!)!;
                }
                else
                {
                    throw new Exception(string.Concat("Error: ", response.StatusCode.ToString()));
                }
                return domainsData.Domains.Where(x => x.Type == "A").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Failure: ", ex));
            }
        }
    }
}
