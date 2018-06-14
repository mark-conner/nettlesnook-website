using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nettlesnook.Models
{
    public class BlogImages
    {
        public int ID { get; set; } //Primary Key
        
        public int BlogID { get; set; } //Set foriegn key to Blog.ID
        public Blog Blog { get; set; }  //Ties one Blog.ID to one BlogImages.ID

        public string ImageFileName { get; set; }   //File name for src attribute in img tag
        public string ImageDesc { get; set; }   //Description for alt attribute in img tag
    }
}
