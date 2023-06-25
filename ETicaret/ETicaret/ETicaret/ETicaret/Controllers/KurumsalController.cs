using ETicaret.Data;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Controllers
{
    public class KurumsalController : Controller
    {
        private readonly ETicaretContext db;

        public KurumsalController(ETicaretContext context)
        {
            db = context;
        }
        public IActionResult Kurumsal()
        {
            var kurumsal = db.Kurumsal.OrderByDescending(x => x.Id);
            return View(kurumsal);
        }

	}
}
