using System.Linq;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class RuncitContextSeed
    {
        public static void Seed (RuncitContext runcitContext, ILoggerFactory loggerFactory)
        {

            if (!runcitContext.Items.Any())
            {
                runcitContext.AddRange
                (
                    new Item { Name = "Summer 1.5L", Description = "Summer Mineral Water in 1.5L packaging"},
                    new Item { Name = "Detol Soap", Description = "Detol Anti Bacterial Soap in 3 in 1 packaging" },
                    new Item { Name = "Pepsodent 190g", Description = "Pepsodent Toothpaste in 190g tube packaging" }
                );
            }

            runcitContext.SaveChanges();
        }
    }
}
