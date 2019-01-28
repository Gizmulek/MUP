using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeetUp.Models;
using MeetUp.DAL;

namespace MeetUp.ViewModels
{
    public class ArchiwEvent
    {
        public List<Event> Events { get; set; }
    }
}