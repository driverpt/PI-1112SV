using System.Globalization;
using System.Web;
using System.Web.Mvc;

namespace FollowMyTv.WebApp.Filters
{
    public class HttpStatusCodeResultFilter : IResultFilter, IExceptionFilter
    {
        private const int FIRST_ERROR_CODE = 400;

        public void OnResultExecuting( ResultExecutingContext filterContext )
        {
            // Nothing to do
        }

        public void OnResultExecuted( ResultExecutedContext filterContext )
        {
            HttpStatusCodeResult httpStatusCodeResult = filterContext.Result as HttpStatusCodeResult;

            if ( httpStatusCodeResult != null && httpStatusCodeResult.StatusCode >= FIRST_ERROR_CODE )
            {
                ExecuteCustomViewResult( filterContext.Controller.ControllerContext, httpStatusCodeResult.StatusCode );
            }
        }

        public void OnException( ExceptionContext filterContext )
        {
            HttpException httpException = filterContext.Exception as HttpException;

            if ( httpException != null )
            {
                ExecuteCustomViewResult( filterContext.Controller.ControllerContext, httpException.GetHttpCode() );
                // This causes ELMAH not to log exceptions, so commented out
                //filterContext.ExceptionHandled = true;
            }
        }

        internal void ExecuteCustomViewResult( ControllerContext controllerContext, int httpCode )
        {
            ViewEngineResult viewLocation = ViewEngines.Engines.FindView( controllerContext,
                                                                   httpCode.ToString( CultureInfo.InvariantCulture ),
                                                                   string.Empty );
            if ( viewLocation.View != null )
            {
                ViewResult viewResult = new ViewResult
                                            {
                                                View = viewLocation.View,
                                                ViewData = controllerContext.Controller.ViewData,
                                                TempData = controllerContext.Controller.TempData
                                            };
                viewResult.ExecuteResult( controllerContext );
                controllerContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            }
        }
    }
}