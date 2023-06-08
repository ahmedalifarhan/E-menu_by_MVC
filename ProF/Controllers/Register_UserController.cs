using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProF.Data;
using ProF.Models;
namespace ProF.Controllers
{
    public class Register_UserController : Controller
    {

        ApplicationDBcontext db;
        private readonly IWebHostEnvironment _environment;
        public Register_UserController(ApplicationDBcontext db, IWebHostEnvironment environment)


        {
            this.db = db;
            this._environment = environment;
        }

        public IActionResult register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult register2(string firstName, string lastName, int idNumber)
        {
            TempData["fname"] = firstName;
            TempData["lname"] = lastName;
            TempData["tnumber"] = idNumber;

            //    // حفظ القيم في TempData لفترة أطول
            TempData.Keep("fname");
            TempData.Keep("lname");
            TempData.Keep("tnumber");
            HttpContext.Session.SetString("fname", firstName);
            HttpContext.Session.SetString("lname", lastName);
            HttpContext.Session.SetInt32("tnumber", idNumber);

            Registeration_USER_ user = new Registeration_USER_();
            user.fname= firstName;
            user.lname= lastName;
            user.table_num = idNumber;
            db.Registeration_USER_s.Add(user);
            db.SaveChanges();
            return RedirectToAction("wellcome", "Register_User");
        }

        

        public IActionResult wellcome()
        {
            var v = HttpContext.Session.GetString("fname");

            if (v==null)
            {
                return RedirectToAction("Register", "Register_User");
            }
            else
            {
                if (TempData["fname"] != null && TempData["lname"] != null && TempData["tnumber"] != null)
                {
                    ViewBag.fname = TempData["fname"];
                    ViewBag.lname = TempData["lname"];
                    ViewBag.tnumber = TempData["tnumber"];

                    // حفظ القيم في TempData لفترة أطول
                    TempData.Keep("fname");
                    TempData.Keep("lname");
                    TempData.Keep("tnumber");

                    return View();
                }
                else
                {
                    return RedirectToAction("Register", "Register_User");
                }
            }
        }
    }

    
}
