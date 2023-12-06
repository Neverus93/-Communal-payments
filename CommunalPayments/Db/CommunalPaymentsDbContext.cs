using CommunalPayments.ViewModels;
using CommunalPayments.ViewModels.Controls;
using Microsoft.EntityFrameworkCore;

namespace CommunalPayments.Db
{
    public class CommunalPaymentsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource = CommunalPaymentsDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IndicatorsViewModel>()
                .HasKey(i => new
                {
                    i.ColdWaterIndicator,
                    i.HotWaterIndicator,
                    i.ElectricityIndicator
                });

            modelBuilder.Entity<CostsViewModel>()
                .HasKey(c => new
                {
                    c.ColdWaterPerCube,
                    c.HotWaterPerCube,
                    c.ElectricityPerKwt,
                    c.WaterSum,
                    c.Internet
                });
        }
    }
}
