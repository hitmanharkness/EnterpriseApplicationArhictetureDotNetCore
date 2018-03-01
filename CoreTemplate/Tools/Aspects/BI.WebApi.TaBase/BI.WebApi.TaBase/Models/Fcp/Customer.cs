using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.WebApi.TaBase.Models.Fcp
{
	[Table("Customer")]
	internal class Customer
	{
		#region Primary key

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CustomerId { get; set; }

		#endregion

		#region Columns
		public string CustomerName { get; set; }

		[Required]
		public string CustomerNumber { get; set; }

		public int SourceCustomerId { get; set; }
		public int SourceId { get; set; }
		#endregion
	}
}