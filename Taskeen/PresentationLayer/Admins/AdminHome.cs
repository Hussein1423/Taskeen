using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Admins
{
    public partial class AdminHome : Form
    {
        private void OpenChildForm(Form childForm)
        {
            panelContainer.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelContainer.Controls.Add(childForm);
            childForm.Show();
        }

        public AdminHome()
        {
            InitializeComponent();
            Dashboard dashboard = new Dashboard();
            OpenChildForm(dashboard);

        }

      
    }
}
