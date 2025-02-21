using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.AboutDtos;
using SignalR.EntityLayer.Concrete;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService aboutService, IMapper mapper)
        {
            _mapper = mapper;
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            return Ok(_mapper.Map<List<ResultAboutDto>>(_aboutService.TGetListAll()));
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            return Ok(_mapper.Map<GetAboutDto>(_aboutService.TGetById(id)));
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto cadto)
        {
            _aboutService.TAdd(_mapper.Map<About>(cadto));
            return Ok("Hakkımda kısmı başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda kısmı başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto uadto)
        {
            _aboutService.TUpdate(_mapper.Map<About>(uadto));
            return Ok("Hakkımda kısmı başarıyla güncellendi.");
        }
    }
}
