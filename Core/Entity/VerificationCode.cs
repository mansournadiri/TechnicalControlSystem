namespace Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class VerificationCode
    {
        public int verificationId { get; set; }

        public string mobileNumber { get; set; }

        public DateTime? creationDate { get; set; }

        public DateTime? expriation { get; set; }

        public string code { get; set; }

        public int? verificationType { get; set; }
    }
}
