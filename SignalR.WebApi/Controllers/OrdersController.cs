using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.WebApi.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.TTotalOrderCount());
        }

        [HttpGet("TotalActiveOrderCount")]
        public IActionResult TotalActiveOrderCount()
        {
            return Ok(_orderService.TTotalActiveOrderCount());
        }

        [HttpGet("LastOrderTotalPrice")]
        public IActionResult LastOrderTotalPrice()
        {
            return Ok(_orderService.TLastOrderTotalPrice());
        }
    }
}
