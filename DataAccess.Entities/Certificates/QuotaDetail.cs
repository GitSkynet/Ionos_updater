using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.IONOSEntities.Certificates
{
	[Serializable]
	public class QuotaDetail
	{
		[JsonProperty("total")]
		public int? Total { get; set; }

		[JsonProperty("used")]
		public int? Used { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
