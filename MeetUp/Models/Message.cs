using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeetUp.Models
{
    public class Message

    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }

        [Display(Name = "Tekst")]
        public string text { get; set; }


        public int userID { get; set; }

        public virtual User User { get; set; }

    }
}