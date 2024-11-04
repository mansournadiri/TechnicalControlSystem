namespace Domain.Entity
{
    public class Party
    {
        public Guid Guid { get; set; }

        public long PartyId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? FullName { get; set; }

        public string? Tel { get; set; }

        public int? MaritalStatus { get; set; }

        public int? EducationDegree { get; set; }

        public DateTime? MarriageDate { get; set; }

        public string? Alias { get; set; }

        public string? NationalId { get; set; }

        public int? Gender { get; set; }

        public string? Nationality { get; set; }

        public string? Mobile { get; set; }

        public string? Email { get; set; }

        public string? FatherName { get; set; }

        public long? BirthPlaceRef { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? IssuanceDate { get; set; }

        public long? IssuancePlaceRef { get; set; }

        public string? CompanyCode { get; set; }

        public string? Abbreviation { get; set; }

        public string? EconomicCode { get; set; }

        public int? CompanyType { get; set; }

        public string? ActivityType { get; set; }

        public string? Website { get; set; }

        public string? CompanyName { get; set; }

        public int Type { get; set; }

        public byte[] Version { get; set; } = null!;

        public string? FirstNameEn { get; set; }

        public string? LastNameEn { get; set; }

        public string? FullNameEn { get; set; }

        public string? CompanyNameEn { get; set; }

        public long? Creator { get; set; }

        public DateTime? CreationDate { get; set; }

        public long? LastModifier { get; set; }

        public DateTime? LastModificationDate { get; set; }
    }
}
