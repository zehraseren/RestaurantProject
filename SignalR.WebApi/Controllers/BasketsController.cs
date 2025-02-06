using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.BasketDtos;
using SignalR.EntityLayer.Concrete;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

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

        [HttpGet]
        public ActionResult GetBasketByMenuTableId(int id)
        {
            return Ok(_mapper.Map<List<ResultBasketDto>>(_basketService.TGetBasketByMenuTableNumber(id)));
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto cbdto)
        {
            using var context = new SignalRContext();
            _basketService.TAdd(new Basket()
            {
                ProductId = cbdto.ProductId,
                MenuTableId = 3,
                Count = 1,
                Price = context.Products.Where(x => x.ProductId == cbdto.ProductId).Select(y => y.Price).FirstOrDefault(),
                TotalPrice = 0,
            });
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
