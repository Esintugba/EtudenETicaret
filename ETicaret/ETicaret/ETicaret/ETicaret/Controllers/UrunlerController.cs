using ETicaret.Data;
using ETicaret.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Controllers
{
    public class UrunlerController : Controller
    {
        private readonly ETicaretContext db;

        public UrunlerController(ETicaretContext context)
        {
            db = context;
        }
        //tüm ürünleri göstermek için linq sorgusu yazıldı.
        public IActionResult Urunler()
        {
            var urun = db.Urunler.Select(i => new Urunler()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description, //eğer açıklama kısmı uzun ise 0-47 karekter arasında görüntüler.Eğer 50 den büyük değilse direk atayabilir.
                Price = i.Price,
                ImageUrl = i.ImageUrl,
                CategoryId = i.CategoryId
            }).OrderByDescending(x => x.Id);
            ViewBag.Kategori = db.Kategori;
            return View(urun);
        }
        public IActionResult Detay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var detay = db.Urunler.FirstOrDefault(x => x.Id == id);
            ViewBag.Kategori = db.Kategori;
            return View(detay);
        }
        public IActionResult getkategori(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var urunler = db.Urunler.Where(u => u.CategoryId == id).ToList();
            ViewBag.Kategori = db.Kategori;
            return View(urunler);
        }

    }
}
