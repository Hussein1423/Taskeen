using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresentationLayer.Admins
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            toolTipUsers.AutoPopDelay = 5000;
            toolTipUsers.InitialDelay = 200;
            toolTipUsers.ReshowDelay = 100;
            toolTipUsers.ShowAlways = true;
            toolTipUsers.SetToolTip(pnlUsers,"users");
            lvNotificatinos.Items.Add("🟢 تم إضافة مهمة جديدة بنجاح");
            lvNotificatinos.Items.Add("🔵 تم تسجيل دخول من قبل أحمد");
            lvNotificatinos.Items.Add("🔴 انتهت المهلة النهائية لمهمة اليوم");
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
