using System;
using System.Collections.Generic;
using System.Linq;
using FollowMyTv.DomainLayer.Repository;
using Microsoft.Practices.Unity;

namespace FollowMyTv.DomainLayer.Service
{
    public class ProposalService
    {
        private readonly IRepository<Proposal, int> Repo;

        [InjectionConstructor]
        public ProposalService( [Dependency] IRepository<Proposal, int> repository)
        {
            Repo = repository;
        }

        public Proposal GetProposalById(int id)
        {
            Proposal proposal = Repo.GetById(id);
            if ( proposal == null )
            {
                throw new ArgumentException( "There is no such proposal" );
            }
            return proposal;
        }

        public IEnumerable<Proposal> GetProposalsByUser(string username)
        {
            return Repo.GetAll().Where(proposal => proposal.User.Identity.Name == username);
        }

        public IEnumerable<Proposal> GetProposalsByShow( string showName )
        {
            return Repo.GetAll().Where(proposal => proposal.Show.Name == showName);
        }

        public IEnumerable<Proposal> GetAllProposals()
        {
            return Repo.GetAll();
        }

        public Proposal AddProposal( Show show, User user )
        {
            Proposal newProposal = new Proposal { Show = show, User = user };
            Repo.Add(newProposal);
            return newProposal;
        }

        public void AcceptProposal( int idProposal )
        {
            Proposal proposal = GetProposalById(idProposal);
            SetProposalStatus( proposal, ProposalStatus.Accepted );
        }

        public void RejectProposal( int idProposal )
        {
            Proposal proposal = GetProposalById( idProposal );
            SetProposalStatus( proposal, ProposalStatus.Rejected );
        }

        private void SetProposalStatus( Proposal proposal, ProposalStatus status )
        {
            if( proposal.Status != ProposalStatus.Created )
            {
                throw new InvalidOperationException();
            }
            proposal.Status = status;
        }
    }
}
