using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskeenLogicLayer.DTOs;

namespace TaskeenLogicLayer.Helpers
{
    public static class CurrentUserSession
    {
        public static int? UserId { get; private set; }
        public static string UserName { get; private set; }
        public static string Email { get; private set; }
        public static string Role { get;  private set; }

        public static void SetUser(int userId, string userName, string email, string role = null)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            Role = role;
        }

        public static void Clear()
        {
            UserId = null;
            UserName = null;
            Email = null;
            Role = null;
        }


        public static bool IsLoggedIn()
        {
            return UserId.HasValue;
        }
    }
}
