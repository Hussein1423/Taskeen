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

        Dashboard dashboard = new Dashboard();
        ManageMembers manageMembers = new ManageMembers();
        ManageLaders manageLaders = new ManageLaders();
        ManageTasks manageTasks = new ManageTasks();
        MyTasks myTasks = new MyTasks();
        Notifications notifications = new Notifications();

        public AdminHome()
        {
            InitializeComponent();
            OpenChildForm(dashboard);

        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(dashboard);
        }

        private void manageMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(manageMembers);
        }

        private void manageLadderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(manageLaders);
        }

        private void manageTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(manageTasks);
        }

        private void myTasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(myTasks);
        }

        private void notificationesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(notifications);
        }

       
    }
}
