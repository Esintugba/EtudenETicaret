using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace ETicaret.Models
{
    public class BizeUlasin
    {
        [Key]
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Mail { get; set; }
        public string Konu { get; set; }
        public string Mesaj { get; set; }
    }
}
