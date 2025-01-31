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
            var values = _mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto cmtdto)
        {
            MenuTable menuTable = new MenuTable()
            {
                Name = cmtdto.Name,
                Status = cmtdto.Status,
            };
            _menuTableService.TAdd(menuTable);
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
            MenuTable menuTable = new MenuTable()
            {
                MenuTableId = umtdto.MenuTableId,
                Name = umtdto.Name,
                Status = umtdto.Status,
            };
            _menuTableService.TUpdate(menuTable);
            return Ok("Masa başarıyla güncellendi.");
        }
    }
}
