namespace CoreApp.Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BookingOffice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OfficeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndContractDeadline { get; set; }

        [StringLength(50)]
        public string OfficeName { get; set; }

        [StringLength(11)]
        public string OfficePhone { get; set; }

        [StringLength(50)]
        public string OfficePlace { get; set; }

        public long? OfficePrice { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartContractDeadline { get; set; }

        public long TripId { get; set; }
        public Trip Trip { get; set; }
    }
}
