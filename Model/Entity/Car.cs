namespace CoreApp.Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Car
    {
        [Key]
        [StringLength(50)]
        public string LicensePlate { get; set; }
        [StringLength(11)]
        public string CarColor { get; set; }

        [StringLength(50)]
        public string CarType { get; set; }

        [Required]
        [StringLength(50)]
        public string Company { get; set; }

        public long ParkId { get; set; }
        [ForeignKey("ParkId")]
        public Parkinglot Parkinglot { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
