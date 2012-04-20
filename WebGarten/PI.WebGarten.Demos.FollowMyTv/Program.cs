using System.Diagnostics;
using PI.WebGarten.Demos.FollowMyTv.Controller;
using PI.WebGarten.Demos.FollowMyTv.Domain;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;
using PI.WebGarten.Demos.FollowMyTv.Filters;
using PI.WebGarten.MethodBasedCommands;
using AuthenticationFilter = PI.WebGarten.Demos.FollowMyTv.Filters.AuthenticationFilter;

namespace PI.WebGarten.Demos.FollowMyTv
{
    class Program
    {
        static void InitPermissions()
        {
            RepositoryLocator.Permissions
                .Add(new Permission("/proposals", Role.AuthUser))
                .Add(new Permission("/proposals/accept", Role.Administrator))
                .Add(new Permission("/logout", Role.AuthUser))
                ;
        }

        static void InitUsers()
        {
            RepositoryLocator.Users
                .Add(new User("admin"    , "admin"   , Role.Administrator ))
                .Add(new User("user"     , "user"    , Role.AuthUser      ))
                .Add(new User("nalmendra", "changeit", Role.Administrator ))
                ;
        }

        static void InitShows()
        {
            RepositoryLocator.Shows.Add(new Show("Breaking Bad"
                                                , "Informed he has terminal cancer, an underachieving chemistry genius " +
                                                  "turned high school chemistry teacher turns to using his expertise in " +
                                                  "chemistry to provide a legacy for his family..." +
                                                  " by producing the world's highest quality crystal meth."
                                                )
                                       );
        }

        static void Main( string[] args )
        {
            Trace.Listeners.Add( new ConsoleTraceListener() );

            InitPermissions();
            InitUsers();
            InitShows();

            var host = new HttpListenerBasedHost( "http://localhost:8080/" );
            host.Add(DefaultMethodBasedCommandFactory.GetCommandsFor(
                                                                    typeof( UserController     )
                                                                  , typeof( HomeController     )
                                                                  , typeof( ShowController     )
                                                                  , typeof( ProposalController )
                                                                  , typeof( AuthController     )
                                                                  )
            );
            
            host.Pipeline.AddFilterFirst( "ConsoleLog"    , typeof( RequestConsoleLogFilter )                   );
            host.Pipeline.AddFilterAfter( "Authentication", typeof( AuthenticationFilter    ), "ConsoleLog"     );
            host.Pipeline.AddFilterAfter( "Authorization" , typeof( AuthorizationFilter     ), "Authentication" );
            //host.Add( new DummyCommand() );
            host.OpenAndWaitForever();
        }
    }
}