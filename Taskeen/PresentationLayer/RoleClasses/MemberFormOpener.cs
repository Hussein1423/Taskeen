using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Members;

namespace PresentationLayer.RoleClasses
{
    public class MemberFormOpener : IUserForm
    {
        public void Show()
        {
            var form = new MemberForm();
            form.Show();
        }
    }
}
