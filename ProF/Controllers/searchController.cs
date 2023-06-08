using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProF.Data;
using ProF.Models;
namespace ProF.Controllers
{
    public class searchController : Controller
    {

        ApplicationDBcontext db;
        private readonly IWebHostEnvironment _environment;
        public searchController(ApplicationDBcontext db, IWebHostEnvironment environment)


        {
            this.db = db;
            this._environment = environment;
        }

        public IActionResult Index_Search()
        {
            ViewBag.Searching = "Search Now....";
            var items = db.items.ToList();
            return View(items);
        }

        [HttpPost]
        public IActionResult Search(string searching)
        {
            ViewBag.Searching = searching;
            if (!string.IsNullOrEmpty(searching))
            {
                var items = db.items.Where(x => x.item_Name.Contains(searching)).ToList();
                return View("Index_Search", items);

            }
            else
            {
                var items = db.items.ToList();
                return View("Index_Search", items);

            }


        }
        public IActionResult Item_Details(int id)
        {
            var item = db.items.Where(x => x.item_id==id).FirstOrDefault();
            ViewBag.name = item.item_Name;
            ViewBag.image = item.item_image;
            ViewBag.stars = item.stars;
            ViewBag.description = item.item_Description;
            ViewBag.cost = item.item_Cost;
            return View();
        }



    }
}
