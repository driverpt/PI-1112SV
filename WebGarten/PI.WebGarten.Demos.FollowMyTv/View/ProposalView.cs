using System.Collections.Generic;
using System.Linq;
using PI.WebGarten.Demos.FollowMyTv.Model;
using PI.WebGarten.HttpContent.Html;

namespace PI.WebGarten.Demos.FollowMyTv.View
{
    public class ProposalView : HtmlDoc
    {
        protected const string TITLE = "Proposals";

        public ProposalView(IEnumerable<Proposal> proposals) :
            base( TITLE,
                  H2(Text("Proposals List"))
                  , Ul(proposals.Select(proposal => Li(A(ResolveUri.For((Proposal) proposal), proposal.Show.Name))).ToArray()))
        {}

        public ProposalView(Proposal proposal) : 
            base( TITLE,
                  H2(Text(string.Format("Proposal #{0}", proposal.Id)))
                , H1(Text(string.Format("Show: {0}", proposal.Show.Name)))
                , Ul( 
                     Li( Text(string.Format("Description: {0}", proposal.Show.Description)))
                  ,  Li( Text(string.Format("{0} Seasons", proposal.Show.Seasons)) )
                )
            )
        {}
    }
}