using PI.WebGarten.HttpContent.Html;

namespace PI.WebGarten.Demos.FollowMyTv.View
{
    class NewProposalView : HtmlDoc
    {
        public NewProposalView() : base("New Proposal", 
            H1(Text("New Proposal"))
          , Form("post", "new", 
                InputText("show_name")
              , InputSubmit("submit")
            )
        )
        {
        }
    }
}