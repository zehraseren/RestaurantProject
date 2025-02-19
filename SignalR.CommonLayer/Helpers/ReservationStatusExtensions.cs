using SignalR.CommonLayer.Enums;

namespace SignalR.CommonLayer.Helpers
{
    public static class ReservationStatusExtensions
    {
        public static string GetReservationStatusString(this ReservationStatus status)
        {
            return status switch
            {
                ReservationStatus.Received => "Rezervasyon Alındı",
                ReservationStatus.Approved => "Rezervasyon Onaylandı",
                ReservationStatus.Cancelled => "Rezervasyon İptal Edildi",
                _ => "Bilinmiyor",
            };
        }
    }
}
