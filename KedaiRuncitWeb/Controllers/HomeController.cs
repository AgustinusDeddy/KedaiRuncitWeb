using KedaiRuncitWeb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KedaiRuncitWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemViewModelService _itemViewModelService;

        public HomeController(ILogger<HomeController> logger, IItemViewModelService itemViewModelService)
        {
            _logger = logger;
            _itemViewModelService = itemViewModelService;
        }

        public IActionResult Index()
        {
            _logger.LogTrace("Getting all items");

            var items = _itemViewModelService.GetItems();
            return View(items);
        }
    }
}