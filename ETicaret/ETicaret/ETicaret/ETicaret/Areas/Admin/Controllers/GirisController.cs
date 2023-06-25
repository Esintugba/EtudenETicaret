using ETicaret.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;
using ETicaret.Models;
using System.Reflection.Metadata;


namespace ETicaret.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class GirisController : Controller
    {

        private readonly ETicaretContext db;

        public GirisController(ETicaretContext context)
        {
            db = context;
        }

        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GirisSorgula([FromBody]Kullanicilar data)
        {
            try
            {
                string EMail = data.EMail;
                string Sifre = data.Sifre;

                if (string.IsNullOrEmpty(Sifre) && string.IsNullOrEmpty(EMail))
                {
                    return Json(new { Result = false, Message = "Kullanıcı Adınızı ve Şifrenizi Girmediniz!" });
                }
                else if (string.IsNullOrEmpty(EMail))
                {
                    return Json(new { Result = false, Message = "Kullanıcı Adınızı girmediniz!" });
                }
                else if (string.IsNullOrEmpty(Sifre))
                {
                    return Json(new { Result = false, Message = "Şifrenizi Girmediniz!" });
                }
                else
                {

					var kullanici = db.Kullanicilar.FirstOrDefault(x => x.EMail == EMail && x.Sifre == Sifre && x.Rol==1);

					if (kullanici == null) return Json(new { Result = false, Message = "Kullanıcı Adınızı ya da Şifreyi hatalı girdiniz!" });

					HttpContext.Session.SetInt32("Kullanici_ID", kullanici.Id); // Yeni bir session oluşturma.
					HttpContext.Session.SetString("Ad", kullanici.Ad);
					HttpContext.Session.SetString("Soyad", kullanici.Soyad);
					HttpContext.Session.SetString("Resim", kullanici.ImageUrl);
					HttpContext.Session.SetInt32("Rol", kullanici.Rol);



					HttpContext.Session.SetInt32("KullaniciRol", kullanici.Rol);
					HttpContext.Session.SetInt32("YoneticiRol", kullanici.Rol);

					return Json(new { Result = true, Message = "Başarıyla Giriş Yaptınız. Yönlendiriliyorsunuz...", url = "Giris/Anasayfa" });
                }

            }
            catch (Exception ex)
            {
                return Json(new { Result = false, ex.Message });
            }
        }

        public IActionResult OturumuKapat()
        {
            HttpContext.Session.Clear(); // Tüm sessionları temizle
            return View("Giris");
        }


        [ServiceFilter(typeof(Filters.AdminUserSecurityAttribute))]
       
        public IActionResult Anasayfa()
		{
			return View();
		}
        public IActionResult Hata()
        {
            
            return Redirect("/Admin/Giris");
        }
        [HttpGet]
        public IActionResult YeniUrun()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniUrun(Urunler u)
        {
            db.Urunler.Add(u);
            db.SaveChanges();
            return RedirectToAction("Anasayfa");
        }
        public IActionResult UrunListele()
        {
            var rn = db.Urunler.ToList();
            return View(rn);

        }
        public IActionResult UrunSil(int id)
        {
            var sil = db.Urunler.Find(id);
            db.Urunler.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Anasayfa");

        }
        public IActionResult UrunGuncelle(int id)
        {
            var guncel = db.Urunler.Find(id);
            return View("UrunGuncelle",guncel);

        }



        [HttpGet]
        public IActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniKategori(Kategori k)
        {
            db.Kategori.Add(k);
            db.SaveChanges();
            return RedirectToAction("YeniKategori");
        }

        [HttpGet]
        public IActionResult YeniKurumsal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniKurumsal(Kategori ku)
        {
            db.Kategori.Add(ku);
            db.SaveChanges();
            return RedirectToAction("YeniKurumsal");
        }

        public IActionResult HakkimizdaDüzenle()
        {
            var hkmz=db.Kurumsal.ToList();
            return View(hkmz);
        }
        public IActionResult HakkimizdaSil(int id)
        {
            var o = db.Kurumsal.Find(id);
            db.Kurumsal.Remove(o);
            db.SaveChanges();
            return RedirectToAction("Kurumsal");
        }

        public IActionResult YorumGetir()
        {
            return View();
        }
        public IActionResult YorumListele()
        {
            return View();
        }

        public IActionResult MailGetir()
        {
            return View();
        }
        public IActionResult MailListele()
        {
            return View();
        }

        public IActionResult YeniMusteri()
        {
            return PartialView();
        }

        public IActionResult MusteriListele()
        {
            return PartialView();
        }

    }

}




