using Microsoft.AspNetCore.Mvc;
using ProF.Models;
using System.Diagnostics;
using System.Threading;
namespace ProF.Controllers;
using Microsoft.AspNetCore.Http;




public class HomepageController : Controller
{
    private readonly ILogger<HomepageController> _logger;

    public HomepageController(ILogger<HomepageController> logger)
    {
        _logger = logger;
    }
    public IActionResult page1()
    {
        return View();
    }

    public IActionResult Logout()
    {

        HttpContext.Session.Remove("fname");
        HttpContext.Session.Remove("lname");
        HttpContext.Session.Remove("tnumber");
        HttpContext.Session.Clear();
        
        return RedirectToAction("page1", "Homepage");


        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
	public IActionResult page2()
	{
		return View();
	}
}