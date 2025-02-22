﻿namespace SignalR.WebUI.Dtos.RapidApiDtos
{
    public class RootTastyApiDto
    {
        public List<ResultTastyApiDto> Results { get; set; }
    }

    public class ResultTastyApiDto
    {
        public string name { get; set; }
        public string original_video_url { get; set; }
        public int total_time_minutes { get; set; }
        public string thumbnail_url { get; set; }
    }
}
