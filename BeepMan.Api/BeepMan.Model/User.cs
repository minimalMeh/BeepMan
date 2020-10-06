using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeepMan.Model
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public string UserName { get; set; }

        [Required]
        public virtual ICollection<Product> Products { get; set; }
    }
}
