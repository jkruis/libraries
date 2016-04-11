using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruisIT.Web.Analytics.Models
{
	[Table("Analytics_Visits")]
	public class Visit
	{
		public int Id { get; set; }

		public DateTime StartTime { get; set; }
		public DateTime? EndTime { get; set; }

		[Required]
		[MaxLength(45)]
		[Column(TypeName="VARCHAR")]
		public string IpAddress { get; set; }

		[MaxLength(100)]
		public string Website { get; set; }

		[Required]
		[MaxLength(2000)]
		public string Location { get; set; }
	}
}
