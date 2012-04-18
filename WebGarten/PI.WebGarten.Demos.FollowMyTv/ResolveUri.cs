using PI.WebGarten.Demos.FollowMyTv.Model;

namespace PI.WebGarten.Demos.FollowMyTv
{
    static class ResolveUri
    {
        public static string ForHome()
        {
            return "/";
        }

        public static string For(User user)
        {
            return string.Format("/user/{0}", user.Identity.Name/*user.Id*/);
        }

        public static string ForUsers()
        {
            return "/users";
        }

        public static string For(Proposal proposal)
        {
            return string.Format("/proposals/{0}", proposal.Id);
        }

        public static string ForShow(string id)
        {
            return "/shows/"+id;
        }

        public static string ForShows()
        {
            return "/shows";
        }
    }
}