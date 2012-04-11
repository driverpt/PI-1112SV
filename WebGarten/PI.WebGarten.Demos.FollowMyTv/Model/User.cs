using System.Security.Principal;

namespace PI.WebGarten.Demos.FollowMyTv.Model
{
    public class User : GenericPrincipal
    {
        public User(string username, string password, Role role) : base(new GenericIdentity(username), Role.GetContainedRoles(role) )
        {
            Password = password;
        }

        public string Password { get; set; }
    }
}