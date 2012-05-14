using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FollowMyTv.DomainLayer;
using FollowMyTv.DomainLayer.Repository;
using FollowMyTv.DomainLayer.Service;
using FollowMyTv.WebApp.Models;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;

namespace FollowMyTv.WebApp.Controllers
{
    [Authorize]
    public class ProposalsController : Controller
    {
        private ProposalService ProposalService;
        private ShowService ShowService;
        private IUserRepository UserRepo;

        [InjectionConstructor]
        public ProposalsController( [Dependency] ProposalService proposalService, [Dependency] IUserRepository userRepository, [Dependency] ShowService showService )
        {
            ProposalService = proposalService;
            UserRepo = userRepository;
            ShowService = showService;
        }
        //
        // GET: /Proposals/

        public ActionResult Index()
        {
            if( User.IsAdministrator() )
            {
                return View(ProposalService.GetAllProposals());
            }
            return View(ProposalService.GetProposalsByUser(User.Identity.Name));
        }

        //
        // GET: /Proposals/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Proposals/Create

        // Creates Proposal Form based on an existing Show
        public ActionResult Create(string id)
        {
            if ( id != null )
            {
                Show show = ShowService.GetShowByName(id);
                if (show != null)
                {
                    return View(show);
                }
            }
            return View();
        }

        //
        // POST: /Proposals/Create

        [HttpPost]
        public ActionResult Create(Show show)
        {
            try
            {
                User user = UserRepo.GetByUsername(User.Identity.Name);

                ProposalService.AddProposal(show, user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Proposals/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Proposals/Edit/5

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

        [Authorize(Roles = FollowMyTvRoles.ADMINISTRATOR)]
        public ActionResult Accept(int id)
        {
            
        }

        [Authorize]
        public ActionResult Reject( int id )
        {

        }
        //
        // GET: /Proposals/Delete/5
 
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Proposals/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
 
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
