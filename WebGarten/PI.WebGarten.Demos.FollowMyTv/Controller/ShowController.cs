using System.Net;
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

        [HttpCmd(HttpMethod.Get, "/shows/{id}")]
        public HttpResponse Get(string id)
        {
            return new HttpResponse(HttpStatusCode.OK, new ShowsView(RepositoryLocator.Shows.GetById(id)));
        }
    }
}