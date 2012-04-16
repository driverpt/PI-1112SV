using System.Diagnostics;
using PI.WebGarten.Demos.First;
using PI.WebGarten.Demos.FollowMyTv.Controller;
using PI.WebGarten.Demos.FollowMyTv.Filters;
using PI.WebGarten.Demos.FollowMyTv.Model;
using PI.WebGarten.MethodBasedCommands;
using AuthenticationFilter = PI.WebGarten.Demos.FollowMyTv.Filters.AuthenticationFilter;

namespace PI.WebGarten.Demos.FollowMyTv
{
    class Program
    {
        static void InitPermissions()
        {
            RepositoryLocator.Permissions
                .Add("/proposals", new Permission("/proposals", Role.AuthUser))
                .Add("/proposals/accept", new Permission("/proposals/accept", Role.Administrator))
                .Add("/logout", new Permission("/logout", Role.AuthUser))
                ;
        }

        static void InitUsers()
        {
            RepositoryLocator.Users
                .Add("admin", new User("admin", "admin", Role.Administrator ))
                .Add("user" , new User("user" , "user" , Role.AuthUser      ))
                .Add("nalmendra", new User("nalmendra", "changeit", Role.Administrator))
                ;
        }

        static void Main( string[] args )
        {
            Trace.Listeners.Add( new ConsoleTraceListener() );

            InitPermissions();
            InitUsers();

            var host = new HttpListenerBasedHost( "http://localhost:8080/" );
            host.Add( DefaultMethodBasedCommandFactory.GetCommandsFor( typeof( UserController ) ) );
            host.Pipeline.AddFilterFirst( "ConsoleLog"    , typeof( RequestConsoleLogFilter )                   );
            host.Pipeline.AddFilterAfter( "Authentication", typeof( AuthenticationFilter    ), "ConsoleLog"     );
            host.Pipeline.AddFilterAfter( "Authorization" , typeof( AuthorizationFilter     ), "Authentication" );
            //host.Add( new DummyCommand() );
            host.OpenAndWaitForever();
        }
    }
}