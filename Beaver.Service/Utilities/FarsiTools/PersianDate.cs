using System;
using System.Globalization;

namespace Beaver.Service.Utilities.FarsiTools
{
    public class PersianDate
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date">Valid Fromat : yyyy/mm/dd</param>
        /// <param name="time">Valid Format : hh:mm:ss:millisec (Second & MilliSecond is optional)</param>
        public PersianDate(string date, string time = null)
        {
            if (string.IsNullOrEmpty(date))
                return;

            var dateArray = date.Split('/');
            if (dateArray.Length != 3)
                return;

            try
            {
                Year = Convert.ToInt32(dateArray[0]);
                Month = Convert.ToInt32(dateArray[1]);
                Day = Convert.ToInt32(dateArray[2]);
            }
            catch (Exception)
            {
                Year = 0;
                Month = 0;
                Day = 0;
            }

            if (time == null)
                return;

            var timeArray = time.Split(':');
            if (timeArray.Length < 2)
                return;

            try
            {
                Hour = Convert.ToInt32(timeArray[0]);
                Minute = Convert.ToInt32(timeArray[1]);

                if (timeArray.Length == 3)
                    Second = Convert.ToInt32(timeArray[2]);

                if (timeArray.Length == 4)
                    MilliSecond = Convert.ToInt32(timeArray[3]);
            }
            catch (Exception)
            {
                Hour = 0;
                Minute = 0;
                Second = 0;
                MilliSecond = 0;
            }
        }
        public PersianDate(int year, int month, int day, int hour = 0, int minute = 0, int second = 0, double millisecond = 0)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
            MilliSecond = millisecond;
        }


        public int Year { get; }
        public int Month { get; }
        public int Day { get; }
        public int Hour { get; }
        public int Minute { get; }
        public int Second { get; }
        public double MilliSecond { get; }

        public static implicit operator PersianDate(DateTime dateTime)
        {
            var persian = new PersianCalendar();
            var day = persian.GetDayOfMonth(dateTime);
            var month = persian.GetMonth(dateTime);
            var year = persian.GetYear(dateTime);
            var hour = persian.GetHour(dateTime);
            var min = persian.GetMinute(dateTime);
            var second = persian.GetSecond(dateTime);
            var milliSec = persian.GetMilliseconds(dateTime);
            return new PersianDate(year, month, day, hour, min, second, milliSec);
        }

        public static implicit operator DateTime(PersianDate persianDate)
        {
            var calendar = new PersianCalendar();
            var dateTime =
                calendar.ToDateTime(persianDate.Year, persianDate.Month, persianDate.Day, persianDate.Hour,
                    persianDate.Minute, persianDate.Second, (int)persianDate.MilliSecond);
            return dateTime;
        }


        public string ToStringDate(PersianDateFormat format = PersianDateFormat.YYYY_MM_DD, string seprator = "/")
        {
            switch (format)
            {
                case PersianDateFormat.YYYY_MM_DD:
                    return string.Format("{0}{1}{2}{1}{3}", Year, seprator, Month.ToString("00"), Day.ToString("00"));

                case PersianDateFormat.DD_MM_YYYY:
                    return string.Format("{0}{1}{2}{1}{3}", Day.ToString("00"), seprator, Month.ToString("00"), Year);

                case PersianDateFormat.YYYY_MonthName_DD:
                    return string.Format("{0}{1}{2}{1}{3}", Year, seprator, PersianDateTools.JalaliMonth(Month), Day.ToString("00"));

                case PersianDateFormat.DD_MonthName_YYYY:
                    return string.Format("{0}{1}{2}{1}{3}", Day.ToString("00"), seprator, PersianDateTools.JalaliMonth(Month), Year);
            }
            return null;
        }

        public string ToStringTime(PersianTimeFormat format = PersianTimeFormat.HH_MM, string seprator = ":")
        {
            switch (format)
            {
                case PersianTimeFormat.HH_MM:
                    return $"{Hour.ToString("00")}{seprator}{Minute.ToString("00")}";

                case PersianTimeFormat.HH_MM_SS:
                    return $"{Hour.ToString("00")}{seprator}{Minute.ToString("00")}{seprator}{Second.ToString("00")}";

                case PersianTimeFormat.HH_MM_SS_MilliSecond:
                    return
                        $"{Hour.ToString("00")}{seprator}{Minute.ToString("00")}{seprator}{Second.ToString("00")}{seprator}{MilliSecond}";
            }
            return null;
        }

        public string ToStringDateTime(
            PersianDateFormat dateFormat = PersianDateFormat.YYYY_MM_DD,
            string dateSeprator = "/",
            PersianTimeFormat timeFormat = PersianTimeFormat.HH_MM,
            string timeSeprator = ":")
        {
            return $"{ToStringDate(dateFormat, dateSeprator)} {ToStringTime(timeFormat, timeSeprator)}";
        }
    }

    public enum PersianDateFormat
    {
        YYYY_MM_DD,
        DD_MM_YYYY,
        YYYY_MonthName_DD,
        DD_MonthName_YYYY,
    }

    public enum PersianTimeFormat
    {
        HH_MM,
        HH_MM_SS,
        HH_MM_SS_MilliSecond,
    }

    public static class PersianDateTools
    {
        public static string[] JalaliMonths()
        {
            return new[]
            {
                "فروردین",
                "اردیبهشت",
                "خرداد",
                "تیر",
                "مرداد",
                "شهریور",
                "مهر",
                "آبان",
                "آذر",
                "دی",
                "بهمن",
                "اسفند"
            };
        }

        public static string JalaliMonth(int month)
        {
            if (0 < month && month < 13)
            {
                return JalaliMonths()[month - 1];
            }
            return null;
        }

        public static string PersianAgo(this DateTime date)
        {
            var days = Math.Floor((DateTime.Now - date).TotalDays);
            if (days >= 365)
            {
                return $"{(int) (days/365)} سال پیش";
            }

            if (days >= 30)
            {
                return $"{(int) (days/30)} ماه پیش";
            }

            if (days >= 7)
            {
                return $"{(int) (days/7)} هفته پیش";
            }

            if (days >= 1)
            {
                return $"{days} روز پیش";
            }

            var hours = Math.Floor((DateTime.Now - date).TotalHours);
            if (hours >= 1)
            {
                return $"{hours} ساعت پیش";
            }

            var minutes = Math.Floor((DateTime.Now - date).TotalMinutes);
            return minutes > 1 ? $"{minutes} دقیقه پیش" : "یک دقیقه پیش";
        }

        public static PersianDate ToPersianDate(this DateTime date)
        {
            return date;
        }
    }

}
