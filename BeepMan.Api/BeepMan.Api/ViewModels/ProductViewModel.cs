using BeepMan.Model;
using System;
using System.Collections.Generic;

namespace BeepMan.Api.ViewModels
{
    public class ProductViewModel
    {
        public Guid OwnerId { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public Uri Link { get; set; }

        public List<Image> Images { get; set; }
    }
}
