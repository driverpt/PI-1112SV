using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;

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

        public static string ForShows()
        {
            return "/shows";
        }
        public static string ForNewProposal()
        {
            return "/proposals";
        }

        public static string ForShow(string show)
        {
            return string.Format("/shows/{0}", show);
        }

        public static string ForHome()
        {
            return "/";
        }

        public static string ForShow(string name)
        {
            return string.Format("/shows/{0}", name);
        }

        public static string ForShows()
        {
            return "/shows";
        }

        public static string ForSeason(string show, string season)
        {
            return string.Format("/shows/{0}/{1}", show, season);
        }

        public static string ForEpisode(string show, string season, string episode)
        {
            return string.Format("/shows/{0}/{1}/{2}", show, season, episode);
        }
    }
}