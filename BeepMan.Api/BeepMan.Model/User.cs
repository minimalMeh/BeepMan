using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeepMan.Model
{
    public class User : IdentityUser
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}
