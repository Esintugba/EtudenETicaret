using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.Models
{
    public class Kullanicilar
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sifre { get; set; }
        public string EMail { get; set; }
        public string ImageUrl { get; set; }
        public System.DateTime EklemeTarihi { get; set; }
        public int Rol { get; set; }
        

    }
}
