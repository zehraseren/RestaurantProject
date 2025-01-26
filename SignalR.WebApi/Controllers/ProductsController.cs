using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.DtoLayer.ProductDtos;
using SignalR.EntityLayer.Concrete;
using SignalR.BusinessLayer.Abstract;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto cpdto)
        {
            Product product = new Product()
            {
                ProductName = cpdto.ProductName,
                Description = cpdto.Description,
                Price = cpdto.Price,
                ImageUrl = cpdto.ImageUrl,
                ProductStatus = cpdto.ProductStatus,
                CategoryId = cpdto.CategoryId,
            };
            _productService.TAdd(product);
            return Ok("Ürün başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Ürün başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updto)
        {
            Product product = new Product()
            {
                ProductId = updto.ProductId,
                ProductName = updto.ProductName,
                Description = updto.Description,
                Price = updto.Price,
                ImageUrl = updto.ImageUrl,
                ProductStatus = updto.ProductStatus,
                CategoryId = updto.CategoryId,
            };
            _productService.TUpdate(product);
            return Ok("Ürün başarıyla güncellendi.");
        }
    }
}
