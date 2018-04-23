using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PechShop.Heplers
{
    public struct NovosibirskTime
    {
        private static readonly string _novosibirskTimeZoneId = "Eastern Standard Time";

        public static DateTime GetCurrent()
        {
            var easternTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(_novosibirskTimeZoneId);

            var currentTime = DateTime.Now;
            var dateTimeWithZone = new DateTimeWithZone(currentTime, easternTimeZoneInfo);

            return dateTimeWithZone.LocalTime;
        }
    }
}
