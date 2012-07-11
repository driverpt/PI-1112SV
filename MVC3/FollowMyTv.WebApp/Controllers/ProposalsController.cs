using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using FollowMyTv.DomainLayer;
using FollowMyTv.DomainLayer.Repository;
using FollowMyTv.DomainLayer.Service;
using FollowMyTv.WebApp.Models;
using Microsoft.Practices.Unity;

namespace FollowMyTv.WebApp.Controllers
{
    [Authorize]
    public class ProposalsController : Controller
    {
        private readonly ProposalService ProposalService;
        private readonly ShowService ShowService;
        private readonly IUserRepository UserRepo;

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
            IEnumerable<Proposal> proposals;
            if ( User.IsAdministrator() )
            {
                proposals = ProposalService.GetAllProposals();
                return View( proposals );
            }

            proposals = ProposalService.GetProposalsByUser( User.Identity.Name );
            return View( proposals );
        }

        //
        // GET: /Proposals/Details/5

        public ActionResult Details( int id )
        {
            Proposal proposal = ProposalService.GetProposalById( id );
            return View( proposal );
        }

        //
        // GET: /Proposals/Create

        // Creates Proposal Form based on an existing Show
        public ActionResult Create( string show )
        {
            if ( show == null )
            {
                return View();
            }

            Show showObj = ShowService.GetShowByName( show );
            if ( showObj == null )
            {
                return HttpNotFound();
            }
            User user = UserRepo.GetByUsername( User.Identity.Name );
            Proposal proposal = new Proposal { Show = showObj, User = user };

            return View( proposal );
        }

        //
        // POST: /Proposals/Create

        [HttpPost]
        public ActionResult Create( Proposal proposal )
        {
            try
            {
                User user = UserRepo.GetByUsername( User.Identity.Name );

                Show show = ShowService.GetShowByName( proposal.Show.Name );
                if ( show == null )
                {
                    show = new Show { Description = proposal.Show.Description, Name = proposal.Show.Name };
                }
                var createdProposal = ProposalService.AddProposal( show, user );
                return RedirectToAction( "Details", "Proposals", new { id = createdProposal.Id } );
            }
            catch
            {
                return View(proposal);
                return new HttpStatusCodeResult( ( int ) HttpStatusCode.InternalServerError );
            }
        }

        //
        // GET: /Proposals/Edit/5
        public ActionResult Edit( int id )
        {
            User user = UserRepo.GetByUsername( User.Identity.Name );
            Proposal proposal = ProposalService.GetProposalById( id );
            if ( proposal == null )
            {
                return HttpNotFound();
            }

            if ( proposal.User.Equals( user ) || user.IsAdministrator() )
            {
                return View( proposal );
            }

            return new HttpStatusCodeResult( ( int ) HttpStatusCode.Unauthorized );
        }

        //
        // POST: /Proposals/Edit/5
        [HttpPost]
        public ActionResult Edit( ProposalModel model )
        {
            try
            {
                User user = UserRepo.GetByUsername( User.Identity.Name );
                Proposal proposal = ProposalService.GetProposalById( model.ProposalId );

                if ( proposal == null )
                {
                    return HttpNotFound();
                }

                if ( proposal.User.Equals( user ) || user.IsAdministrator() )
                {
                    proposal.Show.Name = model.Name;
                    proposal.Show.Description = model.Description;

                    return RedirectToAction( "Index" );
                }

                return new HttpStatusCodeResult( ( int ) HttpStatusCode.Unauthorized );
            }
            catch
            {
                return View();
            }
        }

        [Authorize( Roles = FollowMyTvRoles.ADMINISTRATOR )]
        [HttpPost]
        public ActionResult Accept( int id )
        {
            Proposal proposal = ProposalService.GetProposalById( id );

            if ( proposal == null )
            {
                return HttpNotFound();
            }

            if ( proposal.Status == ProposalStatus.Created )
            {
                proposal.Status = ProposalStatus.Accepted;
                return RedirectToAction( "Index" );
            }

            return new HttpStatusCodeResult( ( int ) HttpStatusCode.BadRequest );
        }

        [Authorize]
        [HttpPost]
        public ActionResult Reject( int id )
        {
            Proposal proposal = ProposalService.GetProposalById( id );

            if ( proposal == null )
            {
                return HttpNotFound();
            }

            if ( proposal.Status == ProposalStatus.Created )
            {
                if ( User.IsAdministrator() || User.Equals( proposal.User ) )
                {
                    proposal.Status = ProposalStatus.Rejected;
                    return RedirectToAction( "Index" );
                }
            }

            return new HttpStatusCodeResult( ( int ) HttpStatusCode.BadRequest );
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