using BWSRulesEngine;

namespace BI.ServiceBus.Core.Template.Action.Rule
{
	internal class ValueShouldNotBeEmptyOrNullRule : WorkRule
	{
		#region Public Constants
		public const string RULE_NAME = "ValueShouldNotBeEmptyOrNullRule";
		#endregion

		#region Private Variables
		private readonly string _value;
		#endregion

		#region Constructor

		public ValueShouldNotBeEmptyOrNullRule(int errorCode, string message, string value)
			: base(RULE_NAME, errorCode, message)
		{
			this._value = value;
		}

		#endregion

		#region Overridden Methods

		public override IWorkResult Verify()
		{
			base.IsValid = !string.IsNullOrWhiteSpace(this._value);
			return new WorkResult(this);
		}

		#endregion
	}
}