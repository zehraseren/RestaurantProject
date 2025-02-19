using SignalR.CommonLayer.Enums;

namespace SignalR.EntityLayer.Concrete
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public AvailableStatus Status { get; set; }
    }
}
