using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeetUp.Models
{
    public class Stand
    {
        [Key]
        
        public int Id { get; set; }

        [Display(Name = "Typ stanowiska:")]
        public double stand_type { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}