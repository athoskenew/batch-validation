using api.Models.Batch;
using api.Models.Material;
using api.Models.Quality;
using Microsoft.EntityFrameworkCore;

namespace api.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaterialModel>()
                .HasOne(m => m.MaterialQualityVision)
                .WithOne()
                .HasForeignKey<QualityVisionModel>(q => q.MaterialModelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MaterialModel>()
                .HasMany(m => m.MaterialQualityCharacteristics)
                .WithOne()
                .HasForeignKey(q => q.MaterialModelId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<MaterialModel> Materials { get; set; }
        public DbSet<BatchModel> Batches { get; set; }

}
}
