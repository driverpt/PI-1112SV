using System;
using System.Collections.Generic;
using System.Linq;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;

namespace PI.WebGarten.Demos.FollowMyTv.Domain.Service
{
    public static class ProposalService
    {
        public static Proposal GetProposalById(int id)
        {
            Proposal proposal = RepositoryLocator.Proposals.GetById(id);
            if ( proposal == null )
            {
                throw new ArgumentException( "There is no such proposal" );
            }
            return proposal;
        }

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

        public static Proposal AddProposal( Show show, User user )
        {
            Proposal newProposal = new Proposal { Show = show, User = user };
            RepositoryLocator.Proposals.Add(newProposal);
            return newProposal;
        }

        public static void AcceptProposal( int idProposal )
        {
            Proposal proposal = GetProposalById(idProposal);
            SetProposalStatus( proposal, ProposalStatus.Accepted );
        }

        public static void RejectProposal( int idProposal )
        {
            Proposal proposal = GetProposalById( idProposal );
            SetProposalStatus( proposal, ProposalStatus.Rejected );
        }

        private static void SetProposalStatus( Proposal proposal, ProposalStatus status )
        {
            if( proposal.Status != ProposalStatus.Created )
            {
                throw new InvalidOperationException();
            }
            proposal.Status = status;
        }
    }
}
