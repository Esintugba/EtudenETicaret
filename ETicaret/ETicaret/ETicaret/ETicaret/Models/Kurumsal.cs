using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.Models
{
    public class Kurumsal
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Aciklama { get; set; }
        
    }
}
