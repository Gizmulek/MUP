using Facebook;
using MeetUp.DAL;
using MeetUp.Models;
using MeetUp.ViewModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MeetUp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //DAL.MeetUpContext db = new DAL.MeetUpContext();
            return View();
        }
        public ActionResult StworzEvent()
        {    
                return View();
        }

        [HttpPost]
        public ActionResult StworzEvent(Event eve)
        {
            if (!ModelState.IsValid)
            {
                return View("StworzEvent", eve);
                
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        public ActionResult Profil()
        {
            int id;
            try
            {
                id = Int32.Parse(Session["userId"].ToString());
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            //id = Int32.Parse(Session["userId"].ToString());
            dynamic mymodel = new ExpandoObject();
            Profil ktos = new Profil();
            User c = ktos.ZnajdzUsera(id);
            mymodel.User = c;
            mymodel.Events = ktos.GetUserEvent(c);
            return View(mymodel);
        }

        [HttpGet]
        public ActionResult Rejestracja(int id = 0)
        {
            User ktos = new User();
            return View(ktos);
        }

        [HttpPost]
        public ActionResult Rejestracja(User ktos)
        {
            User ktos1 = new User();
            ktos1 = ktos;
            UserAdd user = new UserAdd();
            List<User> lista = user.GetUser();
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                if (lista.Any(u => u.login == ktos.login))
                {
                    ModelState.AddModelError("login", "Ten login jest już zajęty!");
                    return View("Rejestracja", ktos);
                }
                else if (ktos.password.Count() < 8)
                {
                    ModelState.AddModelError("password", "Hasło musi mieć co najmniej 8 znaków!");
                    return View("Rejestracja", ktos);
                }
                else
                {
                    user.AddUser(ktos1);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Logowanie(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Logowanie(User user, string ReturnUrl)
        {
            MeetUpContext baza = new MeetUpContext();
            var daneUsera = baza.Users.Where(k => k.login == user.login && k.password == user.password).FirstOrDefault();
            UserAdd ktos = new UserAdd();
            List<User> lista = ktos.GetUser();
            //if (daneUsera == null)
            //{
            //    ModelState.AddModelError("login", "Błędny login lub hasło");
            //    return View("Logowanie", user);
            //}
            if (!lista.Any(k => k.login == user.login && k.password == user.password))
            {
                ModelState.AddModelError("password", "Błędny login lub hasło");
                return View("Logowanie", user);
            }
            else
            {
                Session["userId"] = daneUsera.userId;
                Session["login"] = daneUsera.login;
                FormsAuthentication.SetAuthCookie(user.login, false);

                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

        }

        public ActionResult Wyloguj()
        {
            int Id = (int)Session["userId"];
            Session.Abandon();
            return RedirectToAction("Logowanie", "Home");
        }
        //logowanie fb
        private Uri RediredtUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        
        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = "1161864983966121",
                client_secret = "d5eea1154e79fb70a17bd8525708a5e1",
                redirect_uri = RediredtUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });
            return Redirect(loginUrl.AbsoluteUri);
        }
        
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = "1161864983966121",
                client_secret = "d5eea1154e79fb70a17bd8525708a5e1",
                redirect_uri = RediredtUri.AbsoluteUri,
                code
            });
            var accessToken = result.access_token;
            
            fb.AccessToken = accessToken;
            dynamic me = fb.Get("me?fields=link,first_name,last_name,email,picture,age_range");
            string email = me.email;
            User user = new User()
            {
                age = 20,
                name = me.first_name,
                surname = me.last_name,
                login = me.id,
                password = "5QgboDCEJZDSApBqgZ5V",
                confirmedpassword = "5QgboDCEJZDSApBqgZ5VF"
            };

            UserAdd users = new UserAdd();
            List<User> lista = users.GetUser();
            //if(!lista.Any(u => u.login == user.login))
                Rejestracja(user);
            Logowanie(user, "/home/index");

            FormsAuthentication.SetAuthCookie(email, false);
            return RedirectToAction("Index", "Home");
        }
    
    }
}