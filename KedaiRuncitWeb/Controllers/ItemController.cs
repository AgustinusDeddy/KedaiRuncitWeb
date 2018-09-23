using System;
using KedaiRuncitWeb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KedaiRuncitWeb.Controllers
{
    public class ItemController : Controller
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemViewModelService _itemViewModelService;

        public ItemController(ILogger<ItemController> logger, IItemViewModelService itemViewModelService)
        {
            _logger = logger;
            _itemViewModelService = itemViewModelService;
        }

        public IActionResult Detail(int id)
        {
            _logger.LogTrace("Get detail for item id : " + id);

            try
            {              
                var item = _itemViewModelService.GetItem(id);

                return View(item);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }          
        }
    }
}