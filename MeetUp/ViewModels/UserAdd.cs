using MeetUp.DAL;
using MeetUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetUp.ViewModels
{
    public class UserAdd
    {
        public List<User> GetUser()
        {
            MeetUpContext baza = new MeetUpContext();
            List<User> lista = baza.Users.ToList();
            return lista;
        }

        public void AddUser(User u)
        {
            MeetUpContext baza = new MeetUpContext();
            baza.Users.Add(u);
            baza.Configuration.ValidateOnSaveEnabled = false;
            baza.SaveChanges();
        }

    }
}