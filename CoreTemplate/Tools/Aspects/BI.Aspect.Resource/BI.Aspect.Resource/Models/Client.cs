using System;

namespace BI.Repository.Resource.Models
{
	public class Client
	{
		public int ClientId { get; set; }
		public int EntityTypeId { get; set; }
		public bool IsActive { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string MiddleInitial { get; set; }
		public string Ssn { get; set; }
		public DateTime? BirthDate { get; set; }
		public string Gender { get; set; }
		public string Alias { get; set; }
		public string Comment { get; set; }
		public string InactivateReason { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime ChangeDate { get; set; }
		public int ChangeUserId { get; set; }
		public string CaseNumber { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public int? RiskLevel { get; set; }
		public int DefaultLanguageId { get; set; }
		public int? Height { get; set; }
		public int? Weight { get; set; }
		public int? ClientTypeId { get; set; }
		public int? CountryCodeOfOrigin { get; set; }
		public int? EducationLevelId { get; set; }
		public string EnglishSpokenProficiency { get; set; }
		public string EnglishReadingProficiency { get; set; }
		public int? Race { get; set; }
		public string MaritalStatus { get; set; }
		public string DistinguishingMarks { get; set; }
		public string HairColor { get; set; }
		public string EyeColor { get; set; }
		public string LicenseNumber { get; set; }
		public string LicenseState { get; set; }
		public DateTime? LicenseExpiration { get; set; }
		public bool? IsPregnant { get; set; }
		public DateTime? PregnancyConfirmed { get; set; }
		public DateTime? PregnancyDue { get; set; }
		public bool HasGangAffiliation { get; set; }
		public bool HasDisability { get; set; }
	}
}