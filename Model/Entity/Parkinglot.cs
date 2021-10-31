namespace CoreApp.Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Parkinglot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ParkId { get; set; }

        public long ParkArea { get; set; }

        [StringLength(50)]
        public string ParkName { get; set; }

        [StringLength(11)]
        public string ParkPlace { get; set; }

        public long ParkPrice { get; set; }

        [StringLength(50)]
        public string ParkStatus { get; set; }

        public  ICollection<Car> Cars { get; set; }
    }
}
