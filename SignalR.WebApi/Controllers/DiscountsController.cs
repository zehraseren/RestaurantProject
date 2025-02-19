using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Concrete;
using SignalR.DtoLayer.DiscountDtos;
using SignalR.BusinessLayer.Abstract;
using SignalR.CommonLayer.Enums;
using SignalR.DataAccessLayer.Concrete;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService, IMapper mapper)
        {
            _mapper = mapper;
            _discountService = discountService;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto cddto)
        {
            Discount discount = new Discount()
            {
                Title = cddto.Title,
                Amount = cddto.Amount,
                Description = cddto.Description,
                ImageUrl = cddto.ImageUrl,
                Status = AvailableStatus.Unavailable,
            };
            _discountService.TAdd(discount);
            return Ok("Rezervasyon başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("Rezervasyon başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto uddto)
        {
            Discount discount = new Discount()
            {
                DiscountId = uddto.DiscountId,
                Title = uddto.Title,
                Amount = uddto.Amount,
                Description = uddto.Description,
                ImageUrl = uddto.ImageUrl,
                Status = AvailableStatus.Unavailable,
            };
            _discountService.TUpdate(discount);
            return Ok("Rezervasyon başarıyla güncellendi.");
        }

        [HttpGet("ChangeStatusToActive/{id}")]
        public IActionResult ChangeStatusToActive(int id)
        {
            _discountService.TChangeStatusToActive(id);
            return Ok("İndirim kodu aktifleştirildi.");
        }

        [HttpGet("ChangeStatusToPassive/{id}")]
        public IActionResult ChangeStatusToPassive(int id)
        {
            _discountService.TChangeStatusToPassive(id);
            return Ok("İndirim kodu pasifleştirildi.");
        }

        [HttpGet("GetDiscountListByStatusActive")]
        public IActionResult GetDiscountListByStatusActive()
        {
            var context = new SignalRContext();
            var values = context.Discounts.Where(x => x.Status == AvailableStatus.Available).ToList();
            return Ok(values);
        }
    }
}
