using System.Net;
using PI.WebGarten.Demos.FollowMyTv.Domain;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;

namespace PI.WebGarten.Demos.FollowMyTv.Filters
{
    public class AuthorizationFilter : BaseFilter
    {
        public AuthorizationFilter(string name) : base(name) {}

        public override HttpResponse Process(RequestInfo requestInfo)
        {
            var minPermission = GetUriPermission(requestInfo.Context.Request.Url.AbsolutePath);

            if( minPermission != null )
            {
                if (requestInfo.User == null)
                {
                    return new HttpResponse( HttpStatusCode.Unauthorized );
                }

                if (!requestInfo.User.IsInRole(minPermission.MinRole.ToString()))
                {
                    return new HttpResponse( HttpStatusCode.Unauthorized );
                }                
            }

            return _nextFilter.Process(requestInfo);
        }

        private Permission GetUriPermission(string uri)
        {
            var path = uri.ToLower();

            Permission permission = null;

            while( permission == null && !path.Equals(string.Empty) )
            {
                permission = RepositoryLocator.Permissions.GetById(path);
                path = path.Substring(0, path.LastIndexOf('/'));
            }

            return permission;
        }
    }
}