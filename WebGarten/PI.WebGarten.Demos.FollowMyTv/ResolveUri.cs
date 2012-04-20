using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;

namespace PI.WebGarten.Demos.FollowMyTv
{
    static class ResolveUri
    {
        public static string ForHome()
        {
            return "/";
        }

        public static string ForUsers()
        {
            return "/users";
        }

        public static string ForShows()
        {
            return "/shows";
        }

        public static string ForProposals()
        {
            return "/proposals";
        }

        public static string For(User user)
        {
            return string.Format("/user/{0}", user.Identity.Name);
        }

        public static string For(Proposal proposal)
        {
            return string.Format("/proposals/{0}", proposal.Id);
        }

        public static string ForNewProposal()
        {
            return "/proposals/new";
        }

        public static string ForSubmitEditProposal()
        {
            return "/proposals/edit";
        }

        public static string ForEditProposal(Proposal proposal)
        {
            return string.Format("/proposals/edit/{0}", proposal.Id);
        }

        public static string ForNewProposalFromExistingShow(Show show)
        {
            return string.Format("/proposals/new/{0}", show.Name);
        }

        public static string ForAcceptProposal( Proposal proposal )
        {
            return string.Format( "/proposals/accept/{0}", proposal.Id );
        }

        public static string ForRejectProposal( Proposal proposal )
        {
            return string.Format( "/proposals/cancel/{0}", proposal.Id );
        }

        public static string ForShow(Show show)
        {
            return string.Format("/shows/{0}", show.Name);
        }

        public static string ForSeason(Show show, Season season)
        {
            return string.Format("/shows/{0}/{1}", show.Name, season.Number);
        }

        public static string ForEpisode(Show show, Season season, Episode episode)
        {
            return string.Format("/shows/{0}/{1}/{2}", show, season.Number, episode.Number);
        }
    }
}