using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.Areas.Admin.Controllers
{
    public class HataController : Controller
    {
        public IActionResult Hata()
        {
            return Redirect("/Admin/Giris");
        }
    }
}
