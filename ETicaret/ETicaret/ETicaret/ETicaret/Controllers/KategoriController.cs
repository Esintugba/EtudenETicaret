using ETicaret.Data;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Controllers
{
    public class KategoriController : Controller
    {
        private readonly ETicaretContext db;

        public KategoriController(ETicaretContext context)
        {
            db = context;
        }
        public IActionResult _Index()
        {
            var categories = db.Kategori.OrderBy(k => k.Id).ToList();

            return View(categories);
        }
    }
}
