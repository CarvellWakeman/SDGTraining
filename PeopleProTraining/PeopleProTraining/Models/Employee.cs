using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace PeopleProTraining.Models
{
    public class Employee
    {
        //[Table("tblEmployee")] // Used for making a relationship between this object and the table's entities (if the name of the table differs from the context)
        
        
        // Members
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "Birthday"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        // Foreign key to department
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
    }

}