using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nettlesnook.Models
{
    public class Blog
    {
        public int ID { get; set; } //Primary key

        [Display(Name="Posted: ")]  //Sets HTML rendered name
        [DataType(DataType.DateTime)]   //Sets HTML rendered format
        public DateTime DateTime { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public bool Archive { get; set; }

        public ICollection<BlogImages> Images { get; set; } //Ties one Blog.ID to many Images.ID
    }
}
