using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nettlesnook.Models
{
    public class Images
    {
        public int ID { get; set; } //Primary Key

        public string FileName { get; set; }
        public string AltText { get; set; }

        ICollection<BlogImages> BlogImages { get; set; }
    }
}
