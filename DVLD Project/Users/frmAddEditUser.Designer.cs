namespace DVLD_Project.Users
{
    partial class frmAddEditUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditUser));
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbAddUpdate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tcUsers = new Guna.UI2.WinForms.Guna2TabControl();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.cntrlPersonCardWithFilter2 = new DVLD_Project.People.Controls.cntrlPersonCardWithFilter();
            this.tpLoginInfo = new System.Windows.Forms.TabPage();
            this.pnlUserLoginInfo = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btnShowPassword = new Guna.UI2.WinForms.Guna2Button();
            this.pnChangePassword = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.chbApplyPassword = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtNewPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtCurrentPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.llChangePassword = new System.Windows.Forms.LinkLabel();
            this.chbActive = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lbUserID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.txtAnotherPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbConfirmPassword = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtPassWord = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbUserName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tcUsers.SuspendLayout();
            this.tpPersonalInfo.SuspendLayout();
            this.tpLoginInfo.SuspendLayout();
            this.pnlUserLoginInfo.SuspendLayout();
            this.pnChangePassword.SuspendLayout();
            this.guna2ShadowPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.pictureBox1);
            this.guna2ShadowPanel1.Controls.Add(this.lbAddUpdate);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(41, 3);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 20;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowDepth = 50;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(982, 94);
            this.guna2ShadowPanel1.TabIndex = 30;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.admin__6_;
            this.pictureBox1.Location = new System.Drawing.Point(282, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // lbAddUpdate
            // 
            this.lbAddUpdate.BackColor = System.Drawing.Color.Transparent;
            this.lbAddUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddUpdate.ForeColor = System.Drawing.Color.DarkOrange;
            this.lbAddUpdate.Location = new System.Drawing.Point(384, 24);
            this.lbAddUpdate.Name = "lbAddUpdate";
            this.lbAddUpdate.Size = new System.Drawing.Size(218, 47);
            this.lbAddUpdate.TabIndex = 29;
            this.lbAddUpdate.Text = "Add New User";
            // 
            // tcUsers
            // 
            this.tcUsers.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tcUsers.Controls.Add(this.tpPersonalInfo);
            this.tcUsers.Controls.Add(this.tpLoginInfo);
            this.tcUsers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tcUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcUsers.ImageList = this.imageList1;
            this.tcUsers.ItemSize = new System.Drawing.Size(180, 60);
            this.tcUsers.Location = new System.Drawing.Point(0, 101);
            this.tcUsers.Name = "tcUsers";
            this.tcUsers.SelectedIndex = 0;
            this.tcUsers.Size = new System.Drawing.Size(1041, 716);
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
            this.tcUsers.TabIndex = 35;
            this.tcUsers.TabMenuBackColor = System.Drawing.Color.White;
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpPersonalInfo.Controls.Add(this.btnNext);
            this.tpPersonalInfo.Controls.Add(this.cntrlPersonCardWithFilter2);
            this.tpPersonalInfo.ImageKey = "admin (5).png";
            this.tpPersonalInfo.Location = new System.Drawing.Point(184, 4);
            this.tpPersonalInfo.Name = "tpPersonalInfo";
            this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(20);
            this.tpPersonalInfo.Size = new System.Drawing.Size(853, 708);
            this.tpPersonalInfo.TabIndex = 0;
            this.tpPersonalInfo.Text = "Personal Info";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Animated = true;
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.btnNext.BorderRadius = 18;
            this.btnNext.BorderThickness = 2;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnNext.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnNext.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnNext.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNext.Image = global::DVLD_Project.Properties.Resources.next;
            this.btnNext.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnNext.ImageSize = new System.Drawing.Size(40, 40);
            this.btnNext.Location = new System.Drawing.Point(625, 596);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(130)))));
            this.btnNext.ShadowDecoration.BorderRadius = 4;
            this.btnNext.ShadowDecoration.Depth = 10;
            this.btnNext.Size = new System.Drawing.Size(171, 78);
            this.btnNext.TabIndex = 42;
            this.btnNext.Tag = "Male";
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNext.TextOffset = new System.Drawing.Point(20, 0);
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // cntrlPersonCardWithFilter2
            // 
            this.cntrlPersonCardWithFilter2.BackColor = System.Drawing.Color.Transparent;
            this.cntrlPersonCardWithFilter2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cntrlPersonCardWithFilter2.EnablePersonCardWithFilter = true;
            this.cntrlPersonCardWithFilter2.Location = new System.Drawing.Point(20, 20);
            this.cntrlPersonCardWithFilter2.Name = "cntrlPersonCardWithFilter2";
            this.cntrlPersonCardWithFilter2.Size = new System.Drawing.Size(813, 668);
            this.cntrlPersonCardWithFilter2.TabIndex = 35;
            // 
            // tpLoginInfo
            // 
            this.tpLoginInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpLoginInfo.Controls.Add(this.pnlUserLoginInfo);
            this.tpLoginInfo.ImageKey = "lock_open.png";
            this.tpLoginInfo.Location = new System.Drawing.Point(184, 4);
            this.tpLoginInfo.Name = "tpLoginInfo";
            this.tpLoginInfo.Padding = new System.Windows.Forms.Padding(20);
            this.tpLoginInfo.Size = new System.Drawing.Size(853, 708);
            this.tpLoginInfo.TabIndex = 1;
            this.tpLoginInfo.Text = "Login Info";
            // 
            // pnlUserLoginInfo
            // 
            this.pnlUserLoginInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnlUserLoginInfo.Controls.Add(this.btnShowPassword);
            this.pnlUserLoginInfo.Controls.Add(this.pnChangePassword);
            this.pnlUserLoginInfo.Controls.Add(this.llChangePassword);
            this.pnlUserLoginInfo.Controls.Add(this.chbActive);
            this.pnlUserLoginInfo.Controls.Add(this.btnClose);
            this.pnlUserLoginInfo.Controls.Add(this.guna2ShadowPanel2);
            this.pnlUserLoginInfo.Controls.Add(this.btnSave);
            this.pnlUserLoginInfo.Controls.Add(this.txtAnotherPassword);
            this.pnlUserLoginInfo.Controls.Add(this.lbConfirmPassword);
            this.pnlUserLoginInfo.Controls.Add(this.txtPassWord);
            this.pnlUserLoginInfo.Controls.Add(this.guna2HtmlLabel1);
            this.pnlUserLoginInfo.Controls.Add(this.txtUserName);
            this.pnlUserLoginInfo.Controls.Add(this.lbUserName);
            this.pnlUserLoginInfo.Enabled = false;
            this.pnlUserLoginInfo.FillColor = System.Drawing.Color.White;
            this.pnlUserLoginInfo.Location = new System.Drawing.Point(68, 3);
            this.pnlUserLoginInfo.Name = "pnlUserLoginInfo";
            this.pnlUserLoginInfo.Radius = 20;
            this.pnlUserLoginInfo.ShadowColor = System.Drawing.Color.Black;
            this.pnlUserLoginInfo.ShadowDepth = 30;
            this.pnlUserLoginInfo.Size = new System.Drawing.Size(710, 682);
            this.pnlUserLoginInfo.TabIndex = 45;
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.Animated = true;
            this.btnShowPassword.BorderRadius = 12;
            this.btnShowPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.btnShowPassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowPassword.ForeColor = System.Drawing.Color.White;
            this.btnShowPassword.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnShowPassword.Image = global::DVLD_Project.Properties.Resources.zoom;
            this.btnShowPassword.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnShowPassword.ImageSize = new System.Drawing.Size(25, 25);
            this.btnShowPassword.Location = new System.Drawing.Point(473, 186);
            this.btnShowPassword.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.btnShowPassword.Size = new System.Drawing.Size(42, 39);
            this.btnShowPassword.TabIndex = 49;
            this.btnShowPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnShowPassword_MouseDown);
            this.btnShowPassword.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnShowPassword_MouseUp);
            // 
            // pnChangePassword
            // 
            this.pnChangePassword.BackColor = System.Drawing.Color.Transparent;
            this.pnChangePassword.Controls.Add(this.chbApplyPassword);
            this.pnChangePassword.Controls.Add(this.txtConfirmPassword);
            this.pnChangePassword.Controls.Add(this.guna2HtmlLabel4);
            this.pnChangePassword.Controls.Add(this.txtNewPassword);
            this.pnChangePassword.Controls.Add(this.guna2HtmlLabel5);
            this.pnChangePassword.Controls.Add(this.txtCurrentPassword);
            this.pnChangePassword.Controls.Add(this.guna2HtmlLabel6);
            this.pnChangePassword.FillColor = System.Drawing.Color.White;
            this.pnChangePassword.Location = new System.Drawing.Point(21, 374);
            this.pnChangePassword.Name = "pnChangePassword";
            this.pnChangePassword.Radius = 20;
            this.pnChangePassword.ShadowColor = System.Drawing.Color.Black;
            this.pnChangePassword.ShadowDepth = 90;
            this.pnChangePassword.ShadowShift = 2;
            this.pnChangePassword.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
            this.pnChangePassword.Size = new System.Drawing.Size(678, 180);
            this.pnChangePassword.TabIndex = 45;
            this.pnChangePassword.Visible = false;
            // 
            // chbApplyPassword
            // 
            this.chbApplyPassword.AutoSize = true;
            this.chbApplyPassword.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.chbApplyPassword.CheckedState.BorderRadius = 0;
            this.chbApplyPassword.CheckedState.BorderThickness = 0;
            this.chbApplyPassword.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.chbApplyPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbApplyPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.chbApplyPassword.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.chbApplyPassword.Location = new System.Drawing.Point(508, 143);
            this.chbApplyPassword.Name = "chbApplyPassword";
            this.chbApplyPassword.Size = new System.Drawing.Size(153, 27);
            this.chbApplyPassword.TabIndex = 46;
            this.chbApplyPassword.Text = "Apply Password";
            this.chbApplyPassword.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbApplyPassword.UncheckedState.BorderRadius = 0;
            this.chbApplyPassword.UncheckedState.BorderThickness = 0;
            this.chbApplyPassword.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.txtConfirmPassword.BorderRadius = 10;
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPassword.DefaultText = "";
            this.txtConfirmPassword.DisabledState.FillColor = System.Drawing.Color.White;
            this.txtConfirmPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.txtConfirmPassword.FocusedState.FillColor = System.Drawing.Color.White;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtConfirmPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.txtConfirmPassword.IconLeft = global::DVLD_Project.Properties.Resources.password__1_;
            this.txtConfirmPassword.IconLeftSize = new System.Drawing.Size(60, 60);
            this.txtConfirmPassword.Location = new System.Drawing.Point(172, 126);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PlaceholderText = "Re-Enter Password";
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.Size = new System.Drawing.Size(322, 44);
            this.txtConfirmPassword.TabIndex = 28;
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(3, 126);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(165, 27);
            this.guna2HtmlLabel4.TabIndex = 29;
            this.guna2HtmlLabel4.Text = "Confirm PassWord:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.txtNewPassword.BorderRadius = 10;
            this.txtNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPassword.DefaultText = "";
            this.txtNewPassword.DisabledState.FillColor = System.Drawing.Color.White;
            this.txtNewPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.txtNewPassword.FocusedState.FillColor = System.Drawing.Color.White;
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtNewPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.txtNewPassword.IconLeft = global::DVLD_Project.Properties.Resources.password__1_;
            this.txtNewPassword.IconLeftSize = new System.Drawing.Size(60, 60);
            this.txtNewPassword.Location = new System.Drawing.Point(172, 72);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PlaceholderText = "Enter New Password";
            this.txtNewPassword.SelectedText = "";
            this.txtNewPassword.Size = new System.Drawing.Size(322, 44);
            this.txtNewPassword.TabIndex = 26;
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(3, 72);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(135, 27);
            this.guna2HtmlLabel5.TabIndex = 27;
            this.guna2HtmlLabel5.Text = "New PassWord:";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.txtCurrentPassword.BorderRadius = 10;
            this.txtCurrentPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCurrentPassword.DefaultText = "";
            this.txtCurrentPassword.DisabledState.FillColor = System.Drawing.Color.White;
            this.txtCurrentPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.txtCurrentPassword.FocusedState.FillColor = System.Drawing.Color.White;
            this.txtCurrentPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtCurrentPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.txtCurrentPassword.IconLeft = global::DVLD_Project.Properties.Resources.password__1_;
            this.txtCurrentPassword.IconLeftSize = new System.Drawing.Size(60, 60);
            this.txtCurrentPassword.Location = new System.Drawing.Point(172, 22);
            this.txtCurrentPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PlaceholderText = "Enter Current Password";
            this.txtCurrentPassword.SelectedText = "";
            this.txtCurrentPassword.Size = new System.Drawing.Size(322, 44);
            this.txtCurrentPassword.TabIndex = 24;
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(3, 22);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(161, 27);
            this.guna2HtmlLabel6.TabIndex = 25;
            this.guna2HtmlLabel6.Text = "Current PassWord:";
            // 
            // llChangePassword
            // 
            this.llChangePassword.AutoSize = true;
            this.llChangePassword.Enabled = false;
            this.llChangePassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llChangePassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.llChangePassword.LinkColor = System.Drawing.Color.Orange;
            this.llChangePassword.Location = new System.Drawing.Point(525, 210);
            this.llChangePassword.Name = "llChangePassword";
            this.llChangePassword.Size = new System.Drawing.Size(146, 23);
            this.llChangePassword.TabIndex = 31;
            this.llChangePassword.TabStop = true;
            this.llChangePassword.Text = "Change Password";
            this.llChangePassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llChangPassword_LinkClicked);
            // 
            // chbActive
            // 
            this.chbActive.AutoSize = true;
            this.chbActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.chbActive.CheckedState.BorderRadius = 0;
            this.chbActive.CheckedState.BorderThickness = 0;
            this.chbActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.chbActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbActive.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.chbActive.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.chbActive.Location = new System.Drawing.Point(195, 329);
            this.chbActive.Name = "chbActive";
            this.chbActive.Size = new System.Drawing.Size(88, 29);
            this.chbActive.TabIndex = 40;
            this.chbActive.Text = "Active";
            this.chbActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbActive.UncheckedState.BorderRadius = 0;
            this.chbActive.UncheckedState.BorderThickness = 0;
            this.chbActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // btnClose
            // 
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnClose.BorderRadius = 12;
            this.btnClose.BorderThickness = 1;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(302, 580);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(160, 78);
            this.btnClose.TabIndex = 44;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2ShadowPanel2
            // 
            this.guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel2.Controls.Add(this.lbUserID);
            this.guna2ShadowPanel2.Controls.Add(this.guna2HtmlLabel3);
            this.guna2ShadowPanel2.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel2.Location = new System.Drawing.Point(24, 20);
            this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            this.guna2ShadowPanel2.Radius = 18;
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.Aquamarine;
            this.guna2ShadowPanel2.ShadowDepth = 20;
            this.guna2ShadowPanel2.ShadowShift = 2;
            this.guna2ShadowPanel2.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(225, 56);
            this.guna2ShadowPanel2.TabIndex = 39;
            // 
            // lbUserID
            // 
            this.lbUserID.BackColor = System.Drawing.Color.Transparent;
            this.lbUserID.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbUserID.Location = new System.Drawing.Point(142, 13);
            this.lbUserID.Name = "lbUserID";
            this.lbUserID.Size = new System.Drawing.Size(45, 32);
            this.lbUserID.TabIndex = 32;
            this.lbUserID.Text = "N/A";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(46, 13);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(85, 32);
            this.guna2HtmlLabel3.TabIndex = 33;
            this.guna2HtmlLabel3.Text = "User ID:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Animated = true;
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.btnSave.BorderRadius = 18;
            this.btnSave.BorderThickness = 2;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.Image = global::DVLD_Project.Properties.Resources.diskette1;
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSave.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSave.Location = new System.Drawing.Point(495, 580);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(130)))));
            this.btnSave.ShadowDecoration.BorderRadius = 4;
            this.btnSave.ShadowDecoration.Depth = 10;
            this.btnSave.Size = new System.Drawing.Size(193, 78);
            this.btnSave.TabIndex = 43;
            this.btnSave.Tag = "Male";
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAnotherPassword
            // 
            this.txtAnotherPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.txtAnotherPassword.BorderRadius = 10;
            this.txtAnotherPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAnotherPassword.DefaultText = "";
            this.txtAnotherPassword.DisabledState.FillColor = System.Drawing.Color.White;
            this.txtAnotherPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.txtAnotherPassword.FocusedState.FillColor = System.Drawing.Color.White;
            this.txtAnotherPassword.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtAnotherPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.txtAnotherPassword.IconLeft = global::DVLD_Project.Properties.Resources.card;
            this.txtAnotherPassword.IconLeftSize = new System.Drawing.Size(40, 40);
            this.txtAnotherPassword.Location = new System.Drawing.Point(195, 252);
            this.txtAnotherPassword.Margin = new System.Windows.Forms.Padding(5);
            this.txtAnotherPassword.Name = "txtAnotherPassword";
            this.txtAnotherPassword.PasswordChar = '*';
            this.txtAnotherPassword.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtAnotherPassword.PlaceholderText = "Re-Enter Password";
            this.txtAnotherPassword.SelectedText = "";
            this.txtAnotherPassword.Size = new System.Drawing.Size(322, 59);
            this.txtAnotherPassword.TabIndex = 37;
            this.txtAnotherPassword.Tag = "Password";
            this.txtAnotherPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtAnotherPassword_Validating);
            // 
            // lbConfirmPassword
            // 
            this.lbConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.lbConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbConfirmPassword.Location = new System.Drawing.Point(19, 271);
            this.lbConfirmPassword.Name = "lbConfirmPassword";
            this.lbConfirmPassword.Size = new System.Drawing.Size(166, 27);
            this.lbConfirmPassword.TabIndex = 38;
            this.lbConfirmPassword.Text = "Confirm Password  :";
            // 
            // txtPassWord
            // 
            this.txtPassWord.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.txtPassWord.BorderRadius = 10;
            this.txtPassWord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassWord.DefaultText = "";
            this.txtPassWord.DisabledState.FillColor = System.Drawing.Color.White;
            this.txtPassWord.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.txtPassWord.FocusedState.FillColor = System.Drawing.Color.White;
            this.txtPassWord.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtPassWord.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.txtPassWord.IconLeft = global::DVLD_Project.Properties.Resources.card;
            this.txtPassWord.IconLeftSize = new System.Drawing.Size(40, 40);
            this.txtPassWord.Location = new System.Drawing.Point(195, 174);
            this.txtPassWord.Margin = new System.Windows.Forms.Padding(5);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPassWord.PlaceholderText = "Enter Password";
            this.txtPassWord.SelectedText = "";
            this.txtPassWord.Size = new System.Drawing.Size(322, 59);
            this.txtPassWord.TabIndex = 35;
            this.txtPassWord.Tag = "Password";
            this.txtPassWord.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingEmptyTextBox);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(79, 186);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(93, 27);
            this.guna2HtmlLabel1.TabIndex = 36;
            this.guna2HtmlLabel1.Text = "Password  :";
            // 
            // txtUserName
            // 
            this.txtUserName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.txtUserName.BorderRadius = 10;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.DefaultText = "";
            this.txtUserName.DisabledState.FillColor = System.Drawing.Color.White;
            this.txtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.txtUserName.FocusedState.FillColor = System.Drawing.Color.White;
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.txtUserName.IconLeft = global::DVLD_Project.Properties.Resources.card;
            this.txtUserName.IconLeftSize = new System.Drawing.Size(40, 40);
            this.txtUserName.Location = new System.Drawing.Point(195, 95);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtUserName.PlaceholderText = "Enter UserName";
            this.txtUserName.SelectedText = "";
            this.txtUserName.Size = new System.Drawing.Size(322, 59);
            this.txtUserName.TabIndex = 33;
            this.txtUserName.Tag = "UserName";
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // lbUserName
            // 
            this.lbUserName.BackColor = System.Drawing.Color.Transparent;
            this.lbUserName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbUserName.Location = new System.Drawing.Point(71, 114);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(101, 27);
            this.lbUserName.TabIndex = 34;
            this.lbUserName.Text = "UserName  :";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "admin (5).png");
            this.imageList1.Images.SetKeyName(1, "lock_open.png");
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1041, 817);
            this.Controls.Add(this.tcUsers);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddEditUser";
            this.Load += new System.EventHandler(this.frmAddEditUser_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tcUsers.ResumeLayout(false);
            this.tpPersonalInfo.ResumeLayout(false);
            this.tpLoginInfo.ResumeLayout(false);
            this.pnlUserLoginInfo.ResumeLayout(false);
            this.pnlUserLoginInfo.PerformLayout();
            this.pnChangePassword.ResumeLayout(false);
            this.pnChangePassword.PerformLayout();
            this.guna2ShadowPanel2.ResumeLayout(false);
            this.guna2ShadowPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbAddUpdate;
        private Guna.UI2.WinForms.Guna2TabControl tcUsers;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private System.Windows.Forms.ImageList imageList1;
        private People.Controls.cntrlPersonCardWithFilter cntrlPersonCardWithFilter2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public Guna.UI2.WinForms.Guna2Button btnNext;
        public Guna.UI2.WinForms.Guna2Button btnClose;
        public Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlUserLoginInfo;
        private Guna.UI2.WinForms.Guna2CheckBox chbActive;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbUserID;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        public Guna.UI2.WinForms.Guna2TextBox txtAnotherPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbConfirmPassword;
        public Guna.UI2.WinForms.Guna2TextBox txtPassWord;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        public Guna.UI2.WinForms.Guna2TextBox txtUserName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbUserName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.LinkLabel llChangePassword;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnChangePassword;
        public Guna.UI2.WinForms.Guna2TextBox txtConfirmPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        public Guna.UI2.WinForms.Guna2TextBox txtNewPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2CheckBox chbApplyPassword;
        public Guna.UI2.WinForms.Guna2TextBox txtCurrentPassword;
        public Guna.UI2.WinForms.Guna2Button btnShowPassword;
    }
}