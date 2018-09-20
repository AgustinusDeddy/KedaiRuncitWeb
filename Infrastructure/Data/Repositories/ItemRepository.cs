using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(RuncitContext dbContext) : base(dbContext)
        {
        }
    }
}
