using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskeenLogicLayer.Helpers
{
    public static class RegistryHelper
    {
        private const string RegistryKeyPath = @"SOFTWARE\TaskeenApp";

        public static void SaveCredentials(string username, string encruptedPassword)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryKeyPath))
            {
                key.SetValue("Username", username);
                key.SetValue("encruptedPassword", encruptedPassword);
            }
        }

        public static (string Username, string encruptedPassword) GetCredentials()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
            {
                if (key == null) return (null, null);

                var username = key.GetValue("Username") as string;
                var encruptedPassword = key.GetValue("encruptedPassword") as string;
                return (username, encruptedPassword);
            }
        }

        public static void ClearCredentials()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, writable: true))
            {
                if (key != null)
                {
                    key.DeleteValue("Username", false);
                    key.DeleteValue("encruptedPassword", false);
                }
            }
        }
    }
}
