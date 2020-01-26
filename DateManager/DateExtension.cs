using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DateManager
{
    public static class DateExtension
    {
        /// <summary>
        /// Start of day. e.g (2020/01/24 12:00:00 AM)
        /// </summary>
        /// <param name="date"></param>
        /// <returns>DateTime</returns>
        public static DateTime StartOfDay(this DateTime date) => date.Date;

        /// <summary>
        /// End of day. e.g (2020/01/24 11:59:59 PM)
        /// </summary>
        /// <param name="date"></param>
        /// <returns>DateTime</returns>
        public static DateTime EndOfDay(this DateTime date) => date.Date.AddDays(1).AddTicks(-1);

        /// <summary>
        /// First Day Of Week e.g (2020/01/24 12:00:00 AM)
        /// </summary>
        /// <param name="date"></param>
        /// <returns>DateTime</returns>
        public static DateTime FirstDayOfWeek(this DateTime date)
        {
            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            return fdowDate;
        }

        /// <summary>
        /// Last Day Of Week e.g (2020/01/24 11:59:59 PM)
        /// </summary>
        /// <param name="date"></param>
        /// <returns>DateTime</returns>
        public static DateTime LastDayOfWeek(this DateTime date)
        {
            DateTime ldowDate = date.FirstDayOfWeek().AddDays(6);
            return ldowDate.EndOfDay();
        }

        /// <summary>
        /// Last Day Of Month e.g (2020/01/24 11:59:59 PM)
        /// </summary>
        /// <param name="date"></param>
        /// <returns>DateTime</returns>
        public static DateTime LastDayOfMonth(this DateTime date)
        {
            DateTime ss = new DateTime(date.Year, date.Month, 1);
            return ss.AddMonths(1).AddDays(-1).EndOfDay();
        }

        /// <summary>
        /// First Day Of Month e.g (2020/01/24 12:00:00 AM)
        /// </summary>
        /// <param name="date"></param>
        /// <returns>DateTime</returns>
        public static DateTime FirstDayOfMonth(this DateTime date) => new DateTime(date.Year, date.Month, 1);


        /// <summary>
        /// Last Day Of Year e.g (2020/01/24 11:59:59 PM)
        /// </summary>
        /// <param name="date"></param>
        /// <returns>DateTime</returns>
        public static DateTime LastDayOfYear(this DateTime date)
        {
            DateTime n = new DateTime(date.Year + 1, 1, 1);
            return n.AddDays(-1).EndOfDay();
        }

        /// <summary>
        /// First Day Of Year e.g (2020/01/24 12:00:00 AM)
        /// </summary>
        /// <param name="date"></param>
        /// <returns>DateTime</returns>
        public static DateTime FirstDayOfYear(this DateTime date) => new DateTime(date.Year, 1, 1);


        /// <summary>
        /// Check if date is in time range.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="timeRangeFrom"></param>
        /// <param name="timeRangeTo"></param>
        /// <returns>bool</returns>
        public static bool IsInTimeRange(this DateTime obj, DateTime timeRangeFrom, DateTime timeRangeTo)
        {
            TimeSpan time = obj.TimeOfDay, t1From = timeRangeFrom.TimeOfDay, t1To = timeRangeTo.TimeOfDay;

            // if the time from is smaller than the time to, just filter by range
            if (t1From <= t1To)
            {
                return time >= t1From && time <= t1To;
            }

            // time from is greater than time to so two time intervals have to be created: one {timeFrom-12AM) and another one {12AM to timeTo}
            TimeSpan t2From = TimeSpan.MinValue, t2To = t1To;
            t1To = TimeSpan.MaxValue;

            return (time >= t1From && time <= t1To) || (time >= t2From && time <= t2To);
        }

        /// <summary>
        /// Check if string is a date
        /// </summary>
        /// <param name="input"></param>
        /// <returns>tuple of boolean and date</returns>
        public static (bool, DateTime) IsDate(this string input)
        {
            var date = new DateTime();
            if (!string.IsNullOrEmpty(input))
            {
                return (DateTime.TryParse(input, out DateTime dt), dt);
            }
            else
            {
                return (false, date);
            }
        }

        /// <summary>
        /// Convert Date to short Date  ("yyyy-MM-dd")
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        public static string ShortDate(this DateTime input)
        {
            return input.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Convert Date to Long Date  ("yyyy-MM-dd HH:mm)
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        public static string LongDate(this DateTime input)
        {
            return input.ToString("yyyy-MM-dd HH:mm");
        }

        /// <summary>
        /// Check if object is empty
        /// </summary>
        /// <param name="me"></param>
        /// <returns>boolean</returns>
        public static bool IsNotNull(this object me)
        {
            if (me == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check if email is valid.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>boolean</returns>
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
    }
}
