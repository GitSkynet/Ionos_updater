using Newtonsoft.Json;

namespace DataAccess.Entities.IONOSEntities.Certificates
{
    [Serializable]
    public class AuthenticationSummary
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("method")]
        public string Method;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("content")]
        public string Content;

        [JsonProperty("status")]
        public string Status;
    }
}
