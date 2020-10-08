using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeepMan.Model
{
    public class User : IdentityUser<Guid>
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}
