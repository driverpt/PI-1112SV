namespace PI.WebGarten.Demos.FollowMyTv
{
    public class AuthorizationFilter : BaseFilter
    {
        public AuthorizationFilter(string name) : base(name) {}

        public override HttpResponse Process(RequestInfo requestInfo)
        {
            var ctx = requestInfo.Context;
            var minPermission = GetUriPermission(ctx.Request.Url.AbsolutePath);

            if( minPermission != null )
            {
                if ( ctx.User == null )
                {
                    return new HttpResponse( 401 );
                }

                if ( !ctx.User.IsInRole( minPermission.MinRole.ToString() ) )
                {
                    return new HttpResponse( 401 );
                }                
            }

            return _nextFilter.Process(requestInfo);
        }

        private Permission GetUriPermission(string uri)
        {
            var path = uri.ToLower();

            Permission permission = null;

            while( permission == null && path.Equals(string.Empty) )
            {
                permission = RepositoryLocator.Permissions.GetById(path);
                path = path.Substring(0, path.LastIndexOf('/'));
            }

            return permission;
        }
    }
}