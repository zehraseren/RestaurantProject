using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Helpers;
using SignalR.DtoLayer.DashboardCountDtos;

namespace SignalR.WebApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMenuTableService _menuTableService;
        private readonly IMoneyCaseService _moneyCaseService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IMenuTableService menuTableService, IOrderService orderService, IMoneyCaseService moneyCaseService)
        {
            _orderService = orderService;
            _productService = productService;
            _categoryService = categoryService;
            _menuTableService = menuTableService;
            _moneyCaseService = moneyCaseService;
        }

        public async Task TakeDashboardCounts()
        {
            var dashboardCounts = new DashboardCountDto
            {
                CategoryCount = _categoryService.TCategoryCount(),
                ProductCount = _productService.TProductCount(),
                ActiveCategoryCount = _categoryService.TActiveCategoryCount(),
                PassiveCategoryCount = _categoryService.TPassiveCategoryCount(),
                ProductCountByCategoryNameHamburger = _productService.TProductCountByCategoryNameHamburger(),
                ProductCountByCategoryNameDrink = _productService.TProductCountByCategoryNameDrink(),
                AvgProductPrice = _productService.TAvgProductPrice().ToTurkishLira(),
                AvgProductPriceByHamburger = _productService.TAvgProductPriceByHamburger().ToTurkishLira(),
                ProductNameByMaxPrice = _productService.TProductNameByMaxPrice(),
                ProductNameByMinPrice = _productService.TProductNameByMinPrice(),
                MenuTableCount = _menuTableService.TMenuTableCount(),
                TotalActiveOrderCount = _orderService.TTotalActiveOrderCount(),
                LastOrderTotalPrice = _orderService.TLastOrderTotalPrice().ToTurkishLira(),
                TotalOrderCount = _orderService.TTotalOrderCount(),
                TotalDailyEarnings = _orderService.TTotalDailyEarnings().ToTurkishLira(),
                TotalMoneyCaseAmount = _moneyCaseService.TTotalMoneyCaseAmount().ToTurkishLira(),
            };

            await Clients.All.SendAsync("ReceiveDashboardCounts", dashboardCounts);
        }
    }
}
