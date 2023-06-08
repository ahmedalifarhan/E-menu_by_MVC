using Microsoft.AspNetCore.Mvc;

namespace ProF.Controllers
{
    public class offersController : Controller
    {
        public IActionResult pageoffers()
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
    }
}
