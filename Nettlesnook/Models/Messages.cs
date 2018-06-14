using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nettlesnook.Models
{
    public class Messages
    {
        public int ID { get; set; }

        [Display(Name="Date")] //Set HTML rendered text
        [DataType(DataType.DateTime)]   //Sets HTML rendered format
        public DateTime TimeStamp { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name="Message")]   //Set HTML rendered text
        public string Body { get; set; }
    }
}
