using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FollowMyTv.DomainLayer;
using FollowMyTv.DomainLayer.Repository;
using FollowMyTv.WebApp.Models;
using Microsoft.Practices.Unity;

namespace FollowMyTv.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository<Activation, Guid> Repo;
        private readonly IUserRepository userRepo;

        [InjectionConstructor]
        public AccountController( [Dependency] IRepository<Activation, Guid> repository, [Dependency] IUserRepository userRepository)
        {
            Repo = repository;
            userRepo = userRepository;
        }

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user;
                if ( userRepo.TryAuthenticate(model.UserName, model.Password, out user) )
                {
                    if( !user.IsActivated )
                    {
                        ModelState.AddModelError("", "The user is not active.");
                        return View(model);
                    }

                    PIAuthenticationConfiguration config = PIAuthenticationConfiguration.Current;


                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(  1
                                                                                     , user.Identity.Name
                                                                                     , DateTime.Now
                                                                                     , DateTime.Now.AddYears(
                                                                                         config.CookieExpiration)
                                                                                     , model.RememberMe
                                                                                     , ""
                                                                                     , "/"
                                                                                     );


                    HttpCookie cookie = new HttpCookie(config.CookieName, FormsAuthentication.Encrypt(ticket));
                    Response.SetCookie(cookie);

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }


                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff
        [Authorize]
        public ActionResult LogOff()
        {
            PIAuthenticationConfiguration config = PIAuthenticationConfiguration.Current;
            HttpCookie cookie = Request.Cookies[config.CookieName];
            if( cookie != null )
            {
                cookie.Expires = DateTime.Now.AddYears(-1);
                Response.SetCookie( cookie );
            }
            
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                if ( userRepo.CreateUser(model.UserName, model.Password, model.Email, Role.AuthUser) )
                {
                    Guid guid = new Guid();
                    Activation activation = new Activation() { Id = guid, };
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", ErrorCodeToString(MembershipCreateStatus.UserRejected));

                // If we got this far, something failed, redisplay form
                return View(model);
            }

            
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if ( userRepo.ChangePassword(User.Identity.Name, model.NewPassword) )
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }

                ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        [Authorize]
        public ActionResult Edit(string id)
        {
            if( id == null )
            {
                
            }
            MembershipUser user = Membership.GetUser(id);
            string[] roles = Roles.GetRolesForUser(id);
            EditModel model = new EditModel {Email = user.Email, Role = roles[0], UserName = user.UserName};

            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
