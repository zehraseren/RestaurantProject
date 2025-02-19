using SignalR.CommonLayer.Enums;

namespace SignalR.EntityLayer.Concrete
{
    public class MenuTable
    {
        public int MenuTableId { get; set; }
        public string Name { get; set; }
        public MenuTableStatus Status { get; set; }
        public List<Basket> Baskets { get; set; }
    }
}
