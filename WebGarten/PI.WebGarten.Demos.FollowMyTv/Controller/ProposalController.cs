using System.Collections.Generic;
using System.Net;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;
using PI.WebGarten.Demos.FollowMyTv.Domain.Service;
using PI.WebGarten.Demos.FollowMyTv.View;
using PI.WebGarten.MethodBasedCommands;
using PI.WebGarten.Mvc;

namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    public class ProposalController : BaseController
    {
        [HttpCmd(HttpMethod.Get, "/proposals")]
        public HttpResponse GetAllProposals()
        {
            var user = User.Identity.Name;

            IEnumerable<Proposal> proposals = ProposalService.GetProposalsByUser(user);

            return new HttpResponse(HttpStatusCode.OK, new ProposalView(proposals));
        }

        [HttpCmd( HttpMethod.Get, "/proposals/{id}" )]
        public HttpResponse GetProposal(int id)
        {
            Proposal proposal = ProposalService.GetProposalById(id);
            if ( proposal.User.Identity.Name.Equals(User) )
            {
                return new HttpResponse( HttpStatusCode.OK, new ProposalView( proposal ) );
            }
            return new HttpResponse( HttpStatusCode.Unauthorized );
        }

        [HttpCmd( HttpMethod.Get, "/proposals/new")]
        public HttpResponse GetNewProposalForm()
        {
            return new HttpResponse(HttpStatusCode.OK, new ProposalForm());
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