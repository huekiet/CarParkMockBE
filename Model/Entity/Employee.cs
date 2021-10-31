namespace CoreApp.Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        [Required]
        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(50)]
        public string EmployeeAddress { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EmployeeBirthdate { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(10)]
        public string EmployeePhone { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(1)]
        public string Sex { get; set; }
    }
}
