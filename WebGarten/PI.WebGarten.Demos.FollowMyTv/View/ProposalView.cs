using System.Collections.Generic;
using System.Linq;
using PI.WebGarten.Demos.FollowMyTv.Model;
using PI.WebGarten.HttpContent.Html;

namespace PI.WebGarten.Demos.FollowMyTv.View
{
    public class ProposalView : HtmlDoc
    {
        public ProposalView(IEnumerable<Proposal> proposals) :
            base( "Proposals",
                  H1(Text("Proposals List"))
                  , Ul(proposals.Select(proposal => Li(A(ResolveUri.For((Proposal) proposal), proposal.Show.Name))).ToArray()))
        {}
    }
}