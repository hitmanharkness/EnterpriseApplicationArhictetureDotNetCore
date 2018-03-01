using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BI.WebApi.TaBase.Models.BiCaseMgmt
{
	[Table("AppServiceFunction")]
	internal class AppServiceFunction
	{
		#region Primary key

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.None),
		Column(Order = 1),
		ForeignKey("AppService")]
		public int AppServiceId { get; set; }

		[Key,
		DatabaseGenerated(DatabaseGeneratedOption.None),
		Column(Order = 2),
		ForeignKey("Function")]
		public int FunctionId { get; set; }

		#endregion

		#region Relationships
		public AppService AppService { get; set; }
		public Function Function { get; set; }
		#endregion
	}
}