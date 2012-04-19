using System.Collections.Generic;
using System.Linq;
using System.Net;
using PI.WebGarten.Demos.FollowMyTv.Model;
using PI.WebGarten.Demos.FollowMyTv.Repository;
using PI.WebGarten.Demos.FollowMyTv.View;
using PI.WebGarten.MethodBasedCommands;
using PI.WebGarten.Mvc;

namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    public class ProposalController : BaseController
    {
        private IRepository<Proposal, int> Repo = RepositoryLocator.Proposals;

        [HttpCmd(HttpMethod.Get, "/proposals")]
        public HttpResponse GetAllProposals()
        {
            var user = User.Identity.Name;
            IEnumerable<Proposal> proposals = RepositoryLocator.Proposals.GetAll().Where( nome => nome.User.Equals(user) );

            return new HttpResponse(HttpStatusCode.OK, new ProposalView(proposals));
        }

        [HttpCmd( HttpMethod.Get, "/proposals/{id}" )]
        public HttpResponse GetProposal(int id)
        {
            string username = User.Identity.Name;
            Proposal proposal = Repo.GetById(id);
            if( !proposal.User.Equals(User) )
            {
                return new HttpResponse(HttpStatusCode.Unauthorized);
            }

            return new HttpResponse(HttpStatusCode.OK, new ProposalView(proposal));
        }

        [HttpCmd( HttpMethod.Get, "/proposals/new")]
        public HttpResponse GetNewProposalForm()
        {
            return null;
        }

        [HttpCmd( HttpMethod.Post, "/proposals/new" )]
        public HttpResponse NewProposal()
        {
            return null;
        }

        [HttpCmd( HttpMethod.Post, "/proposals/accept/{id}")]
        public HttpResponse AcceptProposal( int id )
        {
            return null;
        }

        [HttpCmd( HttpMethod.Post, "/proposals/cancel/{id}" )]
        public HttpResponse CancelProposal( int id )
        {
            return null;
        }
    }
}