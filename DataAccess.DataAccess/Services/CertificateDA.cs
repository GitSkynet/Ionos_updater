using DataAccess.DataAccess.Interfaces;
using DataAccess.Entities.IONOSEntities.Certificates;
using Infraestructure.Factories;
using log4net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DataAccess.DataAccess.Services
{
    public class CertificateDA : ICertificate
    {
        private readonly ILog logger;
        private readonly HttpClient client;
        private readonly TelegramService telegramService;
        private readonly string getSSLURL = "https://api.hosting.ionos.com/ssl/v1/certificates/";
        private readonly string getQuotaURL = "https://api.hosting.ionos.com/ssl/v1/certificates/quota/";

        public CertificateDA(IConfiguration apiKeysFactory)
        {
            client = HttpClientFactory.BaseConfigClient(apiKeysFactory);
            telegramService = new TelegramService(apiKeysFactory);
            logger = LogManager.GetLogger(typeof(DomainDA));
        }


        public async Task<List<Certificate>> GetCertificates()
        {
            try
            {
                SSLResponse sslResponse = new();
                var request = new HttpRequestMessage(HttpMethod.Get, getSSLURL);
                request = HttpClientFactory.ConfigRequestIONOS(request);
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    sslResponse = JsonConvert.DeserializeObject<SSLResponse>(jsonResponse!)!;
                }
                else
                {
                    throw new Exception(string.Concat("Error: ", response.StatusCode.ToString()));
                }
                return sslResponse.Certificates;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Failure: ", ex));
            }
        }

        public async Task<Certificate> GetCertificateDetails(string certificateId)
        {
            try
            {
                Certificate certificate = new();
                var request = new HttpRequestMessage(HttpMethod.Get, getSSLURL + certificateId);
                request = HttpClientFactory.ConfigRequestIONOS(request);
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    certificate = JsonConvert.DeserializeObject<Certificate>(jsonResponse!)!;
                }
                else
                {
                    throw new Exception(string.Concat("Error: ", response.StatusCode.ToString()));
                }
                return certificate;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Failure: ", ex));
            }
        }

        public async Task<Quota> GetQuotaCertificate()
        {
            try
            {
                Quota quotaCertificate = new();
                var request = new HttpRequestMessage(HttpMethod.Get, getQuotaURL);
                request = HttpClientFactory.ConfigRequestIONOS(request);
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    quotaCertificate = JsonConvert.DeserializeObject<Quota>(jsonResponse!)!;
                }
                else
                {
                    throw new Exception(string.Concat("Error: ", response.StatusCode.ToString()));
                }
                return quotaCertificate;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Failure: ", ex));
            }
        }
    }
}
