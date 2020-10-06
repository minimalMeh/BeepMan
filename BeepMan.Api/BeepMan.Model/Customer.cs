using System;
using System.ComponentModel.DataAnnotations;

namespace BeepMan.Model
{
    public class Customer
    {
        [Required]
        public Guid Id { get; set; }

        [Required]

        public string Name { get; set; }

        [Required]

        public string Phone { get; set; }

        [Required]

        public virtual Product SelectedProduct { get; set; }
    }
}
