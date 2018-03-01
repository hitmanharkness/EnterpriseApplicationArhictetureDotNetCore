using BWSRulesEngine;

namespace BI.ServiceBus.Core.Template.Action.Rule
{
	internal class IdEqualTo4Returns404Rule : WorkRule
	{
		#region Public Constants
		public const string RULE_NAME = "IdEqualTo4Returns404Rule";
		#endregion

		#region Private Variables
		private readonly int _id;
		#endregion

		#region Constructor

		public IdEqualTo4Returns404Rule(int errorCode, string message, int id)
			: base(RULE_NAME, errorCode, message)
		{
			this._id = id;
		}

		#endregion

		#region Overridden Methods

		public override IWorkResult Verify()
		{
			base.IsValid = this._id != 4;
			return new WorkResult(this);
		}

		#endregion
	}
}