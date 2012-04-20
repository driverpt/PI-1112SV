using System.Collections.Generic;
using System.Linq;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;
using PI.WebGarten.Demos.FollowMyTv.Domain.Service;

namespace PI.WebGarten.Demos.FollowMyTv.View
{
    class ShowsView : MasterPageView
    {
        public ShowsView(IEnumerable<Show> shows) 
            : base("Shows",
              H1(Text("TV Shows"))
            , Ul( shows.Select( show => Li(A(ResolveUri.ForShow(show), show.Name))).ToArray() )
            )
        {}

        public ShowsView(Show show) 
            : base("Show",
                  A(ResolveUri.ForNewProposalFromExistingShow(show), "Create a Proposal")
                , Ul(Li(Text("Name: "), Text(show.Name)), 
                     Li(Text("Description: "), Text(show.Description)), 
                     Li(Text("Seasons: "), Ul(show.Seasons.Select( season => Li(A(ResolveUri.ForSeason(show, ShowService.GetSeason(show.Name, season.Number)), season.Name))).ToArray())))
            )
        {}
    }
}