namespace Domain.Entity
{
    public class Lookup
    {
        public long LookupId { get; set; }

        public string? Type { get; set; }

        public int? Code { get; set; }

        public string? Value { get; set; }

        public string? CustomClass { get; set; }

        public int? DisplayOrder { get; set; }

        public DateTime? DisplayOrderDateTime { get; set; }

        public string? ExtraText { get; set; }

        public bool? DeclineAccess { get; set; }

        public bool? PermitNeed { get; set; }

        public bool? FaildProcessing { get; set; }

        public bool? CompleteProcessing { get; set; }

        public bool? OnProcessing { get; set; }

        public bool? CanEdit { get; set; }

        public bool? CanDelete { get; set; }

        public bool? Disable { get; set; }

        public byte[]? Version { get; set; }
    }
}
