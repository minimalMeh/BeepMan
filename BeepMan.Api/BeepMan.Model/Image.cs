using System;
using System.Collections.Generic;
using System.Text;

namespace BeepMan.Model
{
    public class Image
    {
        public Guid Id { get; set; }

        public string OriginalFileName { get; set; }
        
        public string FileExtention { get; set; }

    }
}
