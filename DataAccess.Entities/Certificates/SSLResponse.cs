using Newtonsoft.Json;

namespace DataAccess.Entities.IONOSEntities.Certificates
{
	[Serializable]
	public class SSLResponse
    {
        [JsonProperty("total")]
        public int Total;

        [JsonProperty("certificates")]
        public List<Certificate> Certificates;
    }
}
