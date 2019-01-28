using MeetUp.DAL;
using MeetUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetUp.ViewModels
{
    public class Login
    {
        public List<User> GetUser()
        {
            MeetUpContext baza = new MeetUpContext();
            List<User> lista = baza.Users.ToList();
            return lista;
        }
    }
}