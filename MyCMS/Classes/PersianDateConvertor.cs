using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using Microsoft.Ajax.Utilities;

namespace MyCMS
{
    public static class PersianDateConvertor
    {
        public static string Toshamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" + pc.GetDayOfMonth(value).ToString("00"); 
        }
    }
}