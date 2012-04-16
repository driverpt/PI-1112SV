using System.Net;
using PI.WebGarten.Demos.FollowMyTv.Model;
using System;
using System.Text;
using PI.WebGarten.HttpContent.Html;

namespace PI.WebGarten.Demos.FollowMyTv.Filters
{
    public class AuthenticationFilter : BaseFilter
    {
        private const string URI_LOGIN = "/login";
        private const string URI_LOGOUT = "/logout";
        private const string COOKIE_AUTH_NAME = "PI_AUTH";

        public AuthenticationFilter(string name) : base(name) {}

        #region Implementation of IHttpFilter

        public override HttpResponse Process( RequestInfo requestInfo )
        {
            var ctx = requestInfo.Context;
            
            if ( ctx.Request.Url.AbsolutePath.Equals( URI_LOGOUT ) )
            {
                var logoutResp = new HttpResponse( HttpStatusCode.Found )
                    .WithHeader("Location", "/");
                Cookie logoutCookie = ctx.Request.Cookies[COOKIE_AUTH_NAME];
                if( logoutCookie != null )
                {
                    logoutResp.WithCookie( new Cookie( COOKIE_AUTH_NAME, "", "/" ) { Expired = true } );
                }
                return logoutResp;
            }

            if( ctx.Request.Url.AbsolutePath.Equals(URI_LOGIN) )
            {
                string auth = ctx.Request.Headers["Authorization"];
                if( auth == null )
                {
                    return UnauthorizedResponseWithAuth();
                }

                auth = auth.Replace( "Basic ", "" );
                string userPassDecoded = Encoding.UTF8.GetString( Convert.FromBase64String( auth ) );
                string[] userPasswd = userPassDecoded.Split( ':' );
                string username = userPasswd[0];
                string passwd = userPasswd[1];

                User user = RepositoryLocator.Users.GetById(username);
                // TODO : Create Method to compare Password
                if( user == null || !user.Password.Equals(passwd) )
                {
                    return UnauthorizedResponseWithAuth();
                }

                var authenticatedResponse = new HttpResponse( HttpStatusCode.Found )
                    .WithCookie(new Cookie(COOKIE_AUTH_NAME, username,"/") )
                    .WithHeader("Location", ctx.Request.UrlReferrer.AbsoluteUri);

                return authenticatedResponse;
            }
            
            Cookie cookie = ctx.Request.Cookies[COOKIE_AUTH_NAME];

            if( cookie != null )
            {
                User user = RepositoryLocator.Users.GetById(cookie.Value);
                if( user != null )
                {
                    requestInfo.User = user;
                    var response = _nextFilter.Process( requestInfo );
                }
                else
                {
                    var response = _nextFilter.Process( requestInfo );
                    response.WithCookie( new Cookie( COOKIE_AUTH_NAME, "", "/" ) { Expired = true } );
                }   
            }

            var nextFilterResp = _nextFilter.Process(requestInfo);

            if( nextFilterResp.Status == (int) HttpStatusCode.Unauthorized )
            {
                return new HttpResponse( HttpStatusCode.Found ).WithHeader( "Location", URI_LOGIN );
            }

            return _nextFilter.Process(requestInfo);
        }

        #endregion

        public HttpResponse UnauthorizedResponseWithAuth()
        {
            var unauthorizedResp = new HttpResponse(401, new TextContent("Not Authorized"));

            unauthorizedResp.WithHeader("WWW-Authenticate", "Basic realm=\"Private Area\"");
            return unauthorizedResp;
        }
    }
}