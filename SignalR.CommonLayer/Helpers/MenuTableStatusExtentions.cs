using SignalR.CommonLayer.Enums;

namespace SignalR.CommonLayer.Helpers
{
    public static class MenuTableStatusExtentions
    {
        public static string GetMenuTableStatusString(this MenuTableStatus status)
        {
            return status switch
            {
                MenuTableStatus.Full => "Dolu",
                MenuTableStatus.Empty => "Boş",
                _ => "Bilinmiyor",
            };
        }
    }
}
