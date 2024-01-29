using DataAccess.Entities.Domains;
using DataAccess.Entities.IONOSEntities.Certificates;

namespace DomainService.Contracts
{
    public interface IDomainContract
    {
		/// <summary>
		/// Obtiene la zona asociada
		/// </summary>
		/// <returns>Una tarea asíncrona que devuelve un objeto de tipo <see cref="IonosZone"/>.</returns>
		public Task<IonosZone> GetTheZoneID();

		/// <summary>
		/// Obtiene una lista de dominios para una zona específica identificada por su ID.
		/// </summary>
		/// <param name="zoneID">El ID de la zona para la cual se desean obtener los dominios.</param>
		/// <returns>Una tarea asíncrona que devuelve una lista de objetos de tipo <see cref="IonosDomain"/>.</returns>
		public Task<List<IonosDomain>> GetAllDomainsForZoneID(string zoneID);

		/// <summary>
		/// Actualiza todos los dominios con una dirección IP pública específica.
		/// </summary>
		/// <param name="publicIP">La dirección IP pública que se utilizará para actualizar los dominios.</param>
		/// <returns>Una tarea asíncrona que devuelve una lista de objetos de tipo <see cref="IonosDomain"/>.</returns>
		public Task<List<IonosDomain>> UpdateAllDomains(string publicIP);

		/// <summary>
		/// Obtiene la dirección IP actual utilizada en Ionos para el subdominio vpn.carloscurtido.es
		/// </summary>
		/// <returns>Una tarea asíncrona que devuelve una cadena que representa la dirección IP.</returns>
		public Task<string> GetIpOnIonos();

		/// <summary>
		/// Crea un subdominio con el nombre especificado.
		/// </summary>
		/// <param name="subdomainName">El nombre del subdominio que se desea crear.</param>
		/// <returns>Una tarea asíncrona que devuelve un objeto de tipo <see cref="IonosDomain"/>.</returns>
		public Task<IonosDomain> CreateSubdomain(string subdomainName);
	}
}
