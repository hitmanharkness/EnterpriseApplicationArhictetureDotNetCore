using System;
using System.Collections.Generic;
using System.Configuration;

namespace BI.Aspect.Config
{
	/// <summary>
	///
	/// </summary>
	public class ApplicationSettingsCollection : ConfigurationElementCollection
	{
		#region Public Properties

		/// <summary>
		///
		/// </summary>
		public override ConfigurationElementCollectionType CollectionType
			=> ConfigurationElementCollectionType.AddRemoveClearMap;

		/// <summary>
		///
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public ApplicationSettingsElement this[int index]
		{
			get { return (ApplicationSettingsElement)base.BaseGet(index); }
			set
			{
				if (base.BaseGet(index) != null)
					base.BaseRemoveAt(index);
				base.BaseAdd(index, value);
			}
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="keyName"></param>
		/// <returns></returns>
		new public ApplicationSettingsElement this[string keyName] => (ApplicationSettingsElement)base.BaseGet(keyName);

		#endregion

		#region Public Methods

		/// <summary>
		///
		/// </summary>
		/// <param name="element"></param>
		public void Add(ApplicationSettingsElement element)
		{
			this.BaseAdd(element);
		}

		/// <summary>
		///
		/// </summary>
		public void Clear()
		{
			base.BaseClear();
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="clientTypes"></param>
		/// <returns></returns>
		public ApplicationSettingsElement GetClientAppSettingsOrDefault(string clientTypes)
		{
			var cTypesArray = clientTypes.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			foreach (var cType in cTypesArray)
			{
				var appSettings = this[cType.ToUpper()];
				if (appSettings != null)
					return appSettings;
			}

			return this[ConfigSettingsStsInfo.DefaultClientTypeValue];
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="element"></param>
		protected override void BaseAdd(ConfigurationElement element)
		{
			base.BaseAdd(element, true);
		}

		/// <summary>
		///
		/// </summary>
		/// <returns></returns>
		protected override ConfigurationElement CreateNewElement()
		{
			return new ApplicationSettingsElement();
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ApplicationSettingsElement)element).ClientType;
		}

		#endregion
	}

	/// <summary>
	///
	/// </summary>
	public class ApplicationSettingsElement : ConfigurationElement
	{
		#region Constructor

