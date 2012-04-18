using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PI.WebGarten.HttpContent.Html;

namespace PI.WebGarten.Demos.FollowMyTv.View
{
    class HomeView : HtmlDoc
    {
        public HomeView() : base("Home",
            H1(Text("Home")),
            Ul( Li(A(ResolveUri.ForUsers(), "Users")), Li(A(ResolveUri.ForShows(), "TV Shows")))
            )
        {}
    }
}