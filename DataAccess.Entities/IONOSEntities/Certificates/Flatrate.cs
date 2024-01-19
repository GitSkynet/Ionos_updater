using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.IONOSEntities.Certificates
{
	[Serializable]
	public class Flatrate
	{
		[JsonProperty("used")]
		public int? Used { get; set; }

		[JsonProperty("present")]
		public bool? Present { get; set; }
	}
}
