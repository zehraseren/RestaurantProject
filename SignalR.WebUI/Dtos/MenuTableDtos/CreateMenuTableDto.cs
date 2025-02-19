using SignalR.CommonLayer.Enums;

namespace SignalR.WebUI.Dtos.MenuTableDtos
{
    public class CreateMenuTableDto
    {
        public string Name { get; set; }
        public MenuTableStatus Status { get; set; }
    }
}
