using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PechShop.Heplers
{
    public class DateTimeWithZone
    {
        private readonly DateTime _utcDateTime;
        private readonly TimeZoneInfo _timeZone;

        public DateTimeWithZone(DateTime dateTime, TimeZoneInfo timeZone)
        {
            var dateTimeUnspec = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
            _utcDateTime = TimeZoneInfo.ConvertTimeToUtc(dateTimeUnspec, timeZone);
            this._timeZone = timeZone;
        }

        public DateTime UniversalTime => _utcDateTime;

        public TimeZoneInfo TimeZone => _timeZone;

        public DateTime LocalTime => TimeZoneInfo.ConvertTime(_utcDateTime, _timeZone);
    }
}
