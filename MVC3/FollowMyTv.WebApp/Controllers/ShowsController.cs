using System.Collections.Generic;
using System.Web.Mvc;
using FollowMyTv.DomainLayer;
using FollowMyTv.DomainLayer.Service;
using Microsoft.Practices.Unity;

namespace FollowMyTv.WebApp.Controllers
{
    public class ShowsController : Controller
    {
        private readonly ShowService Service;

        public ShowsController([Dependency] ShowService service)
        {
            Service = service;
        }

        //
        // GET: /Shows/

        public ActionResult Index()
        {
            IEnumerable<Show> shows = Service.GetAllShows();
            return View(shows);
        }

        //
        // GET: /Shows/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Shows/Create
        [Authorize(Roles = FollowMyTvRoles.ADMINISTRATOR)]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Shows/Create

        [Authorize]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            
            try
            {
                // TODO: Add insert logic here
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Shows/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Shows/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Shows/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Shows/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
