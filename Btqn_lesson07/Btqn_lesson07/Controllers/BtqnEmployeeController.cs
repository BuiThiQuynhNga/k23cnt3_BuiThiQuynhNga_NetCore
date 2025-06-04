using Btqn_lesson07.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Btqn_lesson07.Controllers
{
    public class BtqnEmployeeController : Controller
    {
        //Mock Data:
        private static List<BtqnEmployee> btqnListEmployee = new List<BtqnEmployee>()
        {
            new BtqnEmployee
            {
                BtqnId = 1,
                BtqnName = "Bùi Thị Quỳnh Nga",
                BtqnBirthDay = new DateTime(2005, 8, 15),
                BtqnEmail = "quynga@gmail.com",
                BtqnPhone = "0901234567",
                BtqnSalary = 15000000,
                BtqnStatus = true
            },
            new BtqnEmployee
            {
                BtqnId = 2,
                BtqnName = "Trần Thị B",
                BtqnBirthDay = new DateTime(1992, 3, 22),
                BtqnEmail = "thib@example.com",
                BtqnPhone = "0912345678",
                BtqnSalary = 12000000,
                BtqnStatus = true
            },
            new BtqnEmployee
            {
                BtqnId = 3,
                BtqnName = "Lê Văn C",
                BtqnBirthDay = new DateTime(1988, 5, 10),
                BtqnEmail = "vanc@example.com",
                BtqnPhone = "0987654321",
                BtqnSalary = 18000000,
                BtqnStatus = false
            },
            new BtqnEmployee
            {
                BtqnId = 4,
                BtqnName = "Phạm Thị D",
                BtqnBirthDay = new DateTime(1995, 8, 18),
                BtqnEmail = "thid@example.com",
                BtqnPhone = "0909090909",
                BtqnSalary = 10000000,
                BtqnStatus = true
            },
            new BtqnEmployee
            {
                BtqnId = 5,
                BtqnName = "Hoàng Văn E",
                BtqnBirthDay = new DateTime(1985, 12, 5),
                BtqnEmail = "vane@example.com",
                BtqnPhone = "0933333333",
                BtqnSalary = 20000000,
                BtqnStatus = false
            }
        };
        // GET: BtqnEmployeeController
        public ActionResult BtqnIndex()
        {
            return View(btqnListEmployee);
        }

        // GET: BtqnEmployeeController/BtqnDetails/5
        public ActionResult BtqnDetails(int id)
        {
            var btqnEmployee = btqnListEmployee.FirstOrDefault(x => x.BtqnId == id);
            return View(btqnEmployee);
        }

        // GET: BtqnEmployeeController/BtqnCreate
        public ActionResult BtqnCreate()
        {
            var btqnEmployee = new BtqnEmployee();
            return View(btqnEmployee);
        }

        // POST: BtqnEmployeeController/BtqnCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BtqnCreate(BtqnEmployee btqnModel)
        {
            try
            {
                //thêm mới vào  list
                btqnModel.BtqnId = btqnListEmployee.Max(x => x.BtqnId) + 1;
                btqnListEmployee.Add(btqnModel);    
                return RedirectToAction(nameof(BtqnIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: BtqnEmployeeController/BtqnEdit/5
        public ActionResult BtqnEdit(int id)
        {
            var btqnEmployee = btqnListEmployee.FirstOrDefault(x=>x.BtqnId == id);  
            return View(btqnEmployee);
        }

        // POST: BtqnEmployeeController/BtqnEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BtqnEdit(int id, BtqnEmployee btqnModel)
        {
            try
            {
                for (int i = 0;i<btqnListEmployee.Count();i++)
                {
                    if (btqnListEmployee[i].BtqnId == id)
                        { 
                            btqnListEmployee[i] = btqnModel;
                            break;
                        }    
                }    
                return RedirectToAction(nameof(BtqnIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: BtqnEmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BtqnEmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
