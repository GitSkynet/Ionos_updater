using Newtonsoft.Json;

namespace DataAccess.Entities.IONOSEntities
{
	[Serializable]
	public class IonosDomain
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("rootName", NullValueHandling = NullValueHandling.Ignore)]
        public string RootName { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonProperty("changeDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ChangeDate { get; set; }

        [JsonProperty("ttl")]
        public int Ttl { get; set; }

        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool Disabled { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        
        [JsonProperty("prio", NullValueHandling = NullValueHandling.Ignore)]
        public string? Priority { get; set; }
    }
}