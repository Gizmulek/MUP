using MeetUp.DAL;
using MeetUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetUp.ViewModels
{
    public class Profil
    {
        public List<User> GetUser()
        {
            MeetUpContext baza = new MeetUpContext();
            List<User> lista = baza.Users.ToList();
            return lista;
        }

        public User ZnajdzUsera(int id)
        {
            User c = new User();
            MeetUpContext baza = new MeetUpContext();
            baza.Users.Attach(c);
            c = baza.Users.Find(id);
            return c;
        }
        public List<Event> GetUserEvent(User u)
        {
            MeetUpContext baza = new MeetUpContext();
            List<Event> lista = baza.Events.Where(x => x.User.userId == u.userId).ToList();
            return lista;
        }
    }
}