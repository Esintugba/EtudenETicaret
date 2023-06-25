using ETicaret.Data;
using ETicaret.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ETicaret.Controllers
{
    public class HomeController : Controller


    {
        private readonly ETicaretContext db;

        public HomeController(ETicaretContext context)
        {
            db = context;
        }
       

       
        public IActionResult Anasayfa()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
        public IActionResult Partial1()
        {
            return PartialView();
        }
        public IActionResult Partial2()
        {
            
            return PartialView();
        }
        public IActionResult Hakkinda()
        {
            return PartialView();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}