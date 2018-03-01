using BI.Aspect.Language.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BI.Aspect.Language
{
	/// <summary>
	///
	/// </summary>
	public class LanguageAspect
	{
		#region Lazy Load
		private static readonly Lazy<LanguageAspect> Lazy = new Lazy<LanguageAspect>(() => new LanguageAspect());

		/// <summary>
		///
		/// </summary>
		public static LanguageAspect Instance => Lazy.Value;

		#endregion

		/// <summary>
		///
		/// </summary>
		/// <param name="resourceId"></param>
		/// <returns></returns>
		public string GetStringResource(int resourceId)
		{
			using (var db = new LanguageAspectContext())
			{
				var languageId = this.GetThreadLanguageId(db);

				return
					db.ResourceTranslations
					.FirstOrDefault(x => x.ResourceId.Equals(resourceId) && x.LanguageId.Equals(languageId))
					?.ResourceString;
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="resources"></param>
		/// <returns></returns>
		public IEnumerable<Tuple<int, string>> GetStringResources(IEnumerable<int> resources)
		{
			using (var db = new LanguageAspectContext())
			{
				var languageId = this.GetThreadLanguageId(db);

				var resp = new List<Tuple<int, string>>();
				foreach (var rt in db.ResourceTranslations
					.Where(x => resources.Contains(x.ResourceId) && x.LanguageId.Equals(languageId)))
					resp.Add(new Tuple<int, string>(rt.ResourceId, rt.ResourceString));
				return resp;
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="resourceId"></param>
		/// <returns></returns>
		public Tuple<string, string> GetStringResourceTuple(int resourceId)
		{
			using (var db = new LanguageAspectContext())
			{
				var requestLanguageId = this.GetThreadLanguageId(db);

				const short defaultLanguageId = 1;

				var requestMessage = db.ResourceTranslations
					.FirstOrDefault(x => x.ResourceId.Equals(resourceId) && x.LanguageId.Equals(requestLanguageId))
					?.ResourceString;

				var defaultMessage = db.ResourceTranslations
					.FirstOrDefault(x => x.ResourceId.Equals(resourceId) && x.LanguageId.Equals(defaultLanguageId))
					?.ResourceString;

				return new Tuple<string, string>(requestMessage, defaultMessage);
			}
		}

		private short GetThreadLanguageId(LanguageAspectContext db)
		{
			return db.Languages
				.FirstOrDefault(x => x.LanguageTag.Equals(Thread.CurrentThread.CurrentCulture.Name))
				?.LanguageId ?? 1;
		}
	}
}