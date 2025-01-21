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
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediasController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _socialMediaService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto csmdto)
        {
            SocialMedia socialMedia = new SocialMedia()
            {
                Title = csmdto.Title,
                Url = csmdto.Url,
                Icon = csmdto.Icon,
            };
            _socialMediaService.TAdd(socialMedia);
            return Ok("Sosyal medya başarıyla eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal medya başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto usmdto)
        {
            SocialMedia SocialMedia = new SocialMedia()
            {
                SocialMediaId = usmdto.SocialMediaId,
                Title = usmdto.Title,
                Url = usmdto.Url,
                Icon = usmdto.Icon,
            };
            _socialMediaService.TUpdate(SocialMedia);
            return Ok("Sosyal medya başarıyla güncellendi.");
        }

        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            return Ok(value);
        }
    }
}
