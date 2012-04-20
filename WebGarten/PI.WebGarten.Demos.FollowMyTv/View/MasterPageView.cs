using System.Collections.Generic;
using System.IO;
using PI.WebGarten.HttpContent.Html;

namespace PI.WebGarten.Demos.FollowMyTv.View
{
    public abstract class MasterPageView : HtmlDoc
    {
        private static IWritable[] InitContent(params IWritable[] c )
        {
            List<IWritable> content = new List<IWritable>
                               {
                                   Div("nav", "sidebar",
                                       Ul( Li(A(ResolveUri.ForUsers(), "Home"))
                                           , Li(A(ResolveUri.ForShows(), "TV Shows"))
                                           , Li(A(ResolveUri.ForProposals(), "Proposals List"))
                                           )
                                       )
                               };
            content.AddRange(c);
            return content.ToArray();
        }

        protected MasterPageView( string title, params IWritable[] c ) : base(title, InitContent(c))
        {
        }
    }
}