using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nettlesnook.Models.MessagesViewModels
{
    public class MessagesViewModel
    {
        public int ID { get; set; } //Primary key

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Message")]
        public string Body { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date and Time Sent")]
        public string TimeStamp { get; set; }
    }
}
