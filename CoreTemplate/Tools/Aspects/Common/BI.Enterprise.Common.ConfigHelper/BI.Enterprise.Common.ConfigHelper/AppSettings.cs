using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;

namespace BI.Enterprise.Common.ConfigHelper
{
	using Extensions;

	/// <summary>
	/// Contains methods to access the appSettings section of the web.config or app.config file.
	/// </summary>
	public class AppSettings
	{
		private Configuration Config { get; set; }
		private KeyValueConfigurationCollection Settings { get; set; }
		private DateTime LastConfigFileChange { get; set; }

		private AppSettings()
		{
			this.LoadConfigManager();
		}

		private static AppSettings _instance;

		public static AppSettings Instance => _instance ?? (_instance = new AppSettings());

		#region Public Static Methods

		/// <summary>
		/// Gets the keyName's value from the appSettngs section in the web.config or app.config and returns the value.
		/// If the key doesn't exists or the value is not a number, the default value will be returned instead.
		/// </summary>
		/// <param name="keyName">The app setting key name.</param>
		/// <param name="defaultValue">The value to return in case the keyName doesn't exist or is not a number.</param>
		/// <param name="refreshSection">true to refresh the section before reading the value; Otherwise false.</param>
		/// <returns>The keyName value as an int.</returns>
		public static int GetIntValue(string keyName, int defaultValue = 0, bool refreshSection = false)
		{
			try
			{
				if (refreshSection)
					RefreshAppConfigSection();
				if (!Instance.Settings.AllKeys.Contains(keyName))
					return defaultValue;

				int resp;
				return int.TryParse(Instance.Settings[keyName].Value, out resp) ? resp : defaultValue;
			}
			catch (Exception) { throw; }
		}

		/// <summary>
		/// Gets the keyName's value from the appSettngs section in the web.config or app.config and returns the value.
		/// If the key doesn't exists or the value is not a number, the default value will be returned instead.
		/// </summary>
		/// <param name="keyName">The appSettings key name.</param>
		/// <param name="defaultValue">The value to return in case the keyName doesn't exist or is not a number.</param>
		/// <param name="refreshSection">true to refresh the section before reading the value; Otherwise false.</param>
		/// <returns>The keyName value as a short.</returns>
		public static short GetShortValue(string keyName, short defaultValue = 0, bool refreshSection = false)
		{
			try
			{
				return (short)GetIntValue(keyName, defaultValue, refreshSection);
			}
			catch (Exception) { throw; }
		}

		/// <summary>
		/// Gets the specified key from the appSettings section in the web.config file.
		/// </summary>
		/// <param name="keyName">The name of the key.</param>
		/// <param name="refreshSection">true to refresh the section before reading the value; Otherwise false.</param>
		/// <returns>A string that represents the key name value.</returns>
		/// <exception cref="ConfigurationErrorsException">The key was not found</exception>
		public static string GetStringValue(string keyName, bool refreshSection = false)
		{
			if (refreshSection)
				RefreshAppConfigSection();
			if (!Instance.Settings.AllKeys.Contains(keyName))
				throw new ConfigurationErrorsException($"App setting key was not found. Key = {keyName}");

			return Instance.Settings[keyName].Value;
		}

		/// <summary>
		/// Gets the specified key from the appSettings section in the web.config file.
		/// </summary>
		/// <param name="keyName">The name of the key.</param>
		/// <param name="defaultValue">The value to return in case the keyName does not exists.</param>
		/// <param name="refreshSection">true to refresh the section before reading the value; Otherwise false.</param>
		/// <returns>A string that represents the key name value.</returns>
		public static string GetStringValue(string keyName, string defaultValue, bool refreshSection = false)
		{
			if (refreshSection)
				RefreshAppConfigSection();
			if (!Instance.Settings.AllKeys.Contains(keyName))
				return defaultValue;
			return Instance.Settings[keyName].Value;
		}

