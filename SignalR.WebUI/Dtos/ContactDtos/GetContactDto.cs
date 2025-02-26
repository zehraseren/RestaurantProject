﻿namespace SignalR.WebUI.Dtos.ContactDtos
{
    public class GetContactDto
    {
        public int ContactId { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string FooterDescription { get; set; }
        public string OpenDays { get; set; }
        public string OpenDaysDescription { get; set; }
        public string OpenHours { get; set; }
    }
}
