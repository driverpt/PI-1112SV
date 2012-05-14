using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using FollowMyTv.DomainLayer;

namespace FollowMyTv.WebApp
{
    public static class ExtensionMethods
    {
        public static bool IsAdministrator( this IPrincipal principal )
        {
            return principal.IsInRole( FollowMyTvRoles.ADMINISTRATOR );
        }

        public static bool IsAuthenticatedUser( this IPrincipal principal )
        {
            return principal.IsInRole( FollowMyTvRoles.AUTH_USER );
        }

        public static bool IsAnonymousUser( this IPrincipal principal )
        {
            return !principal.Identity.IsAuthenticated;
        }

        public static MvcHtmlString ShowShowsActionsForCurrentUser( this HtmlHelper helper, Show s )
        {
            return helper.Partial("Showactions", s);
        }
    }
}