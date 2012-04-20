using System;
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
        // Martelada!!!!!
        protected User GetUser()
        {
            return User as User;
        }

        [HttpCmd(HttpMethod.Get, "/proposals")]
        public HttpResponse GetAllProposals()
        {
            IEnumerable<Proposal> proposals;
            if( User.IsInRole(Role.Administrator.ToString()) )
            {
                proposals = ProposalService.GetAllProposals();
            }
            else
            {
                var user = User.Identity.Name;
                proposals = ProposalService.GetProposalsByUser( user );                
            }

            return new HttpResponse(HttpStatusCode.OK, new ProposalView(proposals));
        }

        [HttpCmd( HttpMethod.Get, "/proposals/{id}" )]
        public HttpResponse GetProposal(int id)
        {
            Proposal proposal = ProposalService.GetProposalById(id);
            if ( proposal.User.Identity.Name.Equals(User.Identity.Name) || User.IsInRole(Role.Administrator.ToString()) )
            {
                return new HttpResponse( HttpStatusCode.OK, new ProposalView( proposal, GetUser() ) );
            }
            return new HttpResponse( HttpStatusCode.Forbidden );
        }

        [HttpCmd( HttpMethod.Get, "/proposals/new")]
        public HttpResponse GetNewProposalForm()
        {
            return new HttpResponse(HttpStatusCode.OK, new ProposalForm());
        }

        [HttpCmd( HttpMethod.Get, "/proposals/new/{showname}" )]
        public HttpResponse GetNewProposalFormFromExistingShow(string showname)
        {
            Show show = ShowService.GetShowByName(showname);
            return new HttpResponse( HttpStatusCode.OK, new ProposalForm(show) );
        }

        [HttpCmd( HttpMethod.Post, "/proposals/new" )]
        public HttpResponse NewProposal( IEnumerable<KeyValuePair<string, string>> content )
        {
            Show show = new Show
                            {
                                Name = content.GetValue("show_name")
                              , Description = content.GetValue("show_description")
                            };
            Proposal proposal = ProposalService.AddProposal( show , GetUser() );
            return new HttpResponse(HttpStatusCode.Found).WithHeader("Location", ResolveUri.For(proposal));
        }

        [HttpCmd( HttpMethod.Get, "/proposals/edit/{id}")]
        public HttpResponse EditProposal( int id )
        {
            Proposal proposal = ProposalService.GetProposalById(id);
            return new HttpResponse(HttpStatusCode.OK, new ProposalForm(proposal));
        }

        [HttpCmd( HttpMethod.Post, "/proposals/edit" )]
        public HttpResponse EditProposalSubmit( IEnumerable<KeyValuePair<string, string>> content )
        {
            int proposalId = Convert.ToInt32(content.GetValue("proposal_id"));

            Proposal proposal = ProposalService.GetProposalById( proposalId );
            proposal.Show.Name = content.GetValue("show_name");
            proposal.Show.Description = content.GetValue("show_description");

            return new HttpResponse( HttpStatusCode.Found ).WithHeader("Location", ResolveUri.For(proposal));
        }

        [HttpCmd( HttpMethod.Post, "/proposals/accept/{id}")]
        public HttpResponse AcceptProposal( int id )
        {
            if( !User.IsInRole(Role.Administrator.ToString()) )
            {
                return new HttpResponse(HttpStatusCode.Forbidden);
            }
            ProposalService.AcceptProposal(id);
            return new HttpResponse(HttpStatusCode.Found).WithHeader("Location", ResolveUri.ForProposals());
        }

        [HttpCmd( HttpMethod.Post, "/proposals/cancel/{id}" )]
        public HttpResponse RejectProposal( int id )
        {
            Proposal proposal = ProposalService.GetProposalById(id);
            if ( proposal.User.Identity.Name.Equals(proposal.User.Identity.Name) || User.IsInRole( Role.Administrator.ToString() ))
            {
                ProposalService.RejectProposal( id );
                return new HttpResponse( HttpStatusCode.Found ).WithHeader( "Location", ResolveUri.ForProposals() );
            }
            return new HttpResponse(HttpStatusCode.Forbidden);
        }
    }
}