using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.WebApi.TaBase.Models.Fcp
{
	[Table("FeatureObject")]
	internal class FeatureObject
	{
		#region Primary key

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int ObjectId { get; set; }

		#endregion

		#region Columns
		public int FeatureId { get; set; }
		public bool IsEnabled { get; set; }
		public string ObjectName { get; set; }
		public int PointValue { get; set; }
		public int ReferenceId { get; set; }
		#endregion
	}
}