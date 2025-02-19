using SignalR.DtoLayer.BookingDtos;
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

        public static int clientCount { get; set; } = 0;

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

        public async Task GetBookingStatusList()
        {
            var approvedBookings = _bookingService.TGetBookingStatusApproved();
            var receivedBookings = _bookingService.TGetBookingStatusReceived();
            var cancelledBookings = _bookingService.TGetBookingStatusCanceled();

            await Clients.All.SendAsync("ReceiveApprovedBookings", approvedBookings);
            await Clients.All.SendAsync("ReceiveReceivedBookings", receivedBookings);
            await Clients.All.SendAsync("ReceiveCancelledBookings", cancelledBookings);
        }

        public async Task SendNotification()
        {
            var value = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

            var notificationListByFalse = _notificationService.TGetAllNotificationsByFalse();
            await Clients.All.SendAsync("ReceiveNotificationListByFalse", notificationListByFalse);
        }

        public async Task GetMenuTableStatus()
        {
            var value = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
