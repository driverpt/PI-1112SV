using System.Net;
using System.Security.Principal;

namespace PI.WebGarten.Mvc
{
    public abstract class BaseController
    {
        public RequestInfo RequestInfo { get; set; }
        public HttpListenerContext Context { get { return RequestInfo.Context; } }
        public CookieCollection Cookies { get { return RequestInfo.Context.Request.Cookies; } }
        public IPrincipal User { get { return RequestInfo.User; } }
    }
}