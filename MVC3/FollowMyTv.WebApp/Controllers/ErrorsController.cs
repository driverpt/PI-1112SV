using System.Net;
using System.Web.Mvc;

namespace FollowMyTv.WebApp.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View();
        }

        public ActionResult InternalServerError()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View();
        }

        public ActionResult Unauthorized()
        {
            Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return View();
        }
    }
}