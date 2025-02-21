using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Concrete;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDtos;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMenuTableService _menuTableService;

        public MenuTablesController(IMapper mapper, IMenuTableService menuTableService)
        {
            _mapper = mapper;
            _menuTableService = menuTableService;
        }

        [HttpGet]
        public IActionResult MenuTableList()
        {
            return Ok(_mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetListAll()));
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            return Ok(_mapper.Map<GetMenuTableDto>(_menuTableService.TGetById(id)));
        }

        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto cmtdto)
        {
            _menuTableService.TAdd(_mapper.Map<MenuTable>(cmtdto));
            return Ok("Masa başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            _menuTableService.TDelete(value);
            return Ok("Masa başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto umtdto)
        {
            _menuTableService.TUpdate(_mapper.Map<MenuTable>(umtdto));
            return Ok("Masa başarıyla güncellendi.");
        }

        [HttpGet("ChangeMenuTableStatusToTrue")]
        public IActionResult ChangeMenuTableStatusToTrue(int id)
        {
            _menuTableService.TChangeMenuTableStatusToTrue(id);
            return Ok("İşlem başarılı.");
        }

        [HttpGet("ChangeMenuTableStatusToFalse")]
        public IActionResult ChangeMenuTableStatusToFalse(int id)
        {
            _menuTableService.TChangeMenuTableStatusToFalse(id);
            return Ok("İşlem başarılı.");
        }
    }
}
