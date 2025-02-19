using SignalR.CommonLayer.Enums;

namespace SignalR.DtoLayer.MenuTableDtos
{
    public class UpdateMenuTableDto
    {
        public int MenuTableId { get; set; }
        public string Name { get; set; }
        public MenuTableStatus Status { get; set; }
    }
}
