namespace DVLD_Project.Users.Controls
{
    partial class cntrlUserCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cntrlUserCard));
            this.tcUsers = new Guna.UI2.WinForms.Guna2TabControl();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.tsActive = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lbUserID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tpLoginInfo = new System.Windows.Forms.TabPage();
            this.cntrlPersonCard2 = new DVLD_Project.Controls.cntrlPersonCard();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tcUsers.SuspendLayout();
            this.tpPersonalInfo.SuspendLayout();
            this.guna2ShadowPanel2.SuspendLayout();
            this.guna2ShadowPanel1.SuspendLayout();
            this.tpLoginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcUsers
            // 
            this.tcUsers.Controls.Add(this.tpPersonalInfo);
            this.tcUsers.Controls.Add(this.tpLoginInfo);
            this.tcUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcUsers.ImageList = this.imageList1;
            this.tcUsers.ItemSize = new System.Drawing.Size(180, 60);
            this.tcUsers.Location = new System.Drawing.Point(0, 0);
            this.tcUsers.Name = "tcUsers";
            this.tcUsers.SelectedIndex = 0;
            this.tcUsers.Size = new System.Drawing.Size(854, 689);
            this.tcUsers.TabButtonHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.tcUsers.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(224)))));
            this.tcUsers.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcUsers.TabButtonHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.tcUsers.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcUsers.TabButtonIdleState.BorderColor = System.Drawing.Color.Transparent;
            this.tcUsers.TabButtonIdleState.FillColor = System.Drawing.Color.White;
            this.tcUsers.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcUsers.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.tcUsers.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcUsers.TabButtonImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tcUsers.TabButtonSelectedState.BorderColor = System.Drawing.Color.Transparent;
            this.tcUsers.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.tcUsers.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.tcUsers.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tcUsers.TabButtonSelectedState.InnerColor = System.Drawing.Color.OrangeRed;
            this.tcUsers.TabButtonSize = new System.Drawing.Size(180, 60);
            this.tcUsers.TabButtonTextOffset = new System.Drawing.Point(15, 0);
            this.tcUsers.TabIndex = 36;
            this.tcUsers.TabMenuBackColor = System.Drawing.Color.White;
            this.tcUsers.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.BackColor = System.Drawing.Color.White;
            this.tpPersonalInfo.Controls.Add(this.guna2ShadowPanel2);
            this.tpPersonalInfo.ImageKey = "admin (5).png";
            this.tpPersonalInfo.Location = new System.Drawing.Point(4, 64);
            this.tpPersonalInfo.Name = "tpPersonalInfo";
            this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(20);
            this.tpPersonalInfo.Size = new System.Drawing.Size(846, 621);
            this.tpPersonalInfo.TabIndex = 0;
            this.tpPersonalInfo.Text = "User Info";
            // 
            // guna2ShadowPanel2
            // 
            this.guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel2.Controls.Add(this.tsActive);
            this.guna2ShadowPanel2.Controls.Add(this.guna2ShadowPanel1);
            this.guna2ShadowPanel2.Controls.Add(this.guna2HtmlLabel9);
            this.guna2ShadowPanel2.Controls.Add(this.txtPassword);
            this.guna2ShadowPanel2.Controls.Add(this.guna2HtmlLabel8);
            this.guna2ShadowPanel2.Controls.Add(this.txtUserName);
            this.guna2ShadowPanel2.Controls.Add(this.guna2HtmlLabel6);
            this.guna2ShadowPanel2.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel2.Location = new System.Drawing.Point(18, 5);
            this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            this.guna2ShadowPanel2.Radius = 20;
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel2.ShadowDepth = 90;
            this.guna2ShadowPanel2.ShadowShift = 2;
            this.guna2ShadowPanel2.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(803, 505);
            this.guna2ShadowPanel2.TabIndex = 19;
            // 
            // tsActive
            // 
            this.tsActive.Animated = true;
            this.tsActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tsActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.tsActive.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tsActive.CheckedState.InnerColor = System.Drawing.Color.White;
            this.tsActive.Enabled = false;
            this.tsActive.Location = new System.Drawing.Point(132, 238);
            this.tsActive.Name = "tsActive";
            this.tsActive.Size = new System.Drawing.Size(48, 23);
            this.tsActive.TabIndex = 33;
            this.tsActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsActive.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tsActive.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.tsActive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tsActive_MouseDown);
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.lbUserID);
            this.guna2ShadowPanel1.Controls.Add(this.guna2HtmlLabel2);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(10, 13);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 18;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowDepth = 90;
            this.guna2ShadowPanel1.ShadowShift = 2;
            this.guna2ShadowPanel1.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(225, 56);
            this.guna2ShadowPanel1.TabIndex = 10;
            // 
            // lbUserID
            // 
            this.lbUserID.BackColor = System.Drawing.Color.Transparent;
            this.lbUserID.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbUserID.Location = new System.Drawing.Point(142, 13);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(38, 27);
            this.lbUserID.TabIndex = 32;
            this.lbUserID.Text = "N/A";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(46, 13);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(70, 27);
            this.guna2HtmlLabel2.TabIndex = 33;
            this.guna2HtmlLabel2.Text = "User ID:";
            // 
            // guna2HtmlLabel9
            // 
            this.guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel9.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(8, 234);
            this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            this.guna2HtmlLabel9.Size = new System.Drawing.Size(81, 27);
            this.guna2HtmlLabel9.TabIndex = 25;
            this.guna2HtmlLabel9.Text = "Is Active:";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.txtPassword.BorderRadius = 10;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.White;
            this.txtPassword.Enabled = false;
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.txtPassword.FocusedState.FillColor = System.Drawing.Color.White;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.txtPassword.IconLeft = global::DVLD_Project.Properties.Resources.password__1_;
            this.txtPassword.IconLeftSize = new System.Drawing.Size(60, 60);
            this.txtPassword.Location = new System.Drawing.Point(132, 176);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderText = "Enter Email Address";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(322, 44);
            this.txtPassword.TabIndex = 7;
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(8, 176);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(92, 27);
            this.guna2HtmlLabel8.TabIndex = 23;
            this.guna2HtmlLabel8.Text = "PassWord:";
            // 
            // txtUserName
            // 
            this.txtUserName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.txtUserName.BorderRadius = 10;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.DefaultText = "";
            this.txtUserName.DisabledState.FillColor = System.Drawing.Color.White;
            this.txtUserName.Enabled = false;
            this.txtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.txtUserName.FocusedState.FillColor = System.Drawing.Color.White;
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.txtUserName.IconLeft = global::DVLD_Project.Properties.Resources.card__1_;
            this.txtUserName.IconLeftSize = new System.Drawing.Size(40, 40);
            this.txtUserName.Location = new System.Drawing.Point(132, 108);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtUserName.PlaceholderText = "Enter National Number";
            this.txtUserName.SelectedText = "";
            this.txtUserName.Size = new System.Drawing.Size(322, 44);
            this.txtUserName.TabIndex = 4;
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(8, 108);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(101, 27);
            this.guna2HtmlLabel6.TabIndex = 18;
            this.guna2HtmlLabel6.Text = "User Name:";
            // 
            // tpLoginInfo
            // 
            this.tpLoginInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpLoginInfo.Controls.Add(this.cntrlPersonCard2);
            this.tpLoginInfo.ImageKey = "person_boy (5).png";
            this.tpLoginInfo.Location = new System.Drawing.Point(4, 64);
            this.tpLoginInfo.Name = "tpLoginInfo";
            this.tpLoginInfo.Padding = new System.Windows.Forms.Padding(20);
            this.tpLoginInfo.Size = new System.Drawing.Size(846, 621);
            this.tpLoginInfo.TabIndex = 1;
            this.tpLoginInfo.Text = "Personal Info";
            // 
            // cntrlPersonCard2
            // 
            this.cntrlPersonCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.cntrlPersonCard2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cntrlPersonCard2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cntrlPersonCard2.Location = new System.Drawing.Point(20, 20);
            this.cntrlPersonCard2.Margin = new System.Windows.Forms.Padding(4);
            this.cntrlPersonCard2.Name = "cntrlPersonCard2";
            this.cntrlPersonCard2.Size = new System.Drawing.Size(806, 581);
            this.cntrlPersonCard2.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "admin (5).png");
            this.imageList1.Images.SetKeyName(1, "lock_open.png");
            this.imageList1.Images.SetKeyName(2, "person_boy (5).png");
            // 
            // cntrlUserCard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tcUsers);
            this.Name = "cntrlUserCard";
            this.Size = new System.Drawing.Size(854, 689);
            this.Load += new System.EventHandler(this.cntrlUserCard_Load);
            this.tcUsers.ResumeLayout(false);
            this.tpPersonalInfo.ResumeLayout(false);
            this.guna2ShadowPanel2.ResumeLayout(false);
            this.guna2ShadowPanel2.PerformLayout();
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            this.tpLoginInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TabControl tcUsers;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private System.Windows.Forms.ImageList imageList1;
        private DVLD_Project.Controls.cntrlPersonCard cntrlPersonCard2;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbUserID;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        public Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        public Guna.UI2.WinForms.Guna2TextBox txtUserName;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2ToggleSwitch tsActive;
    }
}
