using EFDatabaseAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFDatabaseAccess.DataAccess;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using RSVP_App.Models;

namespace RSVP_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ResponseContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ResponseContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
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
                {
                    _dbContext.Responses.Add(new GuestResponse
                    {
                        Name = guestRespond.Name,
                        Email = guestRespond.Email,
                        Phone = guestRespond.Phone,
                        Attend = true
                    });
                    _dbContext.SaveChanges();
                    
                    return RedirectToAction("Thanks");
                }

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
