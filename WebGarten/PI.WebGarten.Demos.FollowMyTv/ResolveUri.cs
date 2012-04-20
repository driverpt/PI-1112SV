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

        public static string ForNewProposal()
        {
            return "/proposals";
        }

        public static string ForHome()
        {
            throw new System.NotImplementedException();
        }

        public static string ForShow(string name)
        {
            throw new System.NotImplementedException();
        }

        public static string ForShows()
        {
            throw new System.NotImplementedException();
        }
    }
}