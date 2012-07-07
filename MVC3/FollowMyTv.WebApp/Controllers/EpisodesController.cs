using System;
using System.Net;
using System.Web.Mvc;
using FollowMyTv.DomainLayer;
using FollowMyTv.DomainLayer.Service;
using FollowMyTv.WebApp.Models;

namespace FollowMyTv.WebApp.Controllers
{
    public class EpisodesController : Controller
    {
        private readonly ShowService Service;

        public EpisodesController( ShowService Dependency )
        {
            Service = Dependency;
        }

        //
        // GET: /Episodes/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Episodes/Details/5

        public ActionResult Details( string show, int? season, int? episode )
        {
            Show showObj = Service.GetShowByName( show );
            if ( showObj == null )
            {
                return HttpNotFound();
            }

            Episode episodeObj = Service.GetEpisodeByNumberShowAndSeason( show, season.GetValueOrDefault(), episode.GetValueOrDefault() );

            if ( episodeObj == null )
            {
                return HttpNotFound();
            }

            return View( episodeObj.ToEpisodeModel( show, season.Value ) );
        }

        //
        // GET: /Episodes/Create

        [Authorize( Roles = FollowMyTvRoles.ADMINISTRATOR )]
        public ActionResult Create( string show, int? season )
        {
            return View();
        }

        //
        // POST: /Episodes/Create

        [HttpPost]
        [Authorize( Roles = FollowMyTvRoles.ADMINISTRATOR )]
        public ActionResult Create( EpisodeModel model )
        {
            try
            {
                if ( ModelState.IsValid )
                {
                    Season season = Service.GetSeason( model.ShowName, model.SeasonNumber );
                    if ( season == null )
                    {
                        ModelState.AddModelError( "ShowName", "Show or Season does not exist" );
                        return View( model );
                    }
                    Service.AddEpisodeToSeason( model.ShowName, model.SeasonNumber, model.ToEpisodeDomainEntity() );
                    return RedirectToAction( "Index" );
                }
            }
            catch
            {
                // TODO: LOG
                return new HttpStatusCodeResult( ( int ) HttpStatusCode.InternalServerError );
            }

            return View( model );
        }

        //
        // GET: /Episodes/Edit/5

        [Authorize( Roles = FollowMyTvRoles.ADMINISTRATOR )]
        public ActionResult Edit( string show, int? season, int? episode )
        {
            Episode episodeObj = Service.GetEpisodeByNumberShowAndSeason( show, season.GetValueOrDefault(),
                                                                         episode.GetValueOrDefault() );
            if ( episodeObj == null )
            {
                return HttpNotFound();
            }

            return View( episodeObj.ToEpisodeModel( show, season.GetValueOrDefault() ) );
        }

        //
        // POST: /Episodes/Edit/5

        [HttpPost]
        [Authorize( Roles = FollowMyTvRoles.ADMINISTRATOR )]
        public ActionResult Edit( EpisodeModel model )
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction( "Index" );
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Episodes/Delete/5

        [Authorize( Roles = FollowMyTvRoles.ADMINISTRATOR )]
        public ActionResult Delete( int id )
        {
            return View();
        }

        //
        // POST: /Episodes/Delete/5

        [HttpPost]
        [Authorize( Roles = FollowMyTvRoles.ADMINISTRATOR )]
        public ActionResult Delete( int id, FormCollection collection )
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction( "Index" );
            }
            catch
            {
                return View();
            }
        }
    }
}