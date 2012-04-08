using System.Collections.Generic;
using System.Linq;
using System.Net;
using PI.WebGarten.Demos.FollowMyTv.Model;
using PI.WebGarten.Demos.FollowMyTv.View;
using PI.WebGarten.MethodBasedCommands;

namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    class UserController
    {
        private readonly IUserRepository _repo;
        public UserController()
        {
            _repo = UserRepositoryLocator.Instance;
        }

        [HttpCmd(HttpMethod.Get, "/users")]
        public HttpResponse Get()
        {
            return new HttpResponse(HttpStatusCode.OK, new UsersView(_repo.GetAll()));
        }

        [HttpCmd(HttpMethod.Post, "/users")]
        public HttpResponse Post( IEnumerable<KeyValuePair<string, string>> content )
        {
            var username = content.Where(p => p.Equals("username")).Select(p => p.Value).FirstOrDefault();
            var password = content.Where( p => p.Equals( "password" ) ).Select( p => p.Value ).FirstOrDefault();
            if( _repo.GetById(username) != null )
            {
                return new HttpResponse(HttpStatusCode.BadRequest);
            }
            var user = new User {Name = username, Password = password};
            _repo.Add(user);
            return new HttpResponse( HttpStatusCode.SeeOther ).WithHeader( "Location", ResolveUri.ForUsers() );
        }
    }
}
