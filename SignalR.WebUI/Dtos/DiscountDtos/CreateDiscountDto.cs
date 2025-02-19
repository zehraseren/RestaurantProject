using SignalR.CommonLayer.Enums;

namespace SignalR.WebUI.Dtos.DiscountDtos
{
    public class CreateDiscountDto
    {
        public string Title { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public AvailableStatus Status { get; set; }
    }
}
