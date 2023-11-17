using System.Globalization;

namespace CommunalPayments.Helpers
{
    public static class RuntimeHelper
    {
        public static bool DebugMode
        {
            get
            {
#if DEBUG
                return true;
#else
                return false;
#endif
            }
        }

        public static readonly CultureInfo RussianCultureInfo = new CultureInfo("ru-RU");
    }
}
