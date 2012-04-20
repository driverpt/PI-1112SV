using System.Collections.Generic;
using System.Linq;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;
using PI.WebGarten.HttpContent.Html;

namespace PI.WebGarten.Demos.FollowMyTv.View
{
    public class ProposalView : HtmlDoc
    {
        protected const string TITLE = "Proposals";

        public ProposalView(IEnumerable<Proposal> proposals) :
            base( TITLE,
                  H2(Text("Proposals List"))
                  , Ul(proposals.Select(proposal => Li(A(ResolveUri.For(proposal), proposal.Show.Name))).ToArray()))
        {}

        public ProposalView(Proposal proposal) : 
            base( TITLE,
                  H2(Text(string.Format("Proposal #{0}", proposal.Id)))
                , H1(Text(string.Format("Show: {0}", proposal.Show.Name)))
                , H1(Text( string.Format( "Description: {0}", proposal.Show.Description )))
                , Ul( SeasonsToUl(proposal.Show.Seasons) )
                )
        {}

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