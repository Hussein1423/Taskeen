using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Admins;

namespace PresentationLayer.RoleClasses
{
    public class AdminFormOpener : IUserForm
    {
        public void Show()
        {
            var form = new AdminHome();
            form.Show();
        }
    }

}
