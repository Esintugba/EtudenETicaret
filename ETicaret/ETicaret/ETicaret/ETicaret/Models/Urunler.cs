using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaret.Models
{
    public class Urunler
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

    }
}

