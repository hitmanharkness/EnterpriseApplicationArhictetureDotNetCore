using System.Data.Entity.ModelConfiguration;

namespace BI.Repository.Resource.Models.Mapping
{
	public class ClientMap : EntityTypeConfiguration<Client>
	{
		public ClientMap()
		{
			// Primary Key
			this.HasKey(t => t.ClientId);

			// Properties
			this.Property(t => t.LastName)
				.IsRequired()
				.HasMaxLength(50);

			this.Property(t => t.FirstName)
				.IsRequired()
				.HasMaxLength(50);

			this.Property(t => t.MiddleInitial)
				.HasMaxLength(1);

			this.Property(t => t.Ssn)
				.HasMaxLength(11);

			this.Property(t => t.Gender)
				.HasMaxLength(1);

			this.Property(t => t.Alias)
				.HasMaxLength(50);

			this.Property(t => t.Comment)
				.HasMaxLength(1000);

			this.Property(t => t.InactivateReason)
				.HasMaxLength(50);

			this.Property(t => t.CaseNumber)
				.HasMaxLength(20);

			this.Property(t => t.EnglishSpokenProficiency)
				.IsRequired()
				.HasMaxLength(50);

			this.Property(t => t.EnglishReadingProficiency)
				.IsRequired()
				.HasMaxLength(50);

			this.Property(t => t.MaritalStatus)
				.HasMaxLength(25);

			this.Property(t => t.DistinguishingMarks)
				.HasMaxLength(256);

			this.Property(t => t.HairColor)
				.HasMaxLength(25);

			this.Property(t => t.EyeColor)
				.HasMaxLength(25);

			this.Property(t => t.LicenseNumber)
				.HasMaxLength(20);

			this.Property(t => t.LicenseState)
				.HasMaxLength(4);

			// Table & Column Mappings
			this.ToTable("client");
			this.Property(t => t.ClientId).HasColumnName("client_id");
			this.Property(t => t.EntityTypeId).HasColumnName("entity_type_id");
			this.Property(t => t.IsActive).HasColumnName("is_active");
			this.Property(t => t.LastName).HasColumnName("last_name");
			this.Property(t => t.FirstName).HasColumnName("first_name");
			this.Property(t => t.MiddleInitial).HasColumnName("middle_initial");
			this.Property(t => t.Ssn).HasColumnName("ssn");
			this.Property(t => t.BirthDate).HasColumnName("birth_date");
			this.Property(t => t.Gender).HasColumnName("gender");
			this.Property(t => t.Alias).HasColumnName("alias");
			this.Property(t => t.Comment).HasColumnName("comment");
			this.Property(t => t.InactivateReason).HasColumnName("inactivate_reason");
			this.Property(t => t.CreateDate).HasColumnName("create_date");
			this.Property(t => t.ChangeDate).HasColumnName("change_date");
			this.Property(t => t.ChangeUserId).HasColumnName("change_user_id");
			this.Property(t => t.CaseNumber).HasColumnName("case_number");
			this.Property(t => t.StartDate).HasColumnName("start_date");
			this.Property(t => t.EndDate).HasColumnName("end_date");
			this.Property(t => t.RiskLevel).HasColumnName("risk_level");
			this.Property(t => t.DefaultLanguageId).HasColumnName("default_language_id");
			this.Property(t => t.Height).HasColumnName("height");
			this.Property(t => t.Weight).HasColumnName("weight");
			this.Property(t => t.ClientTypeId).HasColumnName("client_type_id");
			this.Property(t => t.CountryCodeOfOrigin).HasColumnName("country_code_of_origin");
			this.Property(t => t.EducationLevelId).HasColumnName("EducationLevelId");
			this.Property(t => t.EnglishSpokenProficiency).HasColumnName("EnglishSpokenProficiency");
			this.Property(t => t.EnglishReadingProficiency).HasColumnName("EnglishReadingProficiency");
			this.Property(t => t.Race).HasColumnName("Race");
			this.Property(t => t.MaritalStatus).HasColumnName("MaritalStatus");
			this.Property(t => t.DistinguishingMarks).HasColumnName("DistinguishingMarks");
			this.Property(t => t.HairColor).HasColumnName("HairColor");
			this.Property(t => t.EyeColor).HasColumnName("EyeColor");
			this.Property(t => t.LicenseNumber).HasColumnName("LicenseNumber");
			this.Property(t => t.LicenseState).HasColumnName("LicenseState");
			this.Property(t => t.LicenseExpiration).HasColumnName("LicenseExpiration");
			this.Property(t => t.IsPregnant).HasColumnName("IsPregnant");
			this.Property(t => t.PregnancyConfirmed).HasColumnName("PregnancyConfirmed");
			this.Property(t => t.PregnancyDue).HasColumnName("PregnancyDue");
			this.Property(t => t.HasGangAffiliation).HasColumnName("HasGangAffiliation");
			this.Property(t => t.HasDisability).HasColumnName("HasDisability");
		}
	}
}