using System;
using System.Collections.Generic;
using System.Text;

namespace BeepMan.Model
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public virtual Product SelectedProduct { get; set; }
    }
}
