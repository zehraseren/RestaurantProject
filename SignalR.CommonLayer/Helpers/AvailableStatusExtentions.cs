using SignalR.CommonLayer.Enums;

namespace SignalR.CommonLayer.Helpers
{
    public static class AvailableStatusExtentions
    {
        public static string GetAvailableStatusString(this AvailableStatus status)
        {
            return status switch
            {
                AvailableStatus.Available => "Aktif",
                AvailableStatus.Unavailable => "Pasif",
                _ => "Bilinmiyor",
            };
        }
    }
}
