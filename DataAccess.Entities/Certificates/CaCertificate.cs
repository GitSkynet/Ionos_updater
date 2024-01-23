using Newtonsoft.Json;

namespace DataAccess.Entities.IONOSEntities.Certificates
{
    [Serializable]
    public class CaCertificate
    {
        [JsonProperty("type")]
        public string Type;

        [JsonProperty("certificate")]
        public string Certificate;
    }
}
