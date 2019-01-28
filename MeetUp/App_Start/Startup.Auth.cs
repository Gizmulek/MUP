using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using MeetUp.DAL;
namespace MeetUp
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //app.CreatePerOwinContext(MeetUpContext);
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            //app.UseCookieAuthentication(new CookieAuthenticatioOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    LoginPath = new PathString("/Account/Login"),
            //    Provider = new CookieAuthenticationProvider
            //    {
            //        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
            //            validateInterval: TimeSpan.FromMinutes(30),
            //            regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
            //    }
            //});

            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseGoogleAuthentication(
                 clientId: "130162737082-834b7nv9o45spr02e9m02281ica7f6rn.apps.googleusercontent.com",
                 clientSecret: "xrCaKEcSuzikX5BHqmH3V5yZ");
        }
    }
}