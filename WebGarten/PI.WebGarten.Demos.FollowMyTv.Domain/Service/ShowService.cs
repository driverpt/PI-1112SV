using System;
using System.Linq;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;

namespace PI.WebGarten.Demos.FollowMyTv.Domain.Service
{
    public static class ShowService
    {
        public static void AddShow( Show show )
        {
            RepositoryLocator.Shows.Add(show);
        }

        public static void AddSeasonToShow( string showName, Season season )
        {
            Show show = GetShowByName(showName);
            show.Seasons.Add(season);
        }

        public static void AddEpisodeToSeason( string showName, int seasonNumber, Episode episode )
        {
            Show show = GetShowByName( showName );
            Season seasonObj = show.Seasons.FirstOrDefault(cena => cena.Number == seasonNumber);
            if ( seasonObj == null )
            {
                throw new ArgumentException( String.Format( "Season {0} does not exist in show {1}", seasonNumber, showName ) );
            }
            seasonObj.Episodes.Add(episode);
        }

        public static Season GetSeason( string showName, int seasonNumber )
        {
            Show show = GetShowByName(showName);
            Season seasonObj = show.Seasons.FirstOrDefault( season => season.Number == seasonNumber );
            if( seasonObj == null )
            {
                throw new ArgumentException( String.Format("Season {0} does not exist in show {1}", seasonNumber, showName) );
            }
            return seasonObj;
        }

        public static Episode GetEpisodeByNameShowAndSeason( string showName, int seasonNumber, string episodeName )
        {
            Season seasonObj = GetSeason(showName, seasonNumber);
            Episode episodeObj = seasonObj.Episodes.FirstOrDefault(episode => episode.Title.Equals(episodeName));
            if( episodeObj == null )
            {
                throw new ArgumentException( String.Format( "Episode {0} does not exist in Show {1}, Season {2}", episodeName, showName, seasonNumber - 1 ) );
            }
            return episodeObj;
        }

        public static Episode GetEpisodeByNumberShowAndSeason( string showName, int seasonNumber, int episodeNumber )
        {
            Season seasonObj = GetSeason( showName, seasonNumber );
            Episode episodeObj = seasonObj.Episodes.FirstOrDefault( episode => episode.Number == episodeNumber );
            if ( episodeObj == null )
            {
                throw new ArgumentException( String.Format( "Episode #{0} does not exist in Show {1}, Season {2}", episodeNumber, showName, seasonNumber - 1 ) );
            }
            return episodeObj;
        }

        public static Show GetShowByName(string showName)
        {
            Show show = RepositoryLocator.Shows.GetById(showName);
            if( show == null )
            {
                throw new ArgumentException( String.Format( "Show {0} does not exist", showName ) );    
            }
            return show;
        }
    }
}