		/// <summary>
		/// Gets the specified keyname's value from the appSettings section in the web.config or app.config file as DateTime.
		/// If the keyname does not exists or if the value cannot be parsed as DateTime the DateTime.MinValue will be returned.
		/// </summary>
		/// <param name="keyName">Te appSettings KeyName.</param>
		/// <param name="refreshSection">true to refresh the section before reading the value; Otherwise false.</param>
		/// <returns>The KeyName value as DateTime.</returns>
		public static DateTime GetDateTimeValue(string keyName, bool refreshSection = false)
		{
			try
			{
				if (refreshSection)
					RefreshAppConfigSection();

				DateTime output;
				if (!Instance.Settings.AllKeys.Contains(keyName) ||
					string.IsNullOrWhiteSpace(Instance.Settings[keyName].Value) ||
					!DateTime.TryParse(Instance.Settings[keyName].Value, out output))
					throw new ConfigurationErrorsException($"App setting key was not found or has not a valid value. Key = '{keyName}'");

				return output;
			}
			catch (Exception) { throw; }
		}

		/// <summary>
		/// Gets the specified keyname's value from the appSettings section in the web.config or app.config file as DateTime.
		/// If the keyname does not exists or if the value cannot be parsed as DateTime the default value will be returned.
		/// </summary>
		/// <param name="keyName">The appSettings keyname.</param>
		/// <param name="defaultValue">The value to return in case the keyName does not exists or if the value cannot be parsed as DateTime.</param>
		/// <param name="refreshSection">true to refresh the section before reading the value; Otherwise false.</param>
		/// <returns>The KeyName value as DateTime.</returns>
		public static DateTime GetDateTimeValue(string keyName, DateTime defaultValue, bool refreshSection = false)
		{
			try
			{
				if (refreshSection)
					RefreshAppConfigSection();

				DateTime output;
				if (!Instance.Settings.AllKeys.Contains(keyName) ||
					string.IsNullOrWhiteSpace(Instance.Settings[keyName].Value) ||
					!DateTime.TryParse(Instance.Settings[keyName].Value, out output))
					return defaultValue;

				return output;
			}
			catch { throw; }
		}

		/// <summary>
		/// Gets the value of the specified app settting key in the web.config or app.config file as a boolean.
		/// If the app setting key does not exists or if the value cannot be parsed as boolean, the default value will be returned.
		/// </summary>
		/// <param name="keyName">Name of the key.</param>
		/// <param name="defaultValue">if set to <c>true</c> [default value].</param>
		/// <param name="refreshSection">true to refresh the section before reading the value; Otherwise false.</param>
		/// <returns>The app setting key value as a boolean.</returns>
		public static bool GetBoolValue(string keyName, bool defaultValue = false, bool refreshSection = false)
		{
			if (refreshSection)
				RefreshAppConfigSection();

			bool res;
			if (!Instance.Settings.AllKeys.Contains(keyName) ||
				string.IsNullOrWhiteSpace(Instance.Settings[keyName].Value) ||
				!bool.TryParse(Instance.Settings[keyName].Value, out res))
				return defaultValue;

			return res;
		}

		public static bool RefreshAppConfigSection()
		{
			if (Instance.LastConfigFileChange == File.GetLastWriteTime(Instance.Config.FilePath))
				return false;

			Instance.LoadConfigManager();
			return true;
		}

		private void LoadConfigManager()
		{
			var appSettings = ConfigurationManager.GetSection("appSettings") as NameValueCollection;
			try
			{
				this.Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			}
			catch (Exception)
			{
				try
				{
					this.Config =
						System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(
							System.Web.HttpContext.Current.Request.ApplicationPath);
				}
				catch
				{
					this.Config = null;
				}
			}

			this.Settings = (this.Config?.GetSection("appSettings") as AppSettingsSection)?.Settings;
			if (this.Settings == null)
			{
				this.Settings = new KeyValueConfigurationCollection();
				appSettings?.AllKeys.ForEach(key => this.Settings.Add(new KeyValueConfigurationElement(key, appSettings[key])));
			}
			this.LastConfigFileChange = this.Config == null ? DateTime.MinValue : File.GetLastWriteTime(this.Config.FilePath);
		}

		#endregion
	}
}