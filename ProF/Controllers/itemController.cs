using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProF.Data;
using ProF.Models;

namespace ProF.Controllers
{
    public class itemController : Controller
    {
        ApplicationDBcontext db;
        private readonly IWebHostEnvironment _environment;
        public itemController(ApplicationDBcontext db,IWebHostEnvironment environment)
        {
            this.db = db;
            this._environment = environment;
        }
        //list
        public IActionResult ADD()
        {
            List<item> items = db.items.ToList();

			string isLoggedIn = HttpContext.Session.GetString("IsLoggedIn");
			if (isLoggedIn != null && isLoggedIn == "true")
			{
                return View(items);
			}
			else
			{
				return RedirectToAction("login_admin", "admin");

			}
			
        }

       /* public IActionResult showform_menu()
        {
            List<item> items = db.items.ToList();

            return View(items);
        }*/
        /*
        public IActionResult list_Delete()
        {
            List<item> items = db.items.ToList();



            return View(items);
        }

        
        public IActionResult list_updata()
        {
            List<item> items = db.items.ToList();



            return View(items);
        }
        */

        public IActionResult ADD_Item () {

			string isLoggedIn = HttpContext.Session.GetString("IsLoggedIn");
			if (isLoggedIn != null && isLoggedIn == "true")
			{
				return View();
			}
			else
			{
				return RedirectToAction("login_admin", "admin");

			}
		}
        [HttpPost]
        public async Task<IActionResult> ADD_ItemAsync( item item,IFormFile img_file)
        {
            // to create Images folder in the project Path.
            string path = Path.Combine(_environment.WebRootPath,"img1"); // wwwroot/Img1/
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (img_file != null)
            {
                path = Path.Combine(path, img_file.FileName); // for exmple : /Img/Photoname.png
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await img_file.CopyToAsync(stream);
                    // ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
                    item.item_image = img_file.FileName;
                }
            }
            else
            {
                item.item_image = "tt.png"; // to save the default image path in database.
            }
            try
            {
                db.Add(item);
                db.SaveChanges();
                return RedirectToAction("ADD");
            }
            catch (Exception ex) { ViewBag.exc = ex.Message; }


            return View();
                }
        public IActionResult Delete(int id)
        {
            item item = db.items.FirstOrDefault(i => i.item_id==id);
            string isLoggedIn = HttpContext.Session.GetString("IsLoggedIn");
			if (isLoggedIn != null && isLoggedIn == "true")
			{
				return View(item);
			}
			else
			{
				return RedirectToAction("login_admin", "admin");

			}
		}
        [HttpPost]
        public IActionResult Delete(item item)
        {
            //item item = db.items.FirstOrDefault();
            db.items.Remove(item);
            db.SaveChanges();
           string isLoggedIn = HttpContext.Session.GetString("IsLoggedIn");
			if (isLoggedIn != null && isLoggedIn == "true")
			{
				return RedirectToAction("ADD");
			}
			else
			{
				return RedirectToAction("login_admin", "admin");

			}
        }
        public IActionResult Edit(int id)
        {
            var item = db.items.Where(x => x.item_id == id).FirstOrDefault();
            if (item == null)
            {
                return new NotFoundResult();
            }
			string isLoggedIn = HttpContext.Session.GetString("IsLoggedIn");
			if (isLoggedIn != null && isLoggedIn == "true")
			{
				return View(item);
			}
			else
			{
				return RedirectToAction("login_admin", "admin");

			}

		}
        [HttpPost]
        public IActionResult Edit(item item)
        {
            if (ModelState.IsValid)
            {
                db.items.Update(item);
                db.SaveChanges();
                return RedirectToAction("ADD");
            }
            return View(item);


        }
        public async Task<IActionResult> Next_Item(int item_id)
        {
            string v = HttpContext.Session.GetString("fname");

            if (v==null)
            {
                return RedirectToAction("page9apps", "pageapps");
            }
            else
            {

                var items = await db.items.Where(item => item.category == category.menu).OrderBy(item => item.item_id).ToListAsync();
                if (items.Count == 0)
                {
                    return View("Next_Item");
                }
                int current = items.FindIndex(item => item.item_id == item_id);

                if (current + 1 < items.Count)
                {
                    // استعراض العناصر المتبقية
                    item NextItem = items.ElementAtOrDefault(current + 1);
                    ViewBag.name = NextItem.item_Name;
                    ViewBag.image = NextItem.item_image;
                    ViewBag.stars = NextItem.stars;
                    ViewBag.description = NextItem.item_Description;
                    ViewBag.cost = NextItem.item_Cost;
                    ViewBag.id = NextItem.item_id;
                    return View("Next_Item");
                }
                else
                {
                    // الوصول إلى النهاية، عودة إلى البداية
                    item FirstItem = items.FirstOrDefault();
                    ViewBag.name = FirstItem.item_Name;
                    ViewBag.image = FirstItem.item_image;
                    ViewBag.stars = FirstItem.stars;
                    ViewBag.description = FirstItem.item_Description;
                    ViewBag.cost = FirstItem.item_Cost;
                    ViewBag.id = FirstItem.item_id;
                    return View("Next_Item");
                }
            }


        }
        public async Task<IActionResult> be_Item(int item_id)
        {
            string v = HttpContext.Session.GetString("fname");

            if (v==null)
            {
                return RedirectToAction("page9apps", "pageapps");
            }
            else
            {

                //var count = await db.items.CountAsync();
                var items = await db.items.Where(item => item.category == category.menu).OrderBy(item => item.item_id).ToListAsync();
                if (items.Count == 0)
                {
                    return View("Next_Item");
                }
                int current = items.FindIndex(item => item.item_id == item_id);
                if (current > 0)
                {
                    // استعراض العناصر السابقة
                    item NextItem = items.ElementAtOrDefault(current - 1);
                    ViewBag.name = NextItem.item_Name;
                    ViewBag.image = NextItem.item_image;
                    ViewBag.stars = NextItem.stars;
                    ViewBag.description = NextItem.item_Description;
                    ViewBag.cost = NextItem.item_Cost;
                    ViewBag.id = NextItem.item_id;
                    return View("Next_Item");
                }
                else
                {
                    // الوصول إلى البداية، عودة إلى النهاية
                    item LastItem = items.LastOrDefault();
                    ViewBag.name = LastItem.item_Name;
                    ViewBag.image = LastItem.item_image;
                    ViewBag.stars = LastItem.stars;
                    ViewBag.description = LastItem.item_Description;
                    ViewBag.cost = LastItem.item_Cost;
                    ViewBag.id = LastItem.item_id;
                    return View("Next_Item");
                }
            }

        }
        public IActionResult showform_menu()
        {
            string v = HttpContext.Session.GetString("fname");

            if (v==null)
            {
                return RedirectToAction("page9apps", "pageapps");
            }
            else
            {

                List<item> items = db.items.ToList();


                foreach (var item in items)
                {
                    if (item.category == category.menu)
                    {
                        ViewBag.name = item.item_Name;
                        ViewBag.image = item.item_image;
                        ViewBag.stars = item.stars;
                        ViewBag.description = item.item_Description;
                        ViewBag.cost = item.item_Cost;
                        ViewBag.id = item.item_id;
                        return View("Next_Item", item);
                    }
                }
                return View();
            }

        }
        public IActionResult special_food()
        {
            string v = HttpContext.Session.GetString("fname");

            if (v==null)
            {
                return RedirectToAction("page9apps", "pageapps");
            }
            else
            {

                List<item> items = db.items.ToList();

                foreach (var item in items)
                {
                    if (item.category == category.special_food)
                    {
                        ViewBag.name = item.item_Name;
                        ViewBag.image = item.item_image;
                        ViewBag.stars = item.stars;
                        ViewBag.description = item.item_Description;
                        ViewBag.cost = item.item_Cost;
                        ViewBag.id = item.item_id;


                        return View("special_food");
                    }
                }

                return View("special_food");
            }
        }
        public IActionResult fast_food()
        {
            string v = HttpContext.Session.GetString("fname");

            if (v==null)
            {
                return RedirectToAction("page9apps", "pageapps");
            }
            else
            {

                List<item> items = db.items.ToList();

                foreach (var item in items)
                {
                    if (item.category == category.fast_food)
                    {
                        ViewBag.name = item.item_Name;
                        ViewBag.image = item.item_image;
                        ViewBag.stars = item.stars;
                        ViewBag.description = item.item_Description;
                        ViewBag.cost = item.item_Cost;
                        ViewBag.id = item.item_id;


                        return View("fast_food");
                    }
                }

                return View("fast_food");
            }
        }
        [HttpGet]
        public IActionResult AddToCart(int id)
        {
            //if()
            HttpContext.Session.SetInt32("TotalCost", 0);
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("cart") ?? new List<CartItem>();
            CartItem item1 = cart.FirstOrDefault(i => i.CartItemId == id);
            if (item1 != null)
            {
                item1.Quantity++;


            }
            else
            {
                item t1 = db.items.FirstOrDefault(i => i.item_id == id);
                CartItem newItem = new CartItem
                {
                    CartItemId = t1.item_id,
                    ItemName = t1.item_Name,
                    item_Cost = t1.item_Cost,
                    item_image = t1.item_image,
                    Quantity = 1

                };
                cart.Add(newItem);

            }
            HttpContext.Session.Set("cart", cart);
			string refererUrl = Request.Headers["Referer"].ToString();
			return Redirect(refererUrl);

		}
        public IActionResult Cart()
        {
            string v = HttpContext.Session.GetString("fname");

            if (v==null)
            {
                return RedirectToAction("page9apps", "pageapps");
            }
            else
            {
                
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("cart") ?? new List<CartItem>();
            double totalCost = 0;

            foreach (CartItem item in cart)
            {
                totalCost += item.Quantity * item.item_Cost;
            }
            ViewBag.TotalCost = totalCost;

            return View(cart);

        }
        }
        public IActionResult RemoveFromCart(int id)
        {

            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("cart") ?? new List<CartItem>();
            CartItem item1 = cart.FirstOrDefault(i => i.CartItemId == id);
            if (item1.Quantity >=2)
            {
                item1.Quantity--;


            }
            else
            {

                cart.Remove(item1);

            }
            HttpContext.Session.Set("cart", cart);
            ViewBag.TotalCost -= item1.item_Cost;
            return RedirectToAction("Cart");
        }




    }
}
