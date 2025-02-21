using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.CommonLayer.Enums;
using SignalR.EntityLayer.Concrete;
using SignalR.DtoLayer.DiscountDtos;
using SignalR.BusinessLayer.Abstract;
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
            return Ok(_mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll()));
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            return Ok(_mapper.Map<GetDiscountDto>(_discountService.TGetById(id)));
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto cddto)
        {
            _discountService.TAdd(_mapper.Map<Discount>(cddto));
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
            _discountService.TUpdate(_mapper.Map<Discount>(uddto));
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