		/// <summary>
		///
		/// </summary>
		public ApplicationSettingsElement()
		{
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="clientType"></param>
		public ApplicationSettingsElement(string clientType)
		{
			this.ClientType = clientType;
		}

		#endregion

		#region Private Constants

		private const string
			ACCOUNT_LOCKOUT_DURATION = "accountLockoutDuration",
			ACCOUNT_LOCKOUT_FAILED_LOGIN_ATTEMPTS = "accountLockoutFailedLoginAttempts",
			ALLOW_ACCOUNT_DELETION = "allowAccountDeletion",
			ALLOW_LOGIN_AFTER_ACCOUNT_CREATING = "allowLoginAfterAccountCreating",
			APP_NAME = "appName",
			CLAIMS_ARE_REQUIRED = "claimsAreRequired",
			CLIENT_TYPE = "clientType",
			EMAIL_IS_UNIQUE = "emailIsUnique",
			EMAIL_IS_USERNAME = "emailIsUserName",
			EMAIL_SIGNATURE = "emailSignature",
			EMAIL_MESSAGE_FORMATTER = "emailMessageFormatter",
			MINIMUM_VERSION = "minimumVersion",
			MOBILE_PHONE_NUMBER_IS_REQUIRED = "mobilePhoneNumberIsRequired",
			MOBILE_PHONE_NUMBER_IS_UNIQUE = "mobilePhoneNumberIsUnique",
			PASSWORD_HASHING_ITERATION_COUNT = "passwordHashingIterationCount",
			PASSWORD_RESET_FREQUENCY = "passwordResetFrequency",
			RELATIVE_CANCEL_VERIFICATION_URL = "relativeCancelVerificationUrl",
			RELATIVE_CONFIRM_CHANGE_EMAIL_URL = "relativeConfirmChangeEmailUrl",
			RELATIVE_CONFIRM_PASSWORD_RESET_URL = "relativeConfirmPasswordResetUrl",
			RELATIVE_LOGIN_URL = "relativeLoginUrl",
			REQUIRE_ACCOUNT_VERIFICATION = "requireAccountVerification",
			REQUIRE_MOBILE_PHONE_NUMBER_VERFICATION = "requireMobilePhoneNumberVerfication",
			REQUIRE_PASSWORD_RESET = "requirePasswordReset",
			REQUIRED_SCOPES = "requiredScopes",
			RESOURCE_OWNER = "resourceOwner",
			SECRET = "secret",
			UNIQUE_ID_IS_REQUIRED = "uniqueIdIsRequired",
			VERIFICATION_KEY_LIFETIME = "verificationKeyLifetime";

		#endregion

		#region Public Properties

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(ACCOUNT_LOCKOUT_DURATION, DefaultValue = 20)]
		public int AccountLockoutDuration => (int)this[ACCOUNT_LOCKOUT_DURATION];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(ACCOUNT_LOCKOUT_FAILED_LOGIN_ATTEMPTS, DefaultValue = 3)]
		public int AccountLockoutFailedLoginAttempts => (int)this[ACCOUNT_LOCKOUT_FAILED_LOGIN_ATTEMPTS];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(ALLOW_ACCOUNT_DELETION, DefaultValue = true)]
		public bool AllowAccountDeletion => (bool)this[ALLOW_ACCOUNT_DELETION];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(ALLOW_LOGIN_AFTER_ACCOUNT_CREATING, DefaultValue = true)]
		public bool AllowLoginAfterAccountCreating => (bool)this[ALLOW_LOGIN_AFTER_ACCOUNT_CREATING];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(APP_NAME, DefaultValue = "BI Inc, Security")]
		public string AppName => (string)this[APP_NAME];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(CLAIMS_ARE_REQUIRED, DefaultValue = false)]
		public bool ClaimsAreRequired => (bool)this[CLAIMS_ARE_REQUIRED];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(CLIENT_TYPE, IsKey = true, IsRequired = true)]
		public string ClientType
		{
			get { return ((string)this[CLIENT_TYPE] ?? string.Empty).ToUpper(); }
			set { this[CLIENT_TYPE] = value; }
		}

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(EMAIL_IS_UNIQUE, DefaultValue = true)]
		public bool EmailIsUnique => (bool)this[EMAIL_IS_UNIQUE];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(EMAIL_IS_USERNAME, DefaultValue = false)]
		public bool EmailIsUserName => (bool)this[EMAIL_IS_USERNAME];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(EMAIL_MESSAGE_FORMATTER)]
		public string EmailMessageFormatter => (string)this[EMAIL_MESSAGE_FORMATTER];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(EMAIL_SIGNATURE, DefaultValue = "BI Inc.")]
		public string EmailSignature => (string)this[EMAIL_SIGNATURE];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(MINIMUM_VERSION, DefaultValue = 1, IsRequired = false)]
		public int MinimumVersion => (int)this[MINIMUM_VERSION];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(MOBILE_PHONE_NUMBER_IS_REQUIRED, DefaultValue = false)]
		public bool MobilePhoneNumberIsRequired => (bool)this[MOBILE_PHONE_NUMBER_IS_REQUIRED];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(MOBILE_PHONE_NUMBER_IS_UNIQUE, DefaultValue = false)]
		public bool MobilePhoneNumberIsUnique => (bool)this[MOBILE_PHONE_NUMBER_IS_UNIQUE];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(PASSWORD_HASHING_ITERATION_COUNT, DefaultValue = 1000)]
		public int PasswordHashingIterationCount => (int)this[PASSWORD_HASHING_ITERATION_COUNT];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(PASSWORD_RESET_FREQUENCY, DefaultValue = 90)]
		public int PasswordResetFrequency => (int)this[PASSWORD_RESET_FREQUENCY];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(RELATIVE_CANCEL_VERIFICATION_URL, DefaultValue = "auth/CancelRegister/")]
		public string RelativeCancelVerificationUrl => (string)this[RELATIVE_CANCEL_VERIFICATION_URL];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(RELATIVE_CONFIRM_CHANGE_EMAIL_URL, DefaultValue = "auth/ConfirmChangeEmail/")]
		public string RelativeConfirmChangeEmailUrl => (string)this[RELATIVE_CONFIRM_CHANGE_EMAIL_URL];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(RELATIVE_CONFIRM_PASSWORD_RESET_URL, DefaultValue = "Action/ConfirmPasswordReset/?resetKey=")]
		public string RelativeConfirmPasswordResetUrl => (string)this[RELATIVE_CONFIRM_PASSWORD_RESET_URL];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(RELATIVE_LOGIN_URL, DefaultValue = "auth/Login")]
		public string RelativeLoginUrl => (string)this[RELATIVE_LOGIN_URL];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(REQUIRE_ACCOUNT_VERIFICATION, DefaultValue = false)]
		public bool RequireAccountVerification => (bool)this[REQUIRE_ACCOUNT_VERIFICATION];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(REQUIRED_SCOPES, DefaultValue = "offline_access read write ta")]
		public string RequiredScopes => (string)this[REQUIRED_SCOPES];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(REQUIRE_MOBILE_PHONE_NUMBER_VERFICATION, DefaultValue = false)]
		public bool RequireMobilePhoneNumberVerfication => (bool)this[REQUIRE_MOBILE_PHONE_NUMBER_VERFICATION];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(REQUIRE_PASSWORD_RESET, DefaultValue = false)]
		public bool RequirePasswordReset => (bool)this[REQUIRE_PASSWORD_RESET];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(RESOURCE_OWNER, DefaultValue = "roClient")]
		public string ResourceOwner => (string)this[RESOURCE_OWNER];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(SECRET, DefaultValue = "secret")]
		public string Secret => (string)this[SECRET];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(UNIQUE_ID_IS_REQUIRED, DefaultValue = true)]
		public bool UniqueIdIsRequired => (bool)this[UNIQUE_ID_IS_REQUIRED];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(VERIFICATION_KEY_LIFETIME, DefaultValue = 30)]
		public int VerificationKeyLifetime => (int)this[VERIFICATION_KEY_LIFETIME];

		#endregion
	}

	/// <summary>
	///
	/// </summary>
	public class ConfigSettingsStsInfo : ConfigurationSection
	{
		internal const string DefaultClientTypeValue = "DEFAULT";

		#region Private Constants

		private const string
			AUTHORITY = "authority",
			APPLICATIONS_SETTINGS = "applicationsSettings",
			CERT_THUMBPRINT = "certThumbPrint",
			DEFAULT_CLIENT_TYPE = "defaultClientType",
			REQUIRED_SCOPES = "requiredScopes",
			SECTION_NAME = "stsConfigs",
			SITE_NAME = "siteName",
			USER_DATA_STORE = "userDataStore";

		#endregion

		#region Lazy Load

		/// <summary>
		///
		/// </summary>
		public static readonly Lazy<ConfigSettingsStsInfo> Lazy = new Lazy<ConfigSettingsStsInfo>(GetConfigSettingsWebApi);

		/// <summary>
		///
		/// </summary>
		public static ConfigSettingsStsInfo Instance => Lazy.Value;

		private static ConfigSettingsStsInfo GetConfigSettingsWebApi()
		{
			var configSection = (ConfigSettingsStsInfo)ConfigurationManager.GetSection(SECTION_NAME);
			return configSection ?? new ConfigSettingsStsInfo();
		}

		#endregion

		#region Public Properties

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(APPLICATIONS_SETTINGS),
		ConfigurationCollection(typeof(ApplicationSettingsCollection),
			AddItemName = "add",
			ClearItemsName = "clear",
			RemoveItemName = "remove")]
		public ApplicationSettingsCollection ApplicationsSettings
		{
			get
			{
				var appsSettgins = (ApplicationSettingsCollection)base[APPLICATIONS_SETTINGS];
				if (appsSettgins != null && appsSettgins.Count > 0)
				{
					if (appsSettgins.GetClientAppSettingsOrDefault(DefaultClientTypeValue) == null)
						appsSettgins.Add(new ApplicationSettingsElement(DefaultClientTypeValue));
					return appsSettgins;
				}

				if (appsSettgins == null)
					base[APPLICATIONS_SETTINGS] =
						appsSettgins = new ApplicationSettingsCollection { new ApplicationSettingsElement(DefaultClientTypeValue) };
				else if (appsSettgins.Count.Equals(0))
					appsSettgins.Add(new ApplicationSettingsElement(DefaultClientTypeValue));

				return appsSettgins;
			}
		}

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(AUTHORITY, IsRequired = true)]//THE VALUE SHOULD BE THE STS URL
		public string Authority => this[AUTHORITY].ToString();

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(CERT_THUMBPRINT, DefaultValue = "")]
		public string CertThumbPrint => (string)this[CERT_THUMBPRINT];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(DEFAULT_CLIENT_TYPE, DefaultValue = "Default")]
		public string DefaultClientType => (string)this[DEFAULT_CLIENT_TYPE];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(REQUIRED_SCOPES, DefaultValue = "openid")]
		public string RequiredScopes => this[REQUIRED_SCOPES].ToString();

		/// <summary>
		///
		/// </summary>
		public IEnumerable<string> RequiredScopesArray => this.RequiredScopes.Split(' ');

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(SITE_NAME, DefaultValue = "BI Inc, Identity Server")]
		public string SiteName { get { return (string)this[SITE_NAME]; } set { this[SITE_NAME] = value; } }

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(USER_DATA_STORE, DefaultValue = "MembershipReboot")]
		public string UserDataStore => this[USER_DATA_STORE].ToString();

		#endregion
	}
}