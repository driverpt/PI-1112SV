using System;
using System.Collections.Generic;
using System.Linq;
using FollowMyTv.DomainLayer.Repository;
using Microsoft.Practices.Unity;

namespace FollowMyTv.DomainLayer.Service
{
    public class ShowService
    {
        private readonly IRepository<Show, string> Repo;

        [InjectionConstructor]
        public ShowService( [Dependency] IRepository<Show, string> repository )
        {
            Repo = repository;
        }

        public IEnumerable<Show> GetAllShows()
        {
            return Repo.GetAll();
        }

        public void AddShow( Show show )
        {
            Repo.Add( show );
        }

        public void AddSeasonToShow( string showName, Season season )
        {
            Show show = GetShowByName( showName );
            show.Seasons.Add( season );
        }

        public void AddEpisodeToSeason( string showName, int seasonNumber, Episode episode )
        {
            Show show = GetShowByName( showName );
            Season seasonObj = show.Seasons.FirstOrDefault( cena => cena.Number == seasonNumber );
            //if ( seasonObj == null )
            //{
            //    throw new ArgumentException( String.Format( "Season {0} does not exist in show {1}", seasonNumber, showName ) );
            //}
            seasonObj.Episodes.Add( episode );
        }

        public Season GetSeason( string showName, int seasonNumber )
        {
            Show show = GetShowByName( showName );
            Season seasonObj = show.Seasons.FirstOrDefault( season => season.Number == seasonNumber );
            //if( seasonObj == null )
            //{
            //    throw new ArgumentException( String.Format("Season {0} does not exist in show {1}", seasonNumber, showName) );
            //}
            return seasonObj;
        }

        public Episode GetEpisodeByNameShowAndSeason( string showName, int seasonNumber, string episodeName )
        {
            Season seasonObj = GetSeason( showName, seasonNumber );
            Episode episodeObj = seasonObj.Episodes.FirstOrDefault( episode => episode.Title.Equals( episodeName ) );
            //if( episodeObj == null )
            //{
            //    throw new ArgumentException( String.Format( "Episode {0} does not exist in Show {1}, Season {2}", episodeName, showName, seasonNumber - 1 ) );
            //}
            return episodeObj;
        }

        public Episode GetEpisodeByNumberShowAndSeason( string showName, int seasonNumber, int episodeNumber )
        {
            Season seasonObj = GetSeason( showName, seasonNumber );
            Episode episodeObj = seasonObj.Episodes.FirstOrDefault( episode => episode.Number == episodeNumber );
            //if ( episodeObj == null )
            //{
            //    throw new ArgumentException( String.Format( "Episode #{0} does not exist in Show {1}, Season {2}", episodeNumber, showName, seasonNumber - 1 ) );
            //}
            return episodeObj;
        }

        public Show GetShowByName( string showName )
        {
            Show show = Repo.GetById( showName );
            //if( show == null )
            //{
            //    throw new ArgumentException( String.Format( "Show {0} does not exist", showName ) );
            //}
            return show;
        }
    }
}