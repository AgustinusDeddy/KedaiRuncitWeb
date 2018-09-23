using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using KedaiRuncitWeb.Interfaces;
using KedaiRuncitWeb.ViewModels;
using Microsoft.Extensions.Logging;

namespace KedaiRuncitWeb.Services
{
    public class ItemViewModelService : IItemViewModelService
    {
        private readonly ILogger<ItemViewModelService> _logger;
        private readonly IRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public ItemViewModelService(ILogger<ItemViewModelService> logger, IRepository<Item> itemRepository, IMapper mapper)
        {
            _logger = logger;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public IEnumerable<ItemViewModel> GetItems()
        {
            IEnumerable<ItemViewModel> items = _mapper.Map<IEnumerable<Item>, IEnumerable<ItemViewModel>>(_itemRepository.GetAll());

            return items;
        }

        public ItemViewModel GetItem(int id)
        {
            ItemViewModel item = _mapper.Map<Item, ItemViewModel>(_itemRepository.GetSingleBySpec(new ItemDetailsSpecification(id)));

            return item;
        }
    }
}
