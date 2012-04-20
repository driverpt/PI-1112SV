using System.Collections.Generic;
using System.Linq;
using System.Net;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;
using PI.WebGarten.MethodBasedCommands;
using PI.WebGarten.Mvc;

namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    public class UserController : BaseController
    {
        [HttpCmd(HttpMethod.Get, "/users")]
        public HttpResponse Get()
        {
            User user = new User("dummy", "dummy", null);
            //return new HttpResponse(HttpStatusCode.OK, new UsersView(user));
            return new HttpResponse(HttpStatusCode.NotFound);
        }

        [HttpCmd(HttpMethod.Post, "/users")]
        public HttpResponse Post( IEnumerable<KeyValuePair<string, string>> content )
        {
            var username = content.Where(p => p.Equals("username")).Select(p => p.Value).FirstOrDefault();
            var password = content.Where(p => p.Equals( "password" ) ).Select( p => p.Value ).FirstOrDefault();
            User user = new User(username, password, null);
            
            //return new HttpResponse( HttpStatusCode.SeeOther ).WithHeader( "Location", ResolveUri.ForUsers() );
            return new HttpResponse( HttpStatusCode.NotFound );
        }
    }
}
