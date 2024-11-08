namespace Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class VerificationCode
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int verificationId { get; set; }

        [StringLength(13)]
        public string mobileNumber { get; set; }

        public DateTime? creationDate { get; set; }

        public DateTime? expriation { get; set; }

        [StringLength(6)]
        public string code { get; set; }

        public int? verificationType { get; set; }
    }
}
