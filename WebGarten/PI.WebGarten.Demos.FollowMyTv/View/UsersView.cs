using System.Collections.Generic;
using System.Linq;
using PI.WebGarten.Demos.FollowMyTv.Model;
using PI.WebGarten.HttpContent.Html;

namespace PI.WebGarten.Demos.FollowMyTv.View
{
    class UsersView : HtmlDoc
    {
        public UsersView( IEnumerable<User> users ) :
            base( "Users",
            A(ResolveUri.ForHome(), "Home")
           , H1( Text( "User List" ) )
           , Ul( users.Select( user => Li( A( ResolveUri.ForUser( user ), user.Identity.Name/*user.Name*/) ) ).ToArray() )
           , H2( Text( "Create a New User" ) )
           , Form("post", "/users", Label("username", "Username"), InputText("username")
                                  , Label("password", "Password"), InputText("password", true)
                                  , Label("submit", "Submit" )   , InputSubmit("Submit")
            )
         )
        {}
    }
}