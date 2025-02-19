using SignalR.CommonLayer.Enums;

namespace SignalR.WebUI.Dtos.MenuTableDtos
{
    public class UpdateMenuTableDto
    {
        public int MenuTableId { get; set; }
        public string Name { get; set; }
        public MenuTableStatus Status { get; set; }
    }
}
