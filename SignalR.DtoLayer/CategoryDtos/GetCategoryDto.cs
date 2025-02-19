using SignalR.CommonLayer.Enums;

namespace SignalR.DtoLayer.CategoryDtos
{
    public class GetCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public AvailableStatus CategoryStatus { get; set; }
    }
}
