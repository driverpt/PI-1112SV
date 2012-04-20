using System;
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

        public static void AddEpisodeToSeason( string showName, int season, Episode episode )
        {
            Show show = GetShowByName( showName );
            try
            {
                Season seasonObj = show.Seasons[season];
                seasonObj.Episodes.Add(episode);
            }
            catch( ArgumentOutOfRangeException exception) { throw new ArgumentException( String.Format("Season {0} does not exist in show {1}", season, showName) ); }
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