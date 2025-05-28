using Btqn_lesson06.Models;
using Microsoft.AspNetCore.Mvc;

namespace Btqn_lesson06.Controllers
{
    public class BtqnEmployeeController : Controller
    {
        private static List<BtqnEmployee> btqnListEmployee = new List<BtqnEmployee>()
        {
            new BtqnEmployee{ BtqnId = 1, BtqnName = "Bùi Thị Quỳnh Nga", BtqnBirthDay = new DateTime(2005, 08,15), BtqnEmail = "ngaquynh158@gmail.com", BtqnPhone = "0912345678", BtqnSalary = 100, BtqnStatus = true},
            new BtqnEmployee{ BtqnId = 2, BtqnName = "Bùi Thị Quỳnh Nga", BtqnBirthDay = new DateTime(2005, 08,15), BtqnEmail = "ngaquynh158@gmail.com", BtqnPhone = "0912345678", BtqnSalary = 100, BtqnStatus = true},
            new BtqnEmployee{ BtqnId = 3, BtqnName = "Bùi Thị Quỳnh Nga", BtqnBirthDay = new DateTime(2005, 08,15), BtqnEmail = "ngaquynh158@gmail.com", BtqnPhone = "0912345678", BtqnSalary = 100, BtqnStatus = true},
            new BtqnEmployee{ BtqnId = 4, BtqnName = "Bùi Thị Quỳnh Nga", BtqnBirthDay = new DateTime(2005, 08,15), BtqnEmail = "ngaquynh158@gmail.com", BtqnPhone = "0912345678", BtqnSalary = 100, BtqnStatus = true},
            new BtqnEmployee{ BtqnId = 5, BtqnName = "Bùi Thị Quỳnh Nga", BtqnBirthDay = new DateTime(2005, 08,15), BtqnEmail = "ngaquynh158@gmail.com", BtqnPhone = "0912345678", BtqnSalary = 100, BtqnStatus = true},
        };
        public IActionResult BtqnIndex()
        {
            return View(btqnListEmployee);
        }
        public IActionResult BtqnCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BtqnCreateSubmit(BtqnEmployee emp)
        {
            if (ModelState.IsValid)
            {
                // Tạo ID mới (tự tăng)
                emp.BtqnId = btqnListEmployee.Count > 0
                    ? btqnListEmployee.Max(e => e.BtqnId) + 1
                    : 1;

                // Thêm vào danh sách tĩnh trong controller
                btqnListEmployee.Add(emp);

                TempData["Success"] = "Thêm sinh viên thành công!";
                return RedirectToAction("BtqnIndex");
            }

            return View("BtqnCreate", emp);
        }
    }
}
