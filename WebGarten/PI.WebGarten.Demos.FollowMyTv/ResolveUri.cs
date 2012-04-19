using PI.WebGarten.Demos.FollowMyTv.Model;

namespace PI.WebGarten.Demos.FollowMyTv
{
    static class ResolveUri
    {
        public static string For(User user)
        {
            return string.Format("/user/{0}", user.Identity.Name);
        }

        public static string ForUsers()
        {
            return "/users";
        }

        public static string For(Proposal proposal)
        {
            return string.Format("/proposals/{0}", proposal.Id);
        }
    }
}