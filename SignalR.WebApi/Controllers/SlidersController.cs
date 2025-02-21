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
            return Ok(_mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll()));
        }

        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            return Ok(_mapper.Map<GetByIdSliderDto>(_sliderService.TGetById(id)));
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto csdto)
        {
            _sliderService.TAdd(_mapper.Map<Slider>(csdto));
            return Ok("Öne çıkan kısmı başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            _sliderService.TDelete(value);
            return Ok("Öne çıkan kısmı başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto usdto)
        {
            _sliderService.TUpdate(_mapper.Map<Slider>(usdto));
            return Ok("Öne çıkan kısmı başarıyla güncellendi.");
        }
    }

}
