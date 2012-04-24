using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;
using PI.WebGarten.Demos.FollowMyTv.Domain.Service;
using PI.WebGarten.Demos.FollowMyTv.HttpContent.Xml;
using PI.WebGarten.MethodBasedCommands;
using PI.WebGarten.Mvc;

namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    public class ApiController : BaseController
    {
        private const string PI_NAMESPACE = "http://www.adeetc.isel.ipl.pt/programacao/pi/";

        [HttpCmd(HttpMethod.Get, "/api/xml/shows/{name}")]
        public HttpResponse XmlGetShow(string name)
        {
            Show show = ShowService.GetShowByName(name);
            if ( show == null )
            {
                return new HttpResponse(HttpStatusCode.NotFound);
            }
            return new HttpResponse(HttpStatusCode.OK, new XmlDoc(PI_NAMESPACE, show));
        }
    }
}
