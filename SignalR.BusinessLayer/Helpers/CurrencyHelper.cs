using System.Globalization;

namespace SignalR.BusinessLayer.Helpers
{
    public static class CurrencyHelper
    {
        public static string ToTurkishLira(this decimal value)
        {
            return value.ToString("C2", new CultureInfo("tr-TR"));
        }
    }
}
