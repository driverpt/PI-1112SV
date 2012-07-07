using System;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FollowMyTv.DomainLayer;
using FollowMyTv.DomainLayer.Repository;

namespace FollowMyTv.WebApp
{
    public class FollowMyTvAuthenticationModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += ContextOnAuthenticateRequest;
            context.EndRequest += ContextOnEndRequest;
        }

        private void ContextOnAuthenticateRequest(object sender, EventArgs eventArgs)
        {
            HttpApplication app = sender as HttpApplication;
            HttpContext ctx = app.Context;
            var config = PIAuthenticationConfiguration.Current;

            IUserRepository userRepo = DependencyResolver.Current.GetService<IUserRepository>();

            HttpCookie authCookie = ctx.Request.Cookies[config.CookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                if( !ticket.Expired )
                {
                    string userName = ticket.Name;
                    User user = userRepo.GetByUsername(userName);
                    if( user != null )
                    {
                        ctx.User = user;
                    }
                }
            }

            // If we got here, its because we don't recognize this Session or Session is invalid
            //ctx.User = new GenericPrincipal(new GenericIdentity(config.AnonymousUserName), Enumerable.Empty<string>().ToArray());
        }

        private void ContextOnEndRequest(object sender, EventArgs eventArgs)
        {
            HttpContext ctx = HttpContext.Current;
            var config = PIAuthenticationConfiguration.Current;

            if ( ctx.Response.StatusCode == (int) HttpStatusCode.Unauthorized )
            {
                if ( GetAuthCookie(ctx.Request) == null )
                {
                    string redirectionUrl = PIAuthenticationConfiguration.Current.LoginUrl + "?returnUrl=" + ctx.Request.Url.AbsolutePath;
                    ctx.Response.Redirect(redirectionUrl, true);
                }
            }
        }


        public void Dispose()
        {}

        private HttpCookie GetAuthCookie(HttpRequest request)
        {
            return request.Cookies[PIAuthenticationConfiguration.Current.CookieName];
        }
    }
}