using SignalR.CommonLayer.Enums;

namespace SignalR.DtoLayer.MessageDtos
{
    public class CreateMessageDto
    {
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageSendDate { get; set; }
        public ReadStatus Status { get; set; }
    }
}
