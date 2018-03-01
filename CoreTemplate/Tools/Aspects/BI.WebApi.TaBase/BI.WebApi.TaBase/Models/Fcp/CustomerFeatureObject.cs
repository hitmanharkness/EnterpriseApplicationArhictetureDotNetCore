using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.WebApi.TaBase.Models.Fcp
{
	[Table("CustomerFeatureObject")]
	internal class CustomerFeatureObject
	{
		#region Primary Key

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int CustomerFeatureObjectId { get; set; }

		#endregion

		#region Columns

		[ForeignKey("Customer")]
		public int CustomerId { get; set; }

		public DateTime? EndDate { get; set; }
		public bool IsDemo { get; set; }

		[ForeignKey("FeatureObject")]
		public int ObjectId { get; set; }

		public DateTime StartDate { get; set; }
		#endregion

		#region Relationships
		public Customer Customer { get; set; }
		public FeatureObject FeatureObject { get; set; }
		#endregion
	}
}