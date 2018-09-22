using System.Collections.Generic;
using KedaiRuncitWeb.Interfaces;
using KedaiRuncitWeb.ViewModels;
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
            var items = _itemViewModelService.GetItems();
            return View(items);
        }
    }
}