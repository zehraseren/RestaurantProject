using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Concrete;
using SignalR.DtoLayer.CategoryDtos;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto cadto)
        {
            Category category = new Category()
            {
                CategoryName = cadto.CategoryName,
                CategoryStatus = cadto.CategoryStatus,
            };
            _categoryService.TAdd(category);
            return Ok("Kategori başarıyla eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            _categoryService.TDelete(value);
            return Ok("Kategori başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto uadto)
        {
            Category category = new Category()
            {
                CategoryName = uadto.CategoryName,
                CategoryStatus = uadto.CategoryStatus,
            };
            _categoryService.TUpdate(category);
            return Ok("Kategori başarıyla güncellendi.");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }
    }
}
