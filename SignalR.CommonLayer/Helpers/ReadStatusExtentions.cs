using SignalR.CommonLayer.Enums;

namespace SignalR.CommonLayer.Helpers
{
    public static class ReadStatusExtentions
    {
        public static string GetReadStatusString(this ReadStatus status)
        {
            return status switch
            {
                ReadStatus.Read => "Okundu",
                ReadStatus.Unread => "Okunmadı",
                _ => "Bilinmiyor",
            };
        }
    }
}
