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
            var values = _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto cadto)
        {
            About about = new About()
            {
                Title = cadto.Title,
                Description = cadto.Description,
                ImageUrl = cadto.ImageUrl,
            };
            _aboutService.TAdd(about);
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
            About about = new About()
            {
                AboutId = uadto.AboutId,
                Title = uadto.Title,
                Description = uadto.Description,
                ImageUrl = uadto.ImageUrl,
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımda kısmı başarıyla güncellendi.");
        }
    }
}
