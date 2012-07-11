using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using FollowMyTv.DataAccessLayer;
using FollowMyTv.DomainLayer;
using FollowMyTv.DomainLayer.Repository;
using FollowMyTv.DomainLayer.Service;
using FollowMyTv.WebApp.Filters;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace FollowMyTv.WebApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters( GlobalFilterCollection filters )
        {
            filters.Add( new HandleErrorAttribute() );
            // This probably can be a trouble, but we'll see if its worth changing this to a HttpModule
            filters.Add( new HttpStatusCodeResultFilter() );
        }

        public static void RegisterRoutes( RouteCollection routes )
        {
            routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

            //routes.MapRoute( "Edit", "{controller}/Edit/{id}", new { controller = "Proposals", action = "Edit" } );

            routes.MapRoute(
                            "Paging", // Route name
                            "{controller}/Page/{pageNumber}", // URL with parameters
                            new { controller = "Show", action = "Page", pageNumber = UrlParameter.Optional } // Parameter defaults
                        );

            //routes.MapRoute(
            //    "List", // Route name
            //    "{controller}/{show}/{season}/{episode}", // URL with parameters
            //    new { controller = "Show", action = "Index", season = UrlParameter.Optional, episode = UrlParameter.Optional, routes } // Parameter defaults
            //);

            //routes.MapRoute(
            //    "Episodes", // Route name
            //    "{controller}/{action}/Shows/{show}/Episodes/{season}", // URL with parameters
            //    new { controller = "Shows", action = "Index", season = UrlParameter.Optional } // Parameter defaults
            //);

            routes.MapRoute(
                "Episodes", // Route name
                "Episodes/{action}/{show}/{season}/{episode}", // URL with parameters
                new { controller = "Episodes", action = "Index" } // Parameter defaults
            );

            routes.MapRoute(
                "Shows", // Route name
                "Shows/{action}/{show}/{season}/", // URL with parameters
                new { controller = "Shows", action = "Index", season = UrlParameter.Optional } // Parameter defaults
            );

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
            container.RegisterType<IRepository<Activation, Guid>, GuidActivationMemoryRepository>();
            container.RegisterType<IUserRepository, UserMemoryRepository>( new ContainerControlledLifetimeManager() );

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
            IUserRepository userRepo = DependencyResolver.Current.GetService<IUserRepository>();
            userRepo.CreateUser( "admin", "admin", "admin@pi.isel", Role.Administrator );
            userRepo.ActivateUser( "admin" );
            userRepo.CreateUser( "user", "user", "user@pi.isel", Role.AuthUser );
            userRepo.ActivateUser( "user" );

            //if ( Roles.GetAllRoles().Length == 0)
            //{
            //    Roles.CreateRole( FollowMyTvRoles.ADMINISTRATOR );
            //    Roles.CreateRole( FollowMyTvRoles.AUTH_USER );
            //}

            //if( Membership.FindUsersByName("administrator").Count == 0 )
            //{
            //    MembershipCreateStatus status;
            //    Membership.CreateUser( "administrator", "administrator", "admin@isel-leic-pi", "Question", "Answer", true, out status );
            //    Console.WriteLine( status );
            //    Roles.AddUserToRole("administrator", FollowMyTvRoles.ADMINISTRATOR );
            //}
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters( GlobalFilters.Filters );
            RegisterRoutes( RouteTable.Routes );

            DependencyResolver.SetResolver( new UnityDependencyResolver( ConfigureDependencies() ) );

            LoadInitialData();
        }
    }
}