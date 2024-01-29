using Newtonsoft.Json;

namespace DataAccess.Entities.IONOSEntities.Certificates
{
    [Serializable]
    public class Link
    {
        [JsonProperty("rel")]
        public string Rel;

        [JsonProperty("href")]
        public string Href;
    }
}
