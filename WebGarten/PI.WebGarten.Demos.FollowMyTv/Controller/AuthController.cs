using System;
using System.Net;
using System.Text;
using PI.WebGarten.Demos.FollowMyTv.Domain;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;
using PI.WebGarten.HttpContent.Html;
using PI.WebGarten.MethodBasedCommands;
using PI.WebGarten.Mvc;

namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    public class AuthController : BaseController
    {
        private const string COOKIE_AUTH_NAME = "PI_AUTH";

        [HttpCmd(HttpMethod.Get, "/login")]
        public HttpResponse Login()
        {
            var userRepo = UserRepositoryLocator.Instance;
            HttpResponse response = null;

            var authentication = Context.Request.Headers["Authorization"];
            //se não existir header, realizar basic authentication
            if(authentication == null)
            {
                response = new HttpResponse(HttpStatusCode.Unauthorized, new TextContent("Not Authorized"))
                                .WithHeader("WWW-Authenticate", "Basic realm=\"Private Area\"");
            }else
            {
                authentication = authentication.Replace("Basic ", "");

                string userPassDecoded = Encoding.UTF8.GetString(Convert.FromBase64String(authentication));
                string[] userPasswd = userPassDecoded.Split(':');
                string username = userPasswd[0];
                string passwd = userPasswd[1];

                User user = null;
                if (userRepo.TryAuthenticate(username, passwd, out user))
                {
                    response = new HttpResponse(HttpStatusCode.Found).WithHeader("Location", "/")
                                    .WithCookie(new Cookie(COOKIE_AUTH_NAME, user.Identity.Name, "/"));
                }
            }

            return response;
        }

        [HttpCmd( HttpMethod.Get, "/logout" )]
        public HttpResponse Logout()
        {
            var response = new HttpResponse(HttpStatusCode.Found).WithHeader("Location", "/");
            Cookie cookie = Context.Request.Cookies[COOKIE_AUTH_NAME];
            
            if(cookie != null)
            {
                cookie.Expired = true;
                response.WithCookie(cookie);
            }

            return response;
        }
    }
}