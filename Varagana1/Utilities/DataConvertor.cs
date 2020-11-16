using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace Varagana1.Utilities
{
    public static class DataConvertor
    {
        public static string ToShamsi (this DateTime value)
        {
            PersianCalendar p = new PersianCalendar();
            return p.GetYear(value) + "/" + p.GetMonth(value).ToString("00") + "/" + p.GetDayOfMonth(value).ToString("00");
        }
    }
}