using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.IONOSEntities.Certificates
{
	[Serializable]
	public class Quota
	{
		[JsonProperty("total")]
		public int? Total { get; set; }

		[JsonProperty("used")]
		public int? Used { get; set; }

		[JsonProperty("quotaDetails")]
		public List<QuotaDetail> QuotaDetails { get; set; }

		[JsonProperty("flatrate")]
		public Flatrate Flatrate { get; set; }
	}
}
