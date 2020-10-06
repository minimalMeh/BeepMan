using System;
using System.Collections.Generic;
using System.Text;

namespace BeepMan.Model
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
