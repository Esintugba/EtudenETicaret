using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.Data
{
    public class ETicaretContext : DbContext
    {
        public ETicaretContext (DbContextOptions<ETicaretContext> options)
            : base(options)
        {
        }

        public DbSet<ETicaret.Models.Anasayfa>? Anasayfa { get; set; }
        public DbSet<ETicaret.Models.Kullanicilar>? Kullanicilar { get; set; }
        public DbSet<ETicaret.Models.Kurumsal>? Kurumsal { get; set; }
        public DbSet<ETicaret.Models.Urunler>? Urunler { get; set; }
        public DbSet<ETicaret.Models.Kategori>? Kategori { get; set; }
        public DbSet<ETicaret.Models.BizeUlasin>? BizeUlasin { get; set; }
        public DbSet<ETicaret.Models.Yorumlar>? Yorumlar { get; set; }

    }
}
