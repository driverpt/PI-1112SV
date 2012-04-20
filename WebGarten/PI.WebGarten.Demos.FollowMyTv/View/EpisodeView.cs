using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;
using PI.WebGarten.HttpContent.Html;

namespace PI.WebGarten.Demos.FollowMyTv.View
{
    class EpisodeView : HtmlDoc
    {
        public EpisodeView(string show, Season season, Episode episode) :
            base("Episode",
              A(ResolveUri.ForHome(), "Home")
            , H1(Text("TV Shows"))
            , H2(Text(show))
            , Ul(
              Li(Text("Season: "), Text(season.Name))
            , Li(Text("Title: "), Text(episode.Title))
            , Li(Text("Duration: "), Text("" + episode.Duration))
            , Li(Text("Synopsis: "), Text(episode.Synopsis))
            , Li(Text("Score: "), Text("" + episode.Score)))
            )
        {}
    }
}