using PI.WebGarten.Demos.FollowMyTv.Model;

namespace PI.WebGarten.Demos.FollowMyTv
{
    public class Permission
    {
        public string Uri { get; private set; }
        public Role MinRole { get; private set; }
        
        public Permission(string uri, Role role)
        {
            Uri = uri;
            MinRole = role;
        }
    }
}