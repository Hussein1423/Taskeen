namespace PresentationLayer.Admins
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTipUsers = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlHomeDash = new System.Windows.Forms.Panel();
            this.lvNotificatinos = new System.Windows.Forms.ListView();
            this.colUsers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMessages = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlUsers = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNotifications = new System.Windows.Forms.Label();
            this.pnlActiveTasks = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbltdyNotifications = new System.Windows.Forms.Label();
            this.pnlSuccessTasks = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSuccessTasks = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvUsers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLeaders = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMembers = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAdmins = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lblUsers = new System.Windows.Forms.Label();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelMain.SuspendLayout();
            this.pnlHomeDash.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlUsers.SuspendLayout();
            this.pnlActiveTasks.SuspendLayout();
            this.pnlSuccessTasks.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTipUsers
            // 
            this.toolTipUsers.ToolTipTitle = "Spreate Users:";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Controls.Add(this.pnlHomeDash);
            this.panelMain.Controls.Add(this.btnNext);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1230, 577);
            this.panelMain.TabIndex = 5;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(246, 519);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(206, 46);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // pnlHomeDash
            // 
            this.pnlHomeDash.Controls.Add(this.lvNotificatinos);
            this.pnlHomeDash.Controls.Add(this.pnlUsers);
            this.pnlHomeDash.Controls.Add(this.flowLayoutPanel1);
            this.pnlHomeDash.Location = new System.Drawing.Point(79, 38);
            this.pnlHomeDash.Name = "pnlHomeDash";
            this.pnlHomeDash.Size = new System.Drawing.Size(565, 458);
            this.pnlHomeDash.TabIndex = 8;
            // 
            // lvNotificatinos
            // 
            this.lvNotificatinos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colUsers,
            this.colMessages,
            this.colRead,
            this.colDate});
            this.lvNotificatinos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvNotificatinos.HideSelection = false;
            this.lvNotificatinos.Location = new System.Drawing.Point(3, 257);
            this.lvNotificatinos.Name = "lvNotificatinos";
            this.lvNotificatinos.Size = new System.Drawing.Size(562, 201);
            this.lvNotificatinos.TabIndex = 10;
            this.lvNotificatinos.UseCompatibleStateImageBehavior = false;
            this.lvNotificatinos.View = System.Windows.Forms.View.Details;
            // 
            // colUsers
            // 
            this.colUsers.Text = "User";
            this.colUsers.Width = 100;
            // 
            // colMessages
            // 
            this.colMessages.Text = "Message";
            this.colMessages.Width = 200;
            // 
            // colRead
            // 
            this.colRead.Text = "IsRead";
            this.colRead.Width = 80;
            // 
            // colDate
            // 
            this.colDate.Text = "CreatedAt";
            this.colDate.Width = 100;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlActiveTasks);
            this.flowLayoutPanel1.Controls.Add(this.pnlSuccessTasks);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(43, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(487, 251);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // pnlUsers
            // 
            this.pnlUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlUsers.Controls.Add(this.label1);
            this.pnlUsers.Controls.Add(this.lblNotifications);
            this.pnlUsers.ForeColor = System.Drawing.Color.White;
            this.pnlUsers.Location = new System.Drawing.Point(43, 133);
            this.pnlUsers.Margin = new System.Windows.Forms.Padding(10);
            this.pnlUsers.Name = "pnlUsers";
            this.pnlUsers.Padding = new System.Windows.Forms.Padding(10);
            this.pnlUsers.Size = new System.Drawing.Size(473, 100);
            this.pnlUsers.TabIndex = 0;
            this.toolTipUsers.SetToolTip(this.pnlUsers, "\r\n");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Notifications";
            // 
            // lblNotifications
            // 
            this.lblNotifications.AutoSize = true;
            this.lblNotifications.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotifications.Location = new System.Drawing.Point(184, 10);
            this.lblNotifications.Name = "lblNotifications";
            this.lblNotifications.Size = new System.Drawing.Size(113, 43);
            this.lblNotifications.TabIndex = 0;
            this.lblNotifications.Text = "Count";
            // 
            // pnlActiveTasks
            // 
            this.pnlActiveTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlActiveTasks.Controls.Add(this.label2);
            this.pnlActiveTasks.Controls.Add(this.lbltdyNotifications);
            this.pnlActiveTasks.ForeColor = System.Drawing.Color.White;
            this.pnlActiveTasks.Location = new System.Drawing.Point(10, 10);
            this.pnlActiveTasks.Margin = new System.Windows.Forms.Padding(10);
            this.pnlActiveTasks.Name = "pnlActiveTasks";
            this.pnlActiveTasks.Padding = new System.Windows.Forms.Padding(10);
            this.pnlActiveTasks.Size = new System.Drawing.Size(231, 100);
            this.pnlActiveTasks.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Today Notifications";
            // 
            // lbltdyNotifications
            // 
            this.lbltdyNotifications.AutoSize = true;
            this.lbltdyNotifications.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltdyNotifications.Location = new System.Drawing.Point(30, 10);
            this.lbltdyNotifications.Name = "lbltdyNotifications";
            this.lbltdyNotifications.Size = new System.Drawing.Size(113, 43);
            this.lbltdyNotifications.TabIndex = 0;
            this.lbltdyNotifications.Text = "Count";
            // 
            // pnlSuccessTasks
            // 
            this.pnlSuccessTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.pnlSuccessTasks.Controls.Add(this.label4);
            this.pnlSuccessTasks.Controls.Add(this.lblSuccessTasks);
            this.pnlSuccessTasks.ForeColor = System.Drawing.Color.White;
            this.pnlSuccessTasks.Location = new System.Drawing.Point(261, 10);
            this.pnlSuccessTasks.Margin = new System.Windows.Forms.Padding(10);
            this.pnlSuccessTasks.Name = "pnlSuccessTasks";
            this.pnlSuccessTasks.Padding = new System.Windows.Forms.Padding(10);
            this.pnlSuccessTasks.Size = new System.Drawing.Size(212, 100);
            this.pnlSuccessTasks.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 29);
            this.label4.TabIndex = 1;
            this.label4.Text = "Read Notifications";
            // 
            // lblSuccessTasks
            // 
            this.lblSuccessTasks.AutoSize = true;
            this.lblSuccessTasks.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuccessTasks.Location = new System.Drawing.Point(30, 10);
            this.lblSuccessTasks.Name = "lblSuccessTasks";
            this.lblSuccessTasks.Size = new System.Drawing.Size(113, 43);
            this.lblSuccessTasks.TabIndex = 0;
            this.lblSuccessTasks.Text = "Count";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvUsers);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Location = new System.Drawing.Point(665, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 458);
            this.panel1.TabIndex = 11;
            // 
            // lvUsers
            // 
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvUsers.HideSelection = false;
            this.lvUsers.Location = new System.Drawing.Point(3, 257);
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(562, 201);
            this.lvUsers.TabIndex = 10;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "User";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Message";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "IsRead";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "CreatedAt";
            this.columnHeader4.Width = 100;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Controls.Add(this.panel4);
            this.flowLayoutPanel2.Controls.Add(this.panel5);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(43, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(446, 251);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblLeaders);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 0;
            this.toolTipUsers.SetToolTip(this.panel2, "\r\n");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Laders";
            // 
            // lblLeaders
            // 
            this.lblLeaders.AutoSize = true;
            this.lblLeaders.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaders.Location = new System.Drawing.Point(30, 10);
            this.lblLeaders.Name = "lblLeaders";
            this.lblLeaders.Size = new System.Drawing.Size(113, 43);
            this.lblLeaders.TabIndex = 0;
            this.lblLeaders.Text = "Count";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lblMembers);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(230, 10);
            this.panel3.Margin = new System.Windows.Forms.Padding(10);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(38, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 29);
            this.label7.TabIndex = 1;
            this.label7.Text = "Members";
            // 
            // lblMembers
            // 
            this.lblMembers.AutoSize = true;
            this.lblMembers.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembers.Location = new System.Drawing.Point(30, 10);
            this.lblMembers.Name = "lblMembers";
            this.lblMembers.Size = new System.Drawing.Size(113, 43);
            this.lblMembers.TabIndex = 0;
            this.lblMembers.Text = "Count";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.lblAdmins);
            this.panel4.ForeColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(10, 130);
            this.panel4.Margin = new System.Windows.Forms.Padding(10);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(10);
            this.panel4.Size = new System.Drawing.Size(200, 100);
            this.panel4.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(46, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 29);
            this.label9.TabIndex = 1;
            this.label9.Text = "Admins";
            // 
            // lblAdmins
            // 
            this.lblAdmins.AutoSize = true;
            this.lblAdmins.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdmins.Location = new System.Drawing.Point(30, 10);
            this.lblAdmins.Name = "lblAdmins";
            this.lblAdmins.Size = new System.Drawing.Size(113, 43);
            this.lblAdmins.TabIndex = 0;
            this.lblAdmins.Text = "Count";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.lblUsers);
            this.panel5.ForeColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(230, 130);
            this.panel5.Margin = new System.Windows.Forms.Padding(10);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(10);
            this.panel5.Size = new System.Drawing.Size(200, 100);
            this.panel5.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(51, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 29);
            this.label11.TabIndex = 1;
            this.label11.Text = "Users";
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsers.Location = new System.Drawing.Point(30, 10);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(113, 43);
            this.lblUsers.TabIndex = 0;
            this.lblUsers.Text = "Count";
            // 
            // colId
            // 
            this.colId.Text = "ID";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 577);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dashboard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panelMain.ResumeLayout(false);
            this.pnlHomeDash.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlUsers.ResumeLayout(false);
            this.pnlUsers.PerformLayout();
            this.pnlActiveTasks.ResumeLayout(false);
            this.pnlActiveTasks.PerformLayout();
            this.pnlSuccessTasks.ResumeLayout(false);
            this.pnlSuccessTasks.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTipUsers;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel pnlHomeDash;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ListView lvNotificatinos;
        private System.Windows.Forms.ColumnHeader colUsers;
        private System.Windows.Forms.ColumnHeader colMessages;
        private System.Windows.Forms.ColumnHeader colRead;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNotifications;
        private System.Windows.Forms.Panel pnlActiveTasks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbltdyNotifications;
        private System.Windows.Forms.Panel pnlSuccessTasks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSuccessTasks;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLeaders;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMembers;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblAdmins;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.ColumnHeader colId;
    }
}