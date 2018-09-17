using Core.Entities;
using Core.Entities.PurchaseAggregate;
using Core.Entities.SellAggregate;
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
        public DbSet<Sell> Sells { get; set; }
        public DbSet<SellItem> SellItems { get; set; }
        public DbSet<ItemInventory> Inventories { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
