using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PI.WebGarten.Demos.FollowMyTv.Model;
using PI.WebGarten.HttpContent.Html;

namespace PI.WebGarten.Demos.FollowMyTv.View
{
    class SeasonView : HtmlDoc
    {
        public SeasonView(string show, Season season) : 
            base("Season",
              A(ResolveUri.ForHome(), "Home")
            , H1(Text("TV Shows"))
            , H2(Text(show))
            , Ul(season.Episodes.Select(episode => Li(A(ResolveUri.ForEpisode(show, season.Name, episode.Title), episode.Title))).ToArray())
            )
        {}
    }
}