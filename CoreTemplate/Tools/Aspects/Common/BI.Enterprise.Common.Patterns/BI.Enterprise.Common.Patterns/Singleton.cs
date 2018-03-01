using System;

namespace BI.Enterprise.Common.Patterns
{
	/// <summary>
	/// Inherit from this class to create a singleton instance of your class.  &lt;T&gt; is the same class that inherits this object!<br/>
	/// </summary>
	/// <example>
	/// <code>
	/// public MyClass : Singleton&lt;MyClass&gt;
	/// </code>
	/// </example>
	/// <typeparam name="T">The class that is implementing this base class</typeparam>
	public class Singleton<T> where T : new()
	{
		protected static readonly Lazy<T> Lazy = new Lazy<T>(() => new T());

		public static T Instance => Lazy.Value;

		protected Singleton()
		{
		}
	}
}