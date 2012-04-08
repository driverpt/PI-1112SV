using PI.WebGarten.Demos.FollowMyTv.Controller;
using PI.WebGarten.Demos.FollowMyTv.Model;

namespace PI.WebGarten.Demos.FollowMyTv
{
    using System;
    using System.Security.Principal;
    using System.Text;

    using WebGarten;
    using HttpContent.Html;
    using Pipeline;

    public class AuthenticationFilter : IHttpFilter
    {
        private readonly string _name;

        private IHttpFilter _nextFilter;

        public AuthenticationFilter(string name)
        {
            _name = name;
        }

        #region Implementation of IHttpFilter

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public void SetNextFilter(IHttpFilter nextFilter)
        {
            _nextFilter = nextFilter;
        }

        public HttpResponse Process(RequestInfo requestInfo)
        {
            var ctx = requestInfo.Context;
            if (ctx.Request.Url.AbsolutePath.Contains("private"))
            {
                string auth = ctx.Request.Headers["Authorization"];
                if (auth == null)
                {
                    var resp = new HttpResponse(401, new TextContent("Not Authorized"));

                    resp.WithHeader("WWW-Authenticate", "Basic realm=\"Private Area\"");
                    return resp;

                }

                auth = auth.Replace("Basic ", "");
                string userPassDecoded = Encoding.UTF8.GetString(Convert.FromBase64String(auth));
                string []userPasswd = userPassDecoded.Split(':');
                string username = userPasswd[0];
                string passwd = userPasswd[1];

                if ( Authenticate( username, passwd ) )
                {
                    var userIdentify = new GenericIdentity(username);
                    requestInfo.User = new GenericPrincipal(userIdentify, null);
                }

                Console.WriteLine("Authentication: {0} - {1}", auth, userPassDecoded);
            }

            return _nextFilter.Process(requestInfo);
        }

        public bool Authenticate(string username, string password)
        {
            User user = UserRepositoryLocator.Instance.GetById( username );
            return user.Password == password;
        }

        #endregion
    }
}