using System;
using System.Security.Principal;
using FollowMyTv.DomainLayer.Interfaces;

namespace FollowMyTv.DomainLayer
{
    public class User : GenericPrincipal, IDomainModel<string>
    {
        public User(string username, string password, Role role) : base(new GenericIdentity(username), Role.GetContainedRoles(role) )
        {
            Password = password;
            Role = role;
        }

        public Role Role { get; private set; }

        public string Password { get; set; }

        public string Id
        {
            get { return Identity.Name; }
            set { throw new InvalidOperationException("Setter Not Allowed"); }
        }
        
    }
}