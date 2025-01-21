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
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetListAll();
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
            };
            _productService.TAdd(product);
            return Ok("Rezervasyon başarıyla eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Rezervasyon başarıyla silindi.");
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
            };
            _productService.TUpdate(product);
            return Ok("Rezervasyon başarıyla güncellendi.");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }
    }
}
