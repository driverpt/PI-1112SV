using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PI.WebGarten.Demos.FollowMyTv.Model;
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
            /*, H2(Text(season.Name))
            , H2(Text(episode.Title))
            , H2(Text(""+episode.Duration))
            , H2(Text(episode.Synopsis))
            , H2(Text(""+episode.Score))*/
            )
        {}
    }
}