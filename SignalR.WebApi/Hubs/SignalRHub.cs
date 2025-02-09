using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Helpers;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DashboardCountDtos;
using SignalR.DtoLayer.GetProgressPercentageDtos;

namespace SignalR.WebApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IBookingService _bookingService;
        private readonly ICategoryService _categoryService;
        private readonly IMenuTableService _menuTableService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IBookingService bookingService, IMenuTableService menuTableService, IOrderService orderService, IMoneyCaseService moneyCaseService, INotificationService notificationService)
        {
            _orderService = orderService;
            _productService = productService;
            _bookingService = bookingService;
            _categoryService = categoryService;
            _menuTableService = menuTableService;
            _moneyCaseService = moneyCaseService;
            _notificationService = notificationService;
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

        public async Task GetProgressPercentage()
        {
            var getProgressPercentageDto = new GetProgressPercentageDto
            {
                TotalMoneyCaseAmount = _moneyCaseService.TTotalMoneyCaseAmount().ToTurkishLira(),
                TotalActiveOrderCount = _orderService.TTotalActiveOrderCount(),
                MenuTableCount = _menuTableService.TMenuTableCount(),
            };

            await Clients.All.SendAsync("ReceiveProgressPercentage", getProgressPercentageDto);
        }

        public async Task GetBookingList()
        {
            var getBookingList = _bookingService.TGetListAll();

            await Clients.All.SendAsync("ReceiveBookingList", getBookingList);
        }

        public async Task SendNotification()
        {
            var value = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

            var notificationListByFalse = _notificationService.TGetAllNotificationsByFalse();
            await Clients.All.SendAsync("ReceiveNotificationListByFalse", notificationListByFalse);
        }
    }
}
