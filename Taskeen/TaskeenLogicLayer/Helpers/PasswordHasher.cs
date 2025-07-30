using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TaskeenLogicLayer.Helpers
{
    public static class PasswordHasher
    {
        // تُستخدم لتوليد كلمة مرور مشفّرة
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // تتحقق من تطابق كلمة المرور مع التجزئة المخزنة
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            var hashOfInput = HashPassword(enteredPassword);
            return string.Equals(hashOfInput, storedHash, StringComparison.Ordinal);
        }
    }
}
