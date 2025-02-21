using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.CommonLayer.Enums;
using SignalR.EntityLayer.Concrete;
using SignalR.DtoLayer.CategoryDtos;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            return Ok(_mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll()));
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            return Ok(_mapper.Map<GetCategoryDto>(_categoryService.TGetById(id)));
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_categoryService.TCategoryCount());
        }

        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            return Ok(_categoryService.TActiveCategoryCount());
        }

        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            return Ok(_categoryService.TPassiveCategoryCount());
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto ccdto)
        {
            _categoryService.TAdd(_mapper.Map<Category>(ccdto));
            return Ok("Kategori başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(_categoryService.TGetById(id));
            return Ok("Kategori başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto ucdto)
        {
            _categoryService.TUpdate(_mapper.Map<Category>(ucdto));
            return Ok("Kategori başarıyla güncellendi.");
        }
    }
}
