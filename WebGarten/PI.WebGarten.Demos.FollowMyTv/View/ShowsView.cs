using System.Collections.Generic;
using System.Linq;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;
using PI.WebGarten.HttpContent.Html;

namespace PI.WebGarten.Demos.FollowMyTv.View
{
    class ShowsView : HtmlDoc
    {
        public ShowsView(IEnumerable<Show> shows) 
            : base("Shows",
              A(ResolveUri.ForHome(), "Home")
            , H1(Text("TV Shows"))
            , Ul( shows.Select( show => Li(A(ResolveUri.ForShow(show.Name), show.Name))).ToArray() )
            )
        {}

        public ShowsView(Show show) 
            : base("Show",
                  A(ResolveUri.ForHome(), "Home")
                , Ul(Li(Text("Name: "), Text(show.Name)), 
                     Li(Text("Description: "), Text(show.Description)), 
                     Li(Text("Seasons: "), Ul(show.Seasons.Select( season => Li(A(ResolveUri.ForSeason(show.Name, season.Name), season.Name))).ToArray())))
            )
        { }
    }
}