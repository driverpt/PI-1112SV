using System.Net;

namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    public abstract class BaseController
    {
        public HttpResponse OK(IHttpContent content)
        {
            return new HttpResponse(HttpStatusCode.OK, content);
        }

        public HttpResponse REDIRECT(string location)
        {
            var response = new HttpResponse(HttpStatusCode.Found);
            response.WithHeader("Location", location);
            return response;
        }

        public HttpResponse POST_REDIRECT_GET(string location)
        {
            return new HttpResponse(HttpStatusCode.SeeOther).WithHeader("Location", location);
        }
    }
}