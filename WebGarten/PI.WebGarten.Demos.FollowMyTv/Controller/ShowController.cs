using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using PI.WebGarten.Demos.FollowMyTv.View;
using PI.WebGarten.MethodBasedCommands;

namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    class ShowController
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