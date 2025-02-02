using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.SliderDtos;
using SignalR.EntityLayer.Concrete;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISliderService _sliderService;

        public SlidersController(IMapper mapper, ISliderService sliderService)
        {
            _mapper = mapper;
            _sliderService = sliderService;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto csdto)
        {
            Slider Slider = new Slider()
            {
                Title1 = csdto.Title1,
                Title2 = csdto.Title2,
                Title3 = csdto.Title3,
                Description1 = csdto.Description1,
                Description2 = csdto.Description2,
                Description3 = csdto.Description3,
            };
            _sliderService.TAdd(Slider);
            return Ok("Slayt kısmı başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            _sliderService.TDelete(value);
            return Ok("Slayt kısmı başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto usdto)
        {
            Slider Slider = new Slider()
            {
                SliderId = usdto.SliderId,
                Title1 = usdto.Title1,
                Title2 = usdto.Title2,
                Title3 = usdto.Title3,
                Description1 = usdto.Description1,
                Description2 = usdto.Description2,
                Description3 = usdto.Description3,
            };
            _sliderService.TUpdate(Slider);
            return Ok("Slayt kısmı başarıyla güncellendi.");
        }
    }

}
