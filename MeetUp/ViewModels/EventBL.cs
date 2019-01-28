using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeetUp.DAL;

namespace MeetUp.Models
{
    public class EventBL
    {
        public List<Event> GetEvents()
        {
            MeetUpContext db = new MeetUpContext();
            return db.Events.ToList();
        }


    }
}