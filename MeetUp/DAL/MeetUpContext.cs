using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using System.Web.Configuration;

namespace MeetUp.DAL
{
    public class MeetUpContext : System.Data.Entity.DbContext
    {
        public MeetUpContext() : base("DefaultConnection")
        {

        }

        public DbSet<Models.Event> Events { get; set; }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Message> Messages { get; set; }
        public DbSet<Models.Newsletter> Newsletters { get; set; }
        public DbSet<Models.Stand> Stands { get; set; }

        public System.Data.Entity.DbSet<MeetUp.Models.AdminMessage> AdminMessages { get; set; }
    }
}