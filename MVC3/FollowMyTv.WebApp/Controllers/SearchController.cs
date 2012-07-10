using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FollowMyTv.DomainLayer;
using FollowMyTv.DomainLayer.Service;
using Microsoft.Practices.Unity;
using System.Linq;

namespace FollowMyTv.WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly ShowService Service;

        public SearchController([Dependency] ShowService service)
        {
            Service = service;
        }

        //
        // GET: /Search/
        public ActionResult Index(string query)
        {
            if(!string.IsNullOrEmpty(query))
            {
                IEnumerable<Show> shows = Service.GetAllShows().Where(show => show.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Suggestion", shows);
                }
                return View("Index", shows);
            }
            return null;
        }
    }
}
