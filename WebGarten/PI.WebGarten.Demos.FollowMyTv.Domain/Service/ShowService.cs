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

        private static void AjustSeasonNumber(ref int seasonNumber)
        {
            if ( seasonNumber < 1 )
            {
                throw new ArgumentException( "Invalid Season Number specified, please use numbers bigger than 0" );
            }
            --seasonNumber;
        }

        public static void AddSeasonToShow( string showName, Season season )
        {
            Show show = GetShowByName(showName);
            show.Seasons.Add(season);
        }

        public static void AddEpisodeToSeason( string showName, int season, Episode episode )
        {
            Show show = GetShowByName( showName );
            AjustSeasonNumber(ref season);
            try
            {
                Season seasonObj = show.Seasons[season];
                seasonObj.Episodes.Add(episode);
            }
            catch( ArgumentOutOfRangeException exception) { throw new ArgumentException( String.Format("Season {0} does not exist in show {1}", season, showName) ); }
        }

        public static Season GetSeason( string showName, int season )
        {
            AjustSeasonNumber( ref season );
            Show show = GetShowByName(showName);
            try
            {
                Season seasonObj = show.Seasons[season];
                return seasonObj;
            }
            catch ( ArgumentOutOfRangeException exception ) { throw new ArgumentException( String.Format( "Season {0} does not exist in show {1}", season, showName ) ); }
        }

        public static Episode GetEpisodeByNameShowAndSeason( string showName, int season, string episodeName )
        {
            Season seasonObj = GetSeason(showName, season);
            Episode episodeObj = seasonObj.Episodes.FirstOrDefault(episode => episode.Title.Equals(episodeName));
            if( episodeObj == null )
            {
                AjustSeasonNumber( ref season );
                throw new ArgumentException( String.Format( "Episode {0} does not exist in Show {1}, Season {2}", episodeName, showName, season - 1 ) );
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