using SignalR.CommonLayer.Enums;

namespace SignalR.WebUI.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public AvailableStatus CategoryStatus { get; set; }
    }
}
