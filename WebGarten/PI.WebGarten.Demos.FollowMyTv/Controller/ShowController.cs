using System;
using System.Net;
using PI.WebGarten.Demos.FollowMyTv.Domain;
using PI.WebGarten.Demos.FollowMyTv.View;
using PI.WebGarten.MethodBasedCommands;
using PI.WebGarten.Mvc;

namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    public class ShowController : BaseController
    {
        [HttpCmd(HttpMethod.Get, "/shows")]
        public HttpResponse Get()
        {
            return new HttpResponse(HttpStatusCode.OK, new ShowsView(RepositoryLocator.Shows.GetAll()));
        }

        [HttpCmd(HttpMethod.Get, "/shows/{show}")]
        public HttpResponse Get(string show)
        {
            return new HttpResponse(HttpStatusCode.OK, new ShowsView(RepositoryLocator.Shows.GetById(show)));
        }

        [HttpCmd(HttpMethod.Get, "/shows/{show}/{season}")]
        public HttpResponse Get(string show, int season)
        {
            return new HttpResponse(HttpStatusCode.OK, new SeasonView(show, RepositoryLocator.Shows.GetById(show).Seasons[season-1]));
        }

        [HttpCmd(HttpMethod.Get, "/shows/{show}/{season}/{episode}")]
        public HttpResponse Get(string show, int season, int episode)
        {
            return new HttpResponse(HttpStatusCode.OK, new EpisodeView(show, RepositoryLocator.Shows.GetById(show).Seasons[season-1], RepositoryLocator.Shows.GetById(show).Seasons[season-1].Episodes[episode-1]));
        }
    }
}