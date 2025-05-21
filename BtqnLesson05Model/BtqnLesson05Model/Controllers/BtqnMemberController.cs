using BtqnLesson05Model.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace BtqnLesson05Model.Controllers
{
    public class BtqnMemberController : Controller
    {
        private static List<BtqnMember> btqnListMember = new List<BtqnMember>()
        {
            new BtqnMember
            {
                BtqnMemberId = "2310900075",
                BtqnUserName = "QuynhNga",
                BtqnPassword = "pass123",
                BtqnFullName = "Bùi Thị Quỳnh Nga",
                BtqnEmail = "ngaquynh@gmail.com"
            },
            new BtqnMember
            {
                BtqnMemberId = "M002",
                BtqnUserName = "jane456",
                BtqnPassword = "secure456",
                BtqnFullName = "Jane Smith",
                BtqnEmail = "jane@example.com"
            },
            new BtqnMember
            {
                BtqnMemberId = "M003",
                BtqnUserName = "tom789",
                BtqnPassword = "tompass789",
                BtqnFullName = "Tom Hanks",
                BtqnEmail = "tom@example.com"
            },
            new BtqnMember
            {
                BtqnMemberId = "M004",
                BtqnUserName = "lisa321",
                BtqnPassword = "lisapass321",
                BtqnFullName = "Lisa Ray",
                BtqnEmail = "lisa@example.com"
            },
            new BtqnMember
            {
                BtqnMemberId = "M005",
                BtqnUserName = "mark654",
                BtqnPassword = "markpass654",
                BtqnFullName = "Mark Lee",
                BtqnEmail = "mark@example.com"
            }
        };
        public IActionResult BtqnIndex() //List Member
        {
            return View(btqnListMember);
        }
    }
}
