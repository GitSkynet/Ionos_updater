using Newtonsoft.Json;

namespace DataAccess.Entities.IONOSEntities.Certificates
{
    [Serializable]
    public class Certificate
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("certificateType")]
        public string CertificateType;

        [JsonProperty("authenticationMethod")]
        public string AuthenticationMethod;

        [JsonProperty("authenticationSummary")]
        public AuthenticationSummary AuthenticationSummary;

        [JsonProperty("status")]
        public string Status;

        [JsonProperty("commonName")]
        public string CommonName;

        [JsonProperty("alternativeNames")]
        public List<string>? AlternativeNames;

        [JsonProperty("validFrom")]
        public DateTime? ValidFrom;

        [JsonProperty("validUntil")]
        public DateTime? ValidUntil;

        [JsonProperty("serialNumber")]
        public string SerialNumber;

        [JsonProperty("caOrderId")]
        public string CaOrderId;

        [JsonProperty("replacedCertificates")]
        public List<ReplacedCertificate> ReplacedCertificates;

        // Certificado del dominio
        [JsonProperty("certificate")]
        public string BaseCertificate;

        // Certificado INTERMEDIO del dominio
        [JsonProperty("caCertificates")]
        public List<CaCertificate> CaCertificates;

        [JsonProperty("links")]
        public List<Link> Links;
    }
}
