using System.Collections.Generic;
using System.Linq;
using System.Net;
using PI.WebGarten.Demos.FollowMyTv.Model;
using PI.WebGarten.Demos.FollowMyTv.Repository;
using PI.WebGarten.Demos.FollowMyTv.View;
using PI.WebGarten.MethodBasedCommands;
using PI.WebGarten.Mvc;

namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    public class UserController : BaseController
    {
        private readonly IRepository<User, string> _repo;
        public UserController()
        {
            _repo = RepositoryLocator.Users;
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
            
            return new HttpResponse( HttpStatusCode.SeeOther ).WithHeader( "Location", ResolveUri.ForUsers() );
        }
    }
}
