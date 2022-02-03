using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RSVP_App.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RSVP_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult Index(GuestRespond guestRespond)
        {
            if (ModelState.IsValid)
            {
                if (guestRespond.Attend == true)
                    return RedirectToAction("Thanks");

                else
                    return View("Sorry");
            }

            return View(guestRespond);
        }

        public ActionResult Thanks()
        {
            return View();
        }
    }
}
