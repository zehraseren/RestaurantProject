using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Concrete;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDtos;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediasController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _mapper = mapper;
            _socialMediaService = socialMediaService;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            return Ok(_mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll()));
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            return Ok(_mapper.Map<GetSocialMediaDto>(_socialMediaService.TGetById(id)));
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto csmdto)
        {
            _socialMediaService.TAdd(_mapper.Map<SocialMedia>(csmdto));
            return Ok("Sosyal medya başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal medya başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto usmdto)
        {
            _socialMediaService.TUpdate(_mapper.Map<SocialMedia>(usmdto));
            return Ok("Sosyal medya başarıyla güncellendi.");
        }
    }
}
