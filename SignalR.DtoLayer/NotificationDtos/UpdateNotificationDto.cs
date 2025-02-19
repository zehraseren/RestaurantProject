using SignalR.CommonLayer.Enums;

namespace SignalR.DtoLayer.NotificationDtos
{
    public class UpdateNotificationDto
    {
        public int NotificationId { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public ReadStatus Status { get; set; }
    }
}
