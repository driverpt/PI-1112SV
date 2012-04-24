using System;
using FollowMyTv.DomainLayer.Interfaces;

namespace FollowMyTv.DomainLayer
{
    public class Permission : IDomainModel<string>
    {
        public string Id
        {
            get { return Uri.ToLower(); }
            set { throw new InvalidOperationException("Setter Not Allowed"); }
        }

        public string Uri { get; private set; }
        public Role MinRole { get; private set; }
        
        public Permission(string uri, Role role)
        {
            Uri = uri;
            MinRole = role;
        }
    }
}