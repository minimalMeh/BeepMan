using System;
using System.ComponentModel.DataAnnotations;

namespace BeepMan.Model
{
    public class Image
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string OriginalFileName { get; set; }

        [Required]
        public string FileExtention { get; set; }

        [Required]
        public virtual Product Product { get; set; }
    }
}
