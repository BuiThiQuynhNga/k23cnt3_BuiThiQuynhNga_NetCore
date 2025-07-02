using System.Diagnostics;
using BuiThiQuynhNga_2310900075.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuiThiQuynhNga_2310900075.Controllers
{
    public class BtqnHomeController : Controller
    {
        private readonly ILogger<BtqnHomeController> _logger;

        public BtqnHomeController(ILogger<BtqnHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult BtqnIndex()
        {
            return View();
        }

        public IActionResult BtqnAbout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
