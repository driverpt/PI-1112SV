using System.Net;
using PI.WebGarten.Demos.FollowMyTv.Domain;
using PI.WebGarten.Demos.FollowMyTv.Domain.Repository;

namespace PI.WebGarten.Demos.FollowMyTv.Filters
{
    public class AuthenticationFilter : BaseFilter
    {
        private const string URI_LOGIN = "login";
        private const string COOKIE_AUTH_NAME = "PI_AUTH";

        private readonly IUserRepository UserRepo = UserRepositoryLocator.Instance;

        public AuthenticationFilter(string name) : base(name) {}

        #region Implementation of IHttpFilter

        public override HttpResponse Process( RequestInfo requestInfo )
        {
            //definir utilizador através do cookie
            Cookie authenticationCookie = requestInfo.Context.Request.Cookies[COOKIE_AUTH_NAME];
            if (authenticationCookie != null)
            {
                requestInfo.User = UserRepo.GetByUsername(authenticationCookie.Value);
            }
            
            var response = _nextFilter.Process(requestInfo);

            //se for unauthorized redireccionar para login
            if (response.Status == (int)HttpStatusCode.Unauthorized && !response.HasAuthHeader())
            {
                return new HttpResponse(HttpStatusCode.Found).WithHeader("Location", URI_LOGIN);
            }

            return response;
        }

        #endregion
    }
}
