using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using FollowMyTv.DataAccessLayer;
using FollowMyTv.DomainLayer;
using FollowMyTv.DomainLayer.Repository;
using FollowMyTv.DomainLayer.Service;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace FollowMyTv.WebApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        private IUnityContainer ConfigureDependencies()
        {
            var container = new UnityContainer();

            container.RegisterType<IRepository<Show, string>, ShowMemoryRepository>();
            container.RegisterType<IRepository<Proposal, int>, ProposalMemoryRepository>();

            container.RegisterType<ShowService>();
            container.RegisterType<ProposalService>();

            return container;
        }

        private void LoadInitialData()
        {
            /*
             * Init Roles
             *
             */
            if ( Roles.GetAllRoles().Length == 0)
            {
                Roles.CreateRole( FollowMyTvRoles.ADMINISTRATOR );
                Roles.CreateRole( FollowMyTvRoles.AUTH_USER );
            }

            if( Membership.FindUsersByName("administrator").Count == 0 )
            {
                MembershipCreateStatus status;
                Membership.CreateUser( "administrator", "administrator", "admin@isel-leic-pi", "Question", "Answer", true, out status );
                Console.WriteLine( status );
                Roles.AddUserToRole("administrator", FollowMyTvRoles.ADMINISTRATOR );
            }

            
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            DependencyResolver.SetResolver(new UnityDependencyResolver(ConfigureDependencies()));

            LoadInitialData();
        }
    }
}