using System.Globalization;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;
using PI.WebGarten.HttpContent.Html;

namespace PI.WebGarten.Demos.FollowMyTv.View
{
    public class ProposalForm : HtmlDoc
    {
        public ProposalForm() : base("New Proposal", H1(Text("New Show"))
                                                   , Form(HttpMethod.Post, ResolveUri.ForNewProposal()
                                                        , Label( "show_name", "Show Name:" )               , InputText( "show_name" )
                                                        , Label( "show_description", "Show Description:" ) , InputText( "show_description" )
                                                        /*, Label( "season_name", "Season Name:" )                        , InputText( "season_name" )
                                                        , Label( "season_start_date", "Season Start Date(dd-mm-yyyy):" ), InputText( "season_start_date" )
                                                        , Label( "season_end_date", "Season End Date(dd-mm-yyyy):" )    , InputText( "season_end_date" )
                                                        , Label( "episode_title", "Episode Title:" )                    , InputText( "episode_title" )
                                                        , Label( "episode_duration", "Episode Duration:" )              , InputText( "episode_duration" )
                                                        , Label( "episode_sinopsis", "Episode Sinopsis:" )              , InputText( "episode_sinopse" )
                                                        , Label( "episode_rating", "Episode Rating:" )                  , InputText( "episode_rating" )
                                                         * 
                                                         */
                                                        , InputSubmit( "submit" )
                                                        )
                                             )
        {}

        public ProposalForm(Show show) : base("New Proposal", H1(Text("New Show"))
                                                            , Form(HttpMethod.Post, ResolveUri.ForNewProposal()
                                                            , Label( "show_name", "Show Name:" )               , InputText( "show_name"       , false, show.Name        )
                                                            , Label( "show_description", "Show Description:" ) , InputText( "show_description", false, show.Description )
                                                            , InputSubmit("submit")
                                                            )
                                              ) {}
        public ProposalForm( Proposal proposal )
            : base( "New Proposal", H1( Text( "New Show" ) )
                                 , Form( HttpMethod.Post, ResolveUri.ForSubmitEditProposal()
                                 , InputHidden("proposal_id", proposal.Id.ToString())
                                 , Label( "show_name", "Show Name:" ), InputText( "show_name", false, proposal.Show.Name )
                                 , Label( "show_description", "Show Description:" ), InputText( "show_description", false, proposal.Show.Description )
                                 , InputSubmit( "submit" )
                                 )
                   ) { }
    }
}
