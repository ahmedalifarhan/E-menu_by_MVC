using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProF.Data;
using ProF.Models;
namespace ProF.Controllers
{
	public class commentController : Controller
	{

		ApplicationDBcontext db;
		private readonly IWebHostEnvironment _environment;
		public commentController(ApplicationDBcontext db, IWebHostEnvironment environment)


		{
			this.db = db;
			this._environment = environment;
		}

		public IActionResult think()
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
		public IActionResult comment_2()
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
		public IActionResult comment_2(comment comment)
		{

			db.comments.Add(comment);
			db.SaveChanges();
			return RedirectToAction("think");



		}


	}
}
