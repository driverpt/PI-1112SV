using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;
using PI.WebGarten.Demos.FollowMyTv.Domain.Service;
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
            , Text("Starts: "), Text(season.Debut.ToString())
            , P(Text(""))
            , Text("Ends: "), Text(season.Finale.ToString())
            , Ul(season.Episodes.Select(episode => Li(A(ResolveUri.ForEpisode(show, ShowService.GetEpisodeByNameShowAndSeason(show, season.Number, episode.Title), episode.Title), episode.Title))).ToArray())
            )
        {}
    }
}