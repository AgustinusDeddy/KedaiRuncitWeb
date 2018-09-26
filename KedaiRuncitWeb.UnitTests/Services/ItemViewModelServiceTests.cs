using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using KedaiRuncitWeb.Services;
using KedaiRuncitWeb.ViewModels;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace KedaiRuncitWeb.UnitTests.Services
{
    [TestFixture]
    public class ItemViewModelServiceTests
    {
        private IMapper _mapper;
        private Mock<ILogger<ItemViewModelService>> _mockLogger;
        private ItemViewModelService _itemViewModelService;
        private Mock<IItemRepository> _mockItemRepo;

        [SetUp]
        public void SetUp()
        {
            var profile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            _mapper = new Mapper(configuration);

            _mockLogger = new Mock<ILogger<ItemViewModelService>>();

            _mockItemRepo = new Mock<IItemRepository>();

            _itemViewModelService = new ItemViewModelService(_mockLogger.Object, _mockItemRepo.Object, _mapper);
        }

        [Test]
        public void GetItems_NoItems_ReturnEmpty()
        {
            _mockItemRepo.Setup(r => r.GetAll()).Returns(new List<Item>());

            var result = _itemViewModelService.GetItems();

            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetItems_HasItems_ReturnAllItems()
        {
            _mockItemRepo.Setup(r => r.GetAll()).Returns(new List<Item>
            {
                new Item{Id = 1, Name = "Item 1", Description = "Desc 1"},
                new Item{Id = 2, Name = "Item 2", Description = "Desc 2"}
            });

            var result = _itemViewModelService.GetItems();

            Assert.That(result, Is.TypeOf<List<ItemViewModel>>());
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetItem_HasItemRequested_ReturnRespectiveItem()
        {
            _mockItemRepo.Setup(r => r.GetSingleBySpec(It.IsAny<ItemDetailsSpecification>())).Returns(
                new Item { Id = 1, Name = "Item 1", Description = "Desc 1" }
                );

            var result = _itemViewModelService.GetItem(1);

            Assert.That(result, Is.TypeOf<ItemViewModel>());
            Assert.That(result.Name, Is.EqualTo("Item 1"));
        }

        [Test]
        public void GetItem_RequestedItemNotAvailable_ReturnNull()
        {
            _mockItemRepo.Setup(r => r.GetSingleBySpec(It.IsAny<ItemDetailsSpecification>())).Returns((Item)null);

            var result = _itemViewModelService.GetItem(2);

            Assert.That(result, Is.EqualTo(null));
        }
    }
}
