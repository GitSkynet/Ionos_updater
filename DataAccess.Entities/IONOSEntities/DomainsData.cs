using Newtonsoft.Json;

namespace DataAccess.Entities.IONOSEntities
{
	[Serializable]
	public class DomainsData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("records")]
        public List<IonosDomain> Domains { get; set; }
    }
}
