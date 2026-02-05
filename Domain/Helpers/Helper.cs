using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Domain.Helpers
{
    static public class Helper
    {
        public static void logErrors(string message)
        {
            string source = "TaskeenApp";       // اسم التطبيق/المصدر
            string logName = "Application";     // اسم السجل (Application, System, أو Custom)

            try
            {
                // التحقق من وجود المصدر في Event Viewer
                if (!EventLog.SourceExists(source))
                {
                    EventLog.CreateEventSource(source, logName);
                }

                // كتابة الخطأ في Event Viewer
                EventLog.WriteEntry(source, message, EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                // إذا فشل التسجيل في Event Viewer، يمكن اختيار تسجيله في ملف نصي كخطة بديلة
                string fallbackPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errors_fallback.log");
                string log = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {ex.Message} - Original: {message}{Environment.NewLine}";
                File.AppendAllText(fallbackPath, log);
            }
        }
    }
}
