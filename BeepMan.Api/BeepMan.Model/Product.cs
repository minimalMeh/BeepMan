using System;
using System.Collections.Generic;
using System.Text;

namespace BeepMan.Model
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public Uri Link { get; set; }

    }
}
