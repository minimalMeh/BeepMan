using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;


namespace BeepMan.Model
{
    public class User : IdentityUser<Guid>
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}
