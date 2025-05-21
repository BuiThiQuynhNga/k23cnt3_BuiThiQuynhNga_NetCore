using System.Diagnostics;
using BtqnLesson05Model.Models;
using BtqnLesson05Model.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace BtqnLesson05Model.Controllers
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
            BtqnMember btqnMember = new BtqnMember();
            btqnMember.BtqnMemberId = Guid.NewGuid().ToString();
            btqnMember.BtqnUserName = "QuynhNga";
            btqnMember.BtqnPassword = "123456@";
            btqnMember.BtqnFullName = "Bùi Thị Quỳnh Nga";
            btqnMember.BtqnEmail = "ngaquynh@gamil.com";

            return View(btqnMember);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
