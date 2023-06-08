using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProF.Data;
using ProF.Models;
namespace ProF.Controllers
{
    public class paymentController : Controller
    {

        ApplicationDBcontext db;
        private readonly IWebHostEnvironment _environment;
        public paymentController(ApplicationDBcontext db, IWebHostEnvironment environment)


        {
            this.db = db;
            this._environment = environment;
        }



        public IActionResult payment()
        {
            string v = HttpContext.Session.GetString("fname");

            if (v==null)
            {
                return RedirectToAction("page9apps", "pageapps");
            }
            else
            {

                return View();
            }
        }

        [HttpPost]
        public IActionResult payment(Payment type_Payment)
        {/*
            if (ModelState.IsValid)
            {*/

            db.Payments.Add(type_Payment);
            db.SaveChanges();
            return RedirectToAction("comment_2", "comment");



        }
    }
}

