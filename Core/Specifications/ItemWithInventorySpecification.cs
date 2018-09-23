using Core.Entities;

namespace Core.Specifications
{
    public sealed class ItemDetailsSpecification : Specification<Item>
    {
        public ItemDetailsSpecification(int id) : base(i => i.Id == id)
        {
            AddInclude(i => i.Inventory);
        }
    }
}
