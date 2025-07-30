using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskeenLogicLayer.Helpers
{
    public static class DateUtils
    {
        // 1️⃣ التأكد من أن تاريخ الاستحقاق لم يمضِ عليه وقت سلبي
        public static bool IsDueDateValid(DateTime createdDate,DateTime dueDate)
        {
            return dueDate > createdDate;
        }

        public static int GetTimeSpanValue(DateTime from, DateTime to)
        {
            var span = to - from;
            if (span.TotalSeconds < 0)
                span = from - to;

            if (span.TotalSeconds < 60)
                return (int)span.TotalSeconds;
            if (span.TotalMinutes < 60)
                return (int)span.TotalMinutes;
            if (span.TotalHours < 24)
                return (int)span.TotalHours;
            if (span.TotalDays < 30)
                return (int)span.TotalDays;
            if (span.TotalDays < 365)
                return (int)(span.TotalDays / 30);

            return (int)(span.TotalDays / 365);
        }

        public static string GetTimeSpanUnit(DateTime from, DateTime to)
        {
            var span = to - from;
            if (span.TotalSeconds < 0)
                span = from - to;

            if (span.TotalSeconds < 60)
                return "seconds";
            if (span.TotalMinutes < 60)
                return "minutes";
            if (span.TotalHours < 24)
                return "hours";
            if (span.TotalDays < 30)
                return "days";
            if (span.TotalDays < 365)
                return "months";

            return "years";
        }

        public static string GetTimeSpanDescription(DateTime from, DateTime to)
        {
            return $"{GetTimeSpanValue(from, to)} {GetTimeSpanUnit(from, to)}";
        }
    }
}
