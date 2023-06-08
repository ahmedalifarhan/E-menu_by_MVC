using Microsoft.AspNetCore.Mvc;
using ProF.Data;
using ProF.Models;
using Microsoft.AspNetCore.Mvc.Filters;
namespace ProF.Controllers
{
    public class AdminController : Controller
    {
        
        private readonly ApplicationDBcontext _dbcontext;
        public AdminController (ApplicationDBcontext dBcontext)
        {
            _dbcontext = dBcontext;
        }
        [HttpGet]
        public IActionResult login_admin()
        {
        return View( new login_admin());
        }

        [HttpPost]
        public IActionResult login_admin(login_admin login_admin)
        {
            if (ModelState.IsValid)
            {
				_dbcontext.login_admins.Add(login_admin);
                _dbcontext.SaveChanges();
				//اسم الصفحه التانيه
				HttpContext.Session.SetString("IsLoggedIn", "true");

				return RedirectToAction("ADD_DELETE_UPDATA");
            }


			
			return View(login_admin);
        }


		public IActionResult ADD_DELETE_UPDATA()
		{
			
			string isLoggedIn = HttpContext.Session.GetString("IsLoggedIn");
			if (isLoggedIn != null && isLoggedIn == "true")
			{
		
				return View("ADD_DELETE_UPDATA");
			}
			else
			{
				return RedirectToAction("login_admin");
			}
		}

	}
}
