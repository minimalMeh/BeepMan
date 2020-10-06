using System;
using System.ComponentModel.DataAnnotations;

namespace BeepMan.Model
{
    public class Customer : IEquatable<Customer>
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public virtual Product SelectedProduct { get; set; }

        public bool Equals(Customer other)
        {
            return other.Id == this.Id &&
                other.Name == this.Name &&
                other.Phone == this.Phone &&
                other.SelectedProduct == this.SelectedProduct;
        }
    }
}
