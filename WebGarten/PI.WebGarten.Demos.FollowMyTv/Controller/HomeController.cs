using System.Net;
using PI.WebGarten.Demos.FollowMyTv.View;
using PI.WebGarten.MethodBasedCommands;
using PI.WebGarten.Mvc;

namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    public class HomeController : BaseController
    {
        

        [HttpCmd(HttpMethod.Get, "/")]
        public HttpResponse Get()
        {
            return new HttpResponse(HttpStatusCode.OK, new HomeView());
        }
    }
}