using System.Collections.Generic;
using System.Linq;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;
using PI.WebGarten.HttpContent.Html;

namespace PI.WebGarten.Demos.FollowMyTv.View
{
    public class ProposalView : MasterPageView
    {
        protected const string TITLE = "Proposals";

        public ProposalView(IEnumerable<Proposal> proposals) :
            base( TITLE,
                    H2(Text("Proposals List"))
                  , Ul(proposals.Select(proposal => Li(A(ResolveUri.For(proposal), string.Format("{0} ({1})",proposal.Show.Name, proposal.Status.ToString())))).ToArray())
                  , A(ResolveUri.ForNewProposal(), "Create New")
            )
        {}

        public ProposalView(Proposal proposal, User user) :
            base( TITLE,
                  H2(Text(string.Format("Proposal #{0}", proposal.Id)))
                , H1(Text(string.Format("Created By: {0}", proposal.User.Identity.Name ) ) )  
                , H1(Text(string.Format("Status: {0}", proposal.Status.ToString())))  
                , H1(Text(string.Format("Show: {0}", proposal.Show.Name)))
                , H1(Text(string.Format("Description: {0}", proposal.Show.Description)))
                , Ul( SeasonsToUl(proposal.Show.Seasons) )
                , DrawProposalActions(proposal, user)
                )
        {}

        private static IWritable DrawProposalActions(Proposal proposal, User user)
        {
            List<IWritable> components = new List<IWritable>();

            if ( proposal.Status == ProposalStatus.Created )
            {
                if (user.Equals(proposal.User))
                {
                    components.Add(A(ResolveUri.ForEditProposal(proposal), "Edit"));
                }

                if (user.Role.Equals(Role.Administrator))
                {
                    components.Add(Form("post", ResolveUri.ForAcceptProposal(proposal), InputSubmit("Accept")));
                }

                components.Add(Form("post", ResolveUri.ForRejectProposal(proposal), InputSubmit("Reject")));
            }

            var elem = Div( "controls", "actions"
                          , components.ToArray()
                          );

            return elem;
        }

        private static IWritable[] SeasonsToUl( IEnumerable<Season> seasons )
        {
            return seasons.Select(season => Ul( Li(Text(string.Format("Name: {0}", season.Name)))
                                              , Li(Text("Debut: " + season.Debut.ToString("d")))
                                              , Li(Text("Finale: " + season.Debut.ToString("d")))
                                              , EpisodeToUl(season.Episodes)
                                              )
                                 ).ToArray();
        }

        private static  IWritable EpisodeToUl( IEnumerable<Episode> episodes )
        {
            List<IWritable> list = new List<IWritable>();
            foreach( Episode episode in episodes )
            {
                list.Add( Li( Text( string.Format( "Title: {0}"     , episode.Title    ) ) ) );
                list.Add( Li( Text( string.Format( "Synopsis: {0}"  , episode.Synopsis ) ) ) );
                list.Add( Li( Text( string.Format( "Duration: {0}"  , episode.Duration ) ) ) );
                list.Add( Li( Text( string.Format( "Score(0-5): {0}", episode.Score    ) ) ) );
            }
            return Ul(list.ToArray());
        }
    }
}