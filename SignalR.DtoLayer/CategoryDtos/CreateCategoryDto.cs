using SignalR.CommonLayer.Enums;

namespace SignalR.DtoLayer.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public AvailableStatus CategoryStatus { get; set; }
    }
}
