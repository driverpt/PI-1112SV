using System;
using System.Collections.Generic;
using System.Diagnostics;
using PI.WebGarten.Demos.FollowMyTv.Controller;
using PI.WebGarten.Demos.FollowMyTv.Domain;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;
using PI.WebGarten.Demos.FollowMyTv.Domain.Service;
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
            Show show = new Show("Breaking Bad", "Informed he has terminal cancer, an underachieving chemistry genius " +
                                                  "turned high school chemistry teacher turns to using his expertise in " +
                                                  "chemistry to provide a legacy for his family..." +
                                                  " by producing the world's highest quality crystal meth.");
            Season season = new Season("1", new DateTime(2008, 1, 28), new DateTime(2008, 3, 10));
            Episode episode = new Episode("Pilot", 40, "Walter White, a 50-year old chemistry teacher, secretly begins making crystal methamphetamine" +
                                                       " to support his family when he finds out that he has terminal lung cancer. He teams up with a former student," +
                                                       " Jesse Pinkman, who is a meth dealer. Jesse is trying to sell the meth but the dealers snatch him and make him" +
                                                       " show them the lab. Walter knows they intend to kill him so he poisons them while showing them his recipe.", 4);
            ShowService.AddShow(show);
            ShowService.AddSeasonToShow(show.Name, season);
            ShowService.AddEpisodeToSeason(show.Name, 1, episode);

            /*RepositoryLocator.Shows.Add(new Show("Breaking Bad"
                                                , "Informed he has terminal cancer, an underachieving chemistry genius " +
                                                  "turned high school chemistry teacher turns to using his expertise in " +
                                                  "chemistry to provide a legacy for his family..." +
                                                  " by producing the world's highest quality crystal meth."
                                                )
                                       );
            Episode episode = new Episode("Pilot", 40, "Walter White, a 50-year old chemistry teacher, secretly begins making crystal methamphetamine" +
                                                       " to support his family when he finds out that he has terminal lung cancer. He teams up with a former student," +
                                                       " Jesse Pinkman, who is a meth dealer. Jesse is trying to sell the meth but the dealers snatch him and make him" +
                                                       " show them the lab. Walter knows they intend to kill him so he poisons them while showing them his recipe.", 4);
            List<Episode> episodes = new List<Episode>();
            episodes.Add(episode);

            Season season = new Season("1", new DateTime(2008, 1, 28), new DateTime(2008, 3, 10));
            List<Season> seasons = new List<Season>();
            seasons.Add(season);*/

            /*RepositoryLocator.Shows.Add("Breaking Bad", new Show("Breaking Bad"
                                                                , "Informed he has terminal cancer, an underachieving chemistry genius " +
                                                                  "turned high school chemistry teacher turns to using his expertise in " +
                                                                  "chemistry to provide a legacy for his family..." +
                                                                  " by producing the world's highest quality crystal meth."
                                                                , seasons));*/
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