using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using myBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myBank.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccountId = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId).First().Id;
            ViewBag.CheckingAccountId = checkingAccountId;

            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            ViewBag.Pin = user.Pin;
            return View();
        }

      //  [ActionName("jide")]
    //  [Authorize(Roles="Administrator", Users ="jide")]
        [Route("home/about")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.TheMessage = "Thanks we got your message";

            return View();
        }

        public ActionResult Foo()
        {
            return View();
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVC5";

            if(letterCase == "lower")
            {
                return Content(serial.ToLower());

            }

            return Json(new { name = "serial", value = serial }, JsonRequestBehavior.AllowGet);
        }
    }
}