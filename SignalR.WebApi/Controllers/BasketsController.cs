using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Concrete;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using SignalR.WebApi.Models;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBasketService _basketService;

        public BasketsController(IMapper mapper, IBasketService basketService)
        {
            _mapper = mapper;
            _basketService = basketService;
        }

        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();

            var values = context.Baskets
                .Include(x => x.Product)
                .Where(y => y.MenuTableId == id)
                .Select(z => new ResultBasketListWithProducts
                {
                    BasketId = z.BasketId,
                    Price = z.Price,
                    Count = z.Count,
                    TotalPrice = z.TotalPrice,
                    ProductId = z.ProductId,
                    MenuTableId = z.MenuTableId,
                    ProductName = z.Product.ProductName,
                }).ToList();
            return Ok(values);
        }

        [HttpGet]
        public ActionResult GetBasketByMenuTableId(int id)
        {
            return Ok(_mapper.Map<List<ResultBasketDto>>(_basketService.TGetBasketByMenuTableNumber(id)));
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto cbdto)
        {
            using var context = new SignalRContext();

            var existingIBasketItem = context.Baskets
                .FirstOrDefault(x => x.ProductId == cbdto.ProductId && x.MenuTableId == cbdto.MenuTableId);

            if (existingIBasketItem != null)
            {
                existingIBasketItem.Count += 1;
                existingIBasketItem.TotalPrice = existingIBasketItem.Count * existingIBasketItem.Price;
                _basketService.TUpdate(existingIBasketItem);
                return Ok();
            }
            else
            {
                var productPrice = context.Products
                    .Where(x => x.ProductId == cbdto.ProductId)
                    .Select(y => y.Price)
                    .FirstOrDefault();

                var newBasketItem = new Basket
                {
                    ProductId = cbdto.ProductId,
                    MenuTableId = cbdto.MenuTableId,
                    Count = 1,
                    Price = productPrice,
                    TotalPrice = cbdto.TotalPrice
                };

                _basketService.TAdd(newBasketItem);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Sepetteki seçilen ürün silindi.");
        }
    }
}
