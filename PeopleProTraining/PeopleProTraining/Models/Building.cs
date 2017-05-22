using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace PeopleProTraining.Models
{
    public class Building
    {
        // Members
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 1)]
        public string Title { get; set; }
    }
}