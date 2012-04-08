using System.Diagnostics;
using PI.WebGarten.Demos.First;
using PI.WebGarten.Demos.FollowMyTv.Controller;
using PI.WebGarten.Demos.FollowMyTv.Model;
using PI.WebGarten.MethodBasedCommands;

namespace PI.WebGarten.Demos.FollowMyTv
{
    class Program
    {
        static void Main( string[] args )
        {
            Trace.Listeners.Add( new ConsoleTraceListener() );

            var repo = UserRepositoryLocator.Instance;
            repo.Add(new User{ Name="Administrator", Password = "xpto"});

            var host = new HttpListenerBasedHost( "http://localhost:8080/" );
            host.Add( DefaultMethodBasedCommandFactory.GetCommandsFor( typeof( UserController ) ) );
            host.Pipeline.AddFilterFirst( "ConsoleLog", typeof( RequestConsoleLogFilter ) );
            host.Pipeline.AddFilterAfter( "Authentication", typeof( AuthenticationFilter ), "ConsoleLog" );
            //host.Add( new DummyCommand() );
            host.OpenAndWaitForever();
        }
    }
}
