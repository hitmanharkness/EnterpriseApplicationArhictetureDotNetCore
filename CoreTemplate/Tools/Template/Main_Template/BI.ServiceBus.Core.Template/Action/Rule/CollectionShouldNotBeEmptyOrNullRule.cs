using BWSRulesEngine;
using System.Collections.Generic;
using System.Linq;

namespace BI.ServiceBus.Core.Template.Action.Rule
{
	internal class CollectionShouldNotBeEmptyOrNullRule<T> : WorkRule
	{
		#region Constants

		private const string RULE_NAME = "CollectionShouldNotBeEmptyOrNullRule";

		#endregion

		#region Private Variables

		private readonly IEnumerable<T> _collection;

		#endregion

		#region Constructor

		public CollectionShouldNotBeEmptyOrNullRule(int errorCode, string message, IEnumerable<T> collection)
			: base(RULE_NAME, errorCode, message) =>
			this._collection = collection;

		#endregion

		#region Overridden Methods

		public override IWorkResult Verify()
		{
			base.IsValid = this._collection != null && this._collection.Any();
			return new WorkResult(this);
		}

		#endregion
	}
}