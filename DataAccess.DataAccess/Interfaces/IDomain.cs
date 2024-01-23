using DataAccess.Entities.Domains;
using DataAccess.Entities.IONOSEntities.Certificates;

namespace DataAccess.DataAccess.Interfaces
{
    public interface IDomain
    {
        /// <summary>
        /// Obtiene la zona de Ionos identificada por su ID.
        /// </summary>
        /// <returns>Una tarea asincrónica que representa la operación y devuelve un objeto de tipo <see cref="IonosZone"/>.</returns>
        public Task<IonosZone> GetTheZoneID();

        /// <summary>
        /// Obtiene una lista de dominios de Ionos para una zona específica identificada por su ID.
        /// </summary>
        /// <param name="zoneID">El ID de la zona para la cual se desean obtener los dominios.</param>
        /// <returns>Una tarea asincrónica que representa la operación y devuelve una lista de objetos de tipo <see cref="IonosDomain"/>.</returns>
        public Task<List<IonosDomain>> GetAllDomainsForZoneID(string zoneID);

        /// <summary>
        /// Crea un subdominio en una zona de Ionos utilizando un dominio de Ionos existente como base.
        /// </summary>
        /// <param name="domainZone">La zona de Ionos en la que se creará el subdominio.</param>
        /// <param name="ionosDomain">El dominio de Ionos que servirá como base para el nuevo subdominio.</param>
        /// <returns>Una tarea asincrónica que representa la operación y devuelve un objeto de tipo <see cref="IonosDomain"/>.</returns>
        public Task<IonosDomain> CreateSubdomain(IonosZone domainZone, IonosDomain ionosDomain);

        /// <summary>
        /// Actualiza los dominios de Ionos con una dirección IP pública específica, dentro de una zona específica.
        /// </summary>
        /// <param name="publicIP">La dirección IP pública que se utilizará para actualizar los dominios.</param>
        /// <param name="domainZone">La zona de Ionos en la que se realizará la actualización.</param>
        /// <param name="filteredDomains">Una lista de dominios de Ionos que se actualizarán.</param>
        /// <returns>Una tarea asincrónica que representa la operación y devuelve una lista de objetos de tipo <see cref="IonosDomain"/>.</returns>
        public Task<List<IonosDomain>> UpdateDomains(string publicIP, IonosZone domainZone, List<IonosDomain> domains);
    }
}
