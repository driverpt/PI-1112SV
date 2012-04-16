using PI.WebGarten.MethodBasedCommands;

namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    class ProposalController
    {
        [HttpCmd(HttpMethod.Get, "/proposals")]
        public HttpResponse Get()
        {
            return null;
        }

        [HttpCmd( HttpMethod.Get, "/proposals/{id}" )]
        public HttpResponse Get(int id)
        {
            return null;
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