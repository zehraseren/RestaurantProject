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
            return Ok(_mapper.Map<List<ResultProductDto>>(_productService.TGetListAll()));
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(_mapper.Map<GetProductDto>(_productService.TGetById(id)));
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }

        [HttpGet("ProductCountByCategoryNameDrink")]
        public IActionResult ProductCountByCategoryNameDrink()
        {
            return Ok(_productService.TProductCountByCategoryNameDrink());
        }

        [HttpGet("ProductCountByCategoryNameHamburger")]
        public IActionResult ProductCountByCategoryNameHamburger()
        {
            return Ok(_productService.TProductCountByCategoryNameHamburger());
        }

        [HttpGet("AvgProductPrice")]
        public IActionResult AvgProductPrice()
        {
            return Ok(_productService.TAvgProductPrice());
        }

        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            return Ok(_productService.TProductNameByMaxPrice());
        }

        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            return Ok(_productService.TProductNameByMinPrice());
        }

        [HttpGet("AvgProductPriceByHamburger")]
        public IActionResult AvgProductPriceByHamburger()
        {
            return Ok(_productService.TAvgProductPriceByHamburger());
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            return Ok(_mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories()));
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto cpdto)
        {
            _productService.TAdd(_mapper.Map<Product>(cpdto));
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
            _productService.TUpdate(_mapper.Map<Product>(updto));
            return Ok("Ürün başarıyla güncellendi.");
        }

        [HttpGet("GetLast9Products")]
        public IActionResult GetLast9Products()
        {
            return Ok(_mapper.Map<List<ResultProductDto>>(_productService.TGetLast9Products()));
        }
    }
}
