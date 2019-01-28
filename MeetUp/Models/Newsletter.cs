using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeetUp.Models
{
    public class Newsletter
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }

        [Display(Name = "Newsletter:")]
        public string content { get; set; }

        
        public int userID { get; set; }

        public virtual User User { get; set; }
    }
}