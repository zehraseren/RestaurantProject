using SignalR.CommonLayer.Enums;

namespace SignalR.DtoLayer.NotificationDtos
{
    public class CreateNotificationDto
    {
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public ReadStatus Status { get; set; }
    }
}
