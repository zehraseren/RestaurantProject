﻿using SignalR.CommonLayer.Enums;

namespace SignalR.WebUI.Dtos.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public ReadStatus Status { get; set; }
    }
}
