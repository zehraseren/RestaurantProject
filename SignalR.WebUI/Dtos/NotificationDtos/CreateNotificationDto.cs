using SignalR.CommonLayer.Enums;

namespace SignalR.WebUI.Dtos.NotificationDtos
{
    public class CreateNotificationDto
    {
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public ReadStatus Status { get; set; }
    }
}
