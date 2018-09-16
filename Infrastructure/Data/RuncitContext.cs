using Core.Entities;
using Core.Entities.PurchaseAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RuncitContext : DbContext
    {
        public RuncitContext(DbContextOptions<RuncitContext> options) : base(options)
        {
        }

        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
