using System.Collections.Generic;
using System.Linq;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;

namespace PI.WebGarten.Demos.FollowMyTv.Domain.Service
{
    public static class ProposalService
    {
        public static IEnumerable<Proposal> GetProposalsByUser(string username)
        {
            return RepositoryLocator.Proposals.GetAll().Where(proposal => proposal.User.Identity.Name == username);
        }

        public static IEnumerable<Proposal> GetProposalsByShow( string showName )
        {
            return RepositoryLocator.Proposals.GetAll().Where(proposal => proposal.Show.Name == showName);
        }

        public static IEnumerable<Proposal> GetAllProposals()
        {
            return RepositoryLocator.Proposals.GetAll();
        }

        public static void AddProposal( Show show, User user )
        {
            Proposal newProposal = new Proposal { Show = show, User = user };
            RepositoryLocator.Proposals.Add(newProposal);
        }
    }
}
