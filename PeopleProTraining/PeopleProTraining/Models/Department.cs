using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace PeopleProTraining.Models
{
    public class Department
    {
        // Members
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 1), Required]
        public string Title { get; set; }

        // Foreign key to building
        [ForeignKey("Building"), Required]
        public int BuildingID { get; set; }

        public virtual Building Building { get; set; }
    }

}