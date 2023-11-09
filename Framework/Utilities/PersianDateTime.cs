using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Utilities
{
    public static class PersianDateTime
    {
        public static string ToPersianCalendar(this DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            return $"{pc.GetYear(DateTime.Now)}_{pc.GetMonth(DateTime.Now)}_{pc.GetDayOfMonth(DateTime.Now)}_{pc.GetHour(DateTime.Now)}_{pc.GetMinute(DateTime.Now)}_{pc.GetSecond(DateTime.Now)}";

        }
    }
}
