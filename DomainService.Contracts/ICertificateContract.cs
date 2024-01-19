using DataAccess.Entities.IONOSEntities.Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Contracts
{
	public interface ICertificateContract
	{
		/// <summary>
		/// Obtiene una lista de los certificados asignados al usuario y devuelve una lista de tipo Certificate
		/// </summary>
		/// <returns>Lista de tipo <see cref="Certificate"/> que representa la lista de certificados asignados.</returns>
		public Task<List<Certificate>> GetCertificates();

		/// <summary>
		/// Obtiene por id los detalles del certificado asignado al usuario y devuelve un objeto de tipo Certificate
		/// </summary>
		/// <param name="certificateId">Identificador del certificado</param>
		/// <returns>Un objeto de tipo <see cref="Certificate"/> que representa el certificado requerido.</returns>
		public Task<Certificate> GetCertificateDetails(string certificateId);

		/// <summary>
		/// Obtiene la quota del certificado asignado al usuario
		/// </summary>
		/// <returns>Un objeto de tipo <see cref="Quota"/> que representa el certificado requerido.</returns>
		public Task<Quota> GetQuotaCertificate();

	}
}
