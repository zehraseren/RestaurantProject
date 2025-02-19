using SignalR.CommonLayer.Enums;

namespace SignalR.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public AvailableStatus CategoryStatus { get; set; }
        List<Product> Products { get; set; }
    }
}
