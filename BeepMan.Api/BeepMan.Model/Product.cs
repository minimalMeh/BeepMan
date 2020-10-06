using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeepMan.Model
{
    public class Product
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        public Uri Link { get; set; }

        [Required]
        public virtual User User { get; set; }

        public virtual ICollection<Image> Images { get; set; }

    }
}
