using BWSRulesEngine;

namespace BI.ServiceBus.Core.Template.Action.Rule
{
	internal class ValueShouldBeGreaterThanZeroRule : WorkRule
	{
		#region Constants
		public const string RULE_NAME = "ValueShouldBeGreaterThanZeroRule";
		#endregion

		#region Private Variables
		private readonly int _value;
		#endregion

		#region Constructor

		public ValueShouldBeGreaterThanZeroRule(int errorCode, string message, int value)
			: base(RULE_NAME, errorCode, message)
		{
			this._value = value;
		}

		#endregion

		#region Overridden Methods

		public override IWorkResult Verify()
		{
			base.IsValid = this._value > 0;
			return new WorkResult(this);
		}

		#endregion
	}
}