using PI.WebGarten.MethodBasedCommands;

namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    public class AuthenticationController : BaseController
    {

        [HttpCmd(HttpMethod.Get, "/login")]
        public HttpResponse Login()
        {
            return null;
        }

        [HttpCmd(HttpMethod.Get, "/logout")]
        public HttpResponse Logout()
        {
            return null;
        }
    }
}