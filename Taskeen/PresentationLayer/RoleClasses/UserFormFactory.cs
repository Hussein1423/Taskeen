using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.RoleClasses;

namespace PresentationLayer.RoleClasses
{
    public static class UserFormFactory
    {
        private static readonly Dictionary<string, IUserForm> userForms = new Dictionary<string, IUserForm>
        {
    { "Admin", new AdminFormOpener() },
    { "Member", new MemberFormOpener() },
    { "TeamLeader", new LadderFormOpener() }
        };




        public static IUserForm GetFormByRole(string role)
        {
            return userForms.TryGetValue(role, out IUserForm form) ? form : null;
        }
    }

}
