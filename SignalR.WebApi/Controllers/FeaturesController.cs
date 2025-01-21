using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.FeatureDtos;
using SignalR.EntityLayer.Concrete;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _featureService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto cfdto)
        {
            Feature feature = new Feature()
            {
                Title1 = cfdto.Title1,
                Description1 = cfdto.Description1,
                Title2 = cfdto.Title2,
                Description2 = cfdto.Description2,
                Title3 = cfdto.Title3,
                Description3 = cfdto.Description3,
            };
            _featureService.TAdd(feature);
            return Ok("Rezervasyon başarıyla eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            _featureService.TDelete(value);
            return Ok("Rezervasyon başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto ufdto)
        {
            Feature feature = new Feature()
            {
                FeatureId = ufdto.FeatureId,
                Title1 = ufdto.Title1,
                Description1 = ufdto.Description1,
                Title2 = ufdto.Title2,
                Description2 = ufdto.Description2,
                Title3 = ufdto.Title3,
                Description3 = ufdto.Description3,
            };
            _featureService.TUpdate(feature);
            return Ok("Rezervasyon başarıyla güncellendi.");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetById(id);
            return Ok(value);
        }
    }
}
