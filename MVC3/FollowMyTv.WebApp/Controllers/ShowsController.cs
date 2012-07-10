using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FollowMyTv.DomainLayer;
using FollowMyTv.DomainLayer.Service;
using FollowMyTv.WebApp.Models;
using Microsoft.Practices.Unity;

namespace FollowMyTv.WebApp.Controllers
{
    [HandleError]
    public class ShowsController : Controller
    {
        private const int PAGE_SIZE = 6;
        private readonly ShowService Service;

        public ShowsController( [Dependency] ShowService service )
        {
            Service = service;
        }

        //
        // GET: /Shows/

        public ActionResult Index( bool noPages = false )
        {
            if ( !noPages )
            {
                return RedirectToAction( "Page", new { pageNumber = 1 } );
            }

            IEnumerable<Show> shows = Service.GetAllShows();

            return View( shows );
        }

        public ActionResult Page( int pageNumber = 1 )
        {
            IEnumerable<Show> shows = Service.GetAllShows();

            int total = shows.Count();
            int totalPages = total / PAGE_SIZE + ( total % PAGE_SIZE != 0 ? 1 : 0 );

            shows = shows.Skip( ( pageNumber - 1 ) * PAGE_SIZE ).Take( PAGE_SIZE );

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = PAGE_SIZE;
            ViewBag.TotalPages = totalPages;

            if ( Request.IsAjaxRequest() )
            {
                return Json( new
                {
                    Content = this.RenderPartialViewToString( "_IndexPaged", shows )
                ,
                    TotalPages = totalPages
                ,
                    CurrentPage = pageNumber
                ,
                    PagingTabContent = this.RenderPartialViewToString( "_PagingActions" )
                }, JsonRequestBehavior.AllowGet );
            }

            return View( shows );
        }

        //GET: /Shows/Details/5

        public ActionResult Details( string show, int? season, int? episode )
        {
            Show showObj = Service.GetShowByName( show );
            if ( showObj == null )
            {
                return HttpNotFound();
            }
            return View( showObj );
        }

        public ActionResult CreateSeason( string show )
        {
            Show showObj = Service.GetShowByName( show );
            if ( showObj == null )
            {
                return new HttpNotFoundResult();
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateSeason( SeasonModel model )
        {
            if ( ModelState.IsValid )
            {
                Show showObj = Service.GetShowByName( model.ShowName );
                if ( showObj == null )
                {
                    ModelState.AddModelError( "ShowName", "Show does not exist" );
                    return View( model );
                }
                Season season = Service.GetSeason( showObj.Name, model.Number );
                if ( season == null )
                {
                    season = new Season { Name = model.Name, Number = model.Number, Debut = model.Debut, Finale = model.Finale };
                    Service.AddSeasonToShow( showObj.Name, season );
                    return RedirectToAction( "Index" );
                }
            }

            return View( model );
        }

        //
        // GET: /Shows/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        [Authorize( Roles = FollowMyTvRoles.ADMINISTRATOR )]
        public ActionResult Create( string show, int? season, int? episode )
        {
            Show showObj = Service.GetShowByName( show );
            if ( showObj != null )
            {
                if ( season.HasValue )
                {
                    Season seasonObj = Service.GetSeason( show, season.Value );
                    return View( "CreateEpisode" );
                }
                return View( "CreateSeason" );
            }

            return View( "Create" );
        }

        //
        // POST: /Shows/Create

        [Authorize]
        [HttpPost]
        public ActionResult Create( ShowModel model )
        {
            if ( ModelState.IsValid )
            {
                Show showObj = Service.GetShowByName( model.Name );
                if ( showObj != null )
                {
                    ModelState.AddModelError( "Name", "Show Already Exists" );
                    return View( model );
                }
                showObj = new Show { Name = model.Name, Description = model.Description };
                Service.AddShow( showObj );
                return RedirectToAction( "Index", new { show = showObj.Name } );
            }

            return View();
        }

        //
        // GET: /Shows/Edit/5

        [Authorize( Roles = FollowMyTvRoles.ADMINISTRATOR )]
        public ActionResult Edit( string show )
        {
            Show showObj = Service.GetShowByName( show );
            if ( showObj == null )
            {
                return HttpNotFound();
            }
            return View( showObj );
        }

        //
        // POST: /Shows/Edit/5

        [HttpPost]
        [Authorize( Roles = FollowMyTvRoles.ADMINISTRATOR )]
        public ActionResult Edit( ShowModel model )
        {
            try
            {
                if ( ModelState.IsValid )
                {
                    Show showObj = Service.GetShowByName( model.Name );
                    if ( showObj == null )
                    {
                        ModelState.AddModelError( "Name", "Show does not exist" );
                    }
                    showObj.Name = model.Name;
                    showObj.Description = model.Description;

                    return RedirectToAction( "Index" );
                }
            }
            catch
            {
                return new HttpStatusCodeResult( ( int ) HttpStatusCode.InternalServerError );
            }
            return View( model );
        }

        public ActionResult List( string show, int? season, int? episode )
        {
            if ( string.IsNullOrEmpty( show ) )
            {
                return new HttpNotFoundResult();
            }
            Show showObj = Service.GetShowByName( show );
            if ( showObj != null )
            {
                ViewBag.ShowTitle = showObj.Name;
                if ( season.HasValue )
                {
                    Season seasonObj = Service.GetSeason( show, season.Value );
                    if ( seasonObj != null )
                    {
                        ViewBag.SeasonNumber = seasonObj.Number;
                        return View( "ListEpisodes", seasonObj.Episodes );
                    }
                    return new HttpNotFoundResult();
                }
                return View( "ListSeasons", showObj.Seasons );
            }
            return new HttpNotFoundResult();
        }

        //
        // GET: /Shows/Delete/5

        public ActionResult Delete( int id )
        {
            return View();
        }

        //
        // POST: /Shows/Delete/5

        [HttpPost]
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