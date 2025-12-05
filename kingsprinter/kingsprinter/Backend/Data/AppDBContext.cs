using Microsoft.EntityFrameworkCore;
using kingsprinter.Models;
using kingsprinter.Backend.Models;

namespace kingsprinter.Data
{
    public class AppDBContext :DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet <Staff>  Staffs { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<PaperQuality> PaperQualities { get; set; }
        public DbSet<CourierPrice> CourierPrices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> Subcategories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Features> features { get; set; }
        public DbSet<LaminationType>laminationTypes { get; set; }
        public DbSet<UVOption> uVOptions { get; set; }

        public DbSet<FoilOption> foilOptions { get; set; }
        public DbSet<DieCutOption> dieCutOptions { get; set; }
        public DbSet<DieCutShape>dieCutShapes { get; set; }

        public DbSet<ProductPrice>productPrices { get; set; }
        public DbSet<PaperSize> PaperSizes { get; set; }
        public DbSet<Texture> textures { get; set; }
        public DbSet<Process> processs { get; set; }
        public DbSet<Product>products { get; set; }
        public DbSet <Order> orders { get; set; }
        public DbSet<City>Cities { get; set; }
    }
}
