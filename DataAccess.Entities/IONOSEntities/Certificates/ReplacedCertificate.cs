using Newtonsoft.Json;

namespace DataAccess.Entities.IONOSEntities.Certificates
{
    [Serializable]
    public class ReplacedCertificate
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("serialNumber")]
        public string SerialNumber;
    }
}
