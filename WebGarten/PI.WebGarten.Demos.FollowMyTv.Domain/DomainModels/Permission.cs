using System;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels.Interfaces;

namespace PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels
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