using System.ComponentModel;

namespace BI.Enterprise.Common.Translation.Enums
{
	public enum ResourceItem
	{
		[Description("The account is already verified.")]
		AccountAlreadyVerified = 1011,
		[Description("The account has been closed - Content.")]
		AccountClosedEmailContent = 1025,
		[Description("The account has been closed - Subject.")]
		AccountClosedEmailSubject = 1024,
		[Description("The account was not found.")]
		AccountNotFound = 1008,
		[Description("The account is closed.")]
		AccountClosed = 1009,
		[Description("The account is locked.")]
		AccountLocked = 1013,
		[Description("Account Locked - Content")]
		AccountLockedContent = 1041,
		[Description("Account Locked - Subject")]
		AccountLockedSubject = 1040,
		[Description("The account is not yet verified! Sending verification request.")]
		AccountNotVerifiedSendingEmail = 1010,
		[Description("AFR is not responding. Please, contact your supervision officer.")]
		AfrDown = -3,
		[Description("Another user was found with the same email.")]
		AnotherUserMatchEmail = 1026,
		[Description("The attempt doesn't exists.")]
		AttemptDoesNotExists = -1,
		[Description("The attempt is complete.")]
		AttemptIsComplete = -2,
		[Description("There was a problem registering your device with Azure.")]
		AzureRegistrationError = 1020,
		[Description("Compare process returned a low score.")]
		CompareLowScore = 1050,
		[Description("Conversation where are client is not present is not supported.")]
		ConversationClientNotIncluded = -4,
		[Description("Client is not registered for push notifications.")]
		ConversationClientIsNotPushNotEnabled = -5,
		[Description("Entity information is missing.")]
		ConversationEntityIsMissing = -6,
		[Description("The entity that sends the conversation message is missing.")]
		ConversationFromEntityIsMissing = -7,
		[Description("The conversation message is missing.")]
		ConversationMessageIsMissing = -8,
		[Description("The client has no officer assigned.")]
		ConversationNoOfficerAssigned = -9,
		[Description("The entity that receives the conversation message is missing.")]
		ConversationToEntityIsMissing = -10,
		[Description("The ConversationThreadId does not exists.")]
		ConversationThreadIdIsNotValid = -11,
		[Description("The search value is invalid.")]
		ConversationInvalidSearchValue = -13,
		[Description("The document does not exists.")]
		DocumentDoesNotExists = -12,
		[Description("The provided email is already assigned.")]
		EmailAlreadyAssigned = 1033,
		[Description("The email has not been verified, resetting the password is not allowed at this time.")]
		EmailNotVerifiedResetNotAllowed = 1012,
		[Description("Account's email has been verified - Content.")]
		EmailVerifiedEmailContent = 1023,
		[Description("Account's email has been verified - Subject.")]
		EmailVerifiedEmailSubject = 1022,
		[Description("The provided EntityId is already assigned.")]
		EntityAlreadyAssigned = 1031,
		[Description("The face is facing forward.")]
		FaceIsFrontal = 1049,
		[Description("The face is not facing forward.")]
		FaceNotFrontal = 1056,
		[Description("You don't have permission to execute this service.")]
		ForbiddenAccess = 998,
		[Description("There was an internal error processing your request. Please contact the service administrator.")]
		GenericErrorMessage = 999,
		[Description("The provided image has an incorrect format.")]
		ImageFormatIncorrect = 1015,
		[Description("The image number is outside the range.")]
		ImageNumberOutsideOfRange = 1047,
		[Description("The password reset key is invalid.")]
		InvalidResetKey = 1014,
		[Description("Invalid user name or password.")]
		InvalidUserNamePassword = 1039,
		[Description("Max number of retries reached.")]
		MaxRetriesReached = 1057,
		[Description("The ClientType is missing.")]
		MissingClientType = 1036,
		[Description("The events are missing.")]
		MissingEvents = 1021,
		[Description("There registration handle is missing.")]
		MissingHandle = 1017,
		[Description("The mobile phone number is missing.")]
		MissingMobilePhoneNumber = 1048,
		[Description("The password is missing.")]
		MissingPassword = 1035,
		[Description("There platform is missing.")]
		MissingPlatform = 1018,
		[Description("The Secret is missing.")]
		MissingSecret = 1037,
		[Description("Missing Unique Id")]
		MissingUniqueId = -14,
		[Description("Multiple eye pairs detected.")]
		MultipleEyePairsDetected = 1052,
		[Description("Multiple faces detected.")]
		MultipleFacesDetected = 1051,
		[Description("There are multiple users linked to this entity id.")]
		MultipleUsersLinkedToEntity = 1029,
		[Description("There are multiple users linked to this phone.")]
		MultipleUsersLinkedToPhone = 1030,
		[Description("New Password Must Be Different From Current Password.")]
		NewPasswordDifferentFromCurrent = 1004,
		[Description("New Password Must Be Different From Previous Three Passwords.")]
		NewPasswordDifferentFromPreviousThree = 1005,
		[Description("No eyes detected.")]
		NoEyesDetected = 1054,
		[Description("No face detected.")]
		NoFaceDetected = 1053,
		[Description("No master template in profile.")]
		NoMasterTemplate = 1055,
		[Description("Reset Password Email - Content")]
		ResetPasswordEmailContent = 1001,
		[Description("Reset Password Email - Subject")]
		ResetPasswordEmailSubject = 1000,
		[Description("Password Changed Email - Content")]
		PasswordChangedEmailContent = 1003,
		[Description("Password Changed Email - Subject")]
		PasswordChangedEmailSubject = 1002,
		[Description("The complexity rules for the password have not been met.")]
		PasswordComplexityRules = 1006,
		[Description("The provided phone is already assigned.")]
		PhoneAlreadyAssigned = 1032,
		[Description("There was an error during photo enrollment.")]
		PhotoEnrollmentError = 1016,
		[Description("The service plans are missing.")]
		ServicePlansMissing = 1028,
		[Description("The version of your app is not supported anymore. Please, update your app.")]
		UnsupportedApp = 1043,
		[Description("The provided platform is not supported.")]
		UnsupportedPlatform = 1019,
		[Description("The provided username is already assigned.")]
		UsernameAlreadyAssigned = 1034,
		[Description("The username and/or email is missing.")]
		UsernameEmailMissing = 1007,
		[Description("User not found.")]
		UserNotFound = 1027,
		[Description("Unknown credentials.")]
		UnknownCredentials = 1038,

		[Description("Tile for facial recognition module")]
		ModuleFacialRecognitionTitle = 1058,
		[Description("Title for VoiceID module")]
		ModuleVoiceIdTitle = 1059,
		[Description("Title for Calendar module")]
		ModuleCalendarTitle = 1080,
		[Description("Title for Self Report module")]
		ModuleSelfReportTitle = 1081,
		[Description("Title for Resources module")]
		ModuleResourcesTile = 1082,
		[Description("Title for Conversation module")]
		ModuleConversationTitle = 1083,
		[Description("Title for Document Capture module")]
		ModuleDocumentTitle = 1084,
		[Description("Title for Supervision Terms module")]
		ModuleSupervisionTerms = 1085,

		[Description("Missing Permissions")]
		MissingPermissions = -15
	}
}