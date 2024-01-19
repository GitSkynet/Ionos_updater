using DataAccess.DataAccess.RESTServices.IONOS.Interfaces;
using DataAccess.Entities.IONOSEntities.Certificates;
using DomainService.Contracts;

namespace Domain.Service.Services.IONOS
{
	public class CertificateBL : ICertificateContract
	{

		private readonly ICertificate certificateDA;

		public CertificateBL(ICertificate certificateDA)
		{
			this.certificateDA = certificateDA;
		}

		public async Task<List<Certificate>> GetCertificates()
		{
			List<Certificate> certificates = await certificateDA.GetCertificates();
			return certificates;
		}

		public async Task<Certificate> GetCertificateDetails(string certificateId)
		{
			Certificate certificates = await certificateDA.GetCertificateDetails(certificateId);
			return certificates;
		}

		public async Task<Quota> GetQuotaCertificate()
		{
			Quota quotaCertificate = await certificateDA.GetQuotaCertificate();
			return quotaCertificate;
		}
	}
}
