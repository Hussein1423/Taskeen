using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Shared
{
    public static class enumRoles
    {
        public enum eRoles
        {
            Admin,
            Member,
            Ladership,
        }
        public static eRoles roles = eRoles.Member; // Default role
    }
}
