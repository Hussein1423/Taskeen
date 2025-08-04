using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.Laders;

namespace PresentationLayer.RoleClasses
{
    public class LadderFormOpener : IUserForm
    {
        public void Show()
        {
            var form = new LaderForm();
            form.Show();
        }
    }
}
