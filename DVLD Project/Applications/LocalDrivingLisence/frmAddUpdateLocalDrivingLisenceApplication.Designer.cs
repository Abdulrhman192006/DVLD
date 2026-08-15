namespace DVLD_Project.Applications.LocalDrivingLicense
{
    partial class frmAddUpdateLocalDrivingLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdateLocalDrivingLicenseApplication));
            this.tcUsers = new Guna.UI2.WinForms.Guna2TabControl();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.cntrlPersonCardWithFilter2 = new DVLD_Project.People.Controls.cntrlPersonCardWithFilter();
            this.tpLoginInfo = new System.Windows.Forms.TabPage();
            this.pnlUserLoginInfo = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lbAppDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbMadeByUser = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbAppFees = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbLocalAppID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbLicenseClass = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.lbConfirmPassword = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbUserName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbAddUpdate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tcUsers.SuspendLayout();
            this.tpPersonalInfo.SuspendLayout();
            this.tpLoginInfo.SuspendLayout();
            this.pnlUserLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.tcUsers.Location = new System.Drawing.Point(0, 138);
            this.tcUsers.Name = "tcUsers";
            this.tcUsers.SelectedIndex = 0;
            this.tcUsers.Size = new System.Drawing.Size(1026, 716);
            this.tcUsers.TabButtonHoverState.BorderColor = System.Drawing.Color.Transparent;
            this.tcUsers.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(224)))));
            this.tcUsers.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcUsers.TabButtonHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.tcUsers.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcUsers.TabButtonIdleState.BorderColor = System.Drawing.Color.Gold;
            this.tcUsers.TabButtonIdleState.FillColor = System.Drawing.Color.Silver;
            this.tcUsers.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcUsers.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.tcUsers.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcUsers.TabButtonImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tcUsers.TabButtonSelectedState.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.tcUsers.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.tcUsers.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.tcUsers.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tcUsers.TabButtonSelectedState.InnerColor = System.Drawing.Color.OrangeRed;
            this.tcUsers.TabButtonSize = new System.Drawing.Size(180, 60);
            this.tcUsers.TabButtonTextOffset = new System.Drawing.Point(19, 0);
            this.tcUsers.TabIndex = 37;
            this.tcUsers.TabMenuBackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpPersonalInfo.Controls.Add(this.btnNext);
            this.tpPersonalInfo.Controls.Add(this.cntrlPersonCardWithFilter2);
            this.tpPersonalInfo.ImageKey = "admin (1).png";
            this.tpPersonalInfo.Location = new System.Drawing.Point(184, 4);
            this.tpPersonalInfo.Name = "tpPersonalInfo";
            this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(20);
            this.tpPersonalInfo.Size = new System.Drawing.Size(838, 708);
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
            this.btnNext.Location = new System.Drawing.Point(610, 596);
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
            // 
            // cntrlPersonCardWithFilter2
            // 
            this.cntrlPersonCardWithFilter2.BackColor = System.Drawing.Color.Transparent;
            this.cntrlPersonCardWithFilter2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cntrlPersonCardWithFilter2.EnablePersonCardWithFilter = true;
            this.cntrlPersonCardWithFilter2.Location = new System.Drawing.Point(20, 20);
            this.cntrlPersonCardWithFilter2.Name = "cntrlPersonCardWithFilter2";
            this.cntrlPersonCardWithFilter2.Size = new System.Drawing.Size(798, 668);
            this.cntrlPersonCardWithFilter2.TabIndex = 35;
            // 
            // tpLoginInfo
            // 
            this.tpLoginInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpLoginInfo.Controls.Add(this.pnlUserLoginInfo);
            this.tpLoginInfo.ImageKey = "form.png";
            this.tpLoginInfo.Location = new System.Drawing.Point(184, 4);
            this.tpLoginInfo.Name = "tpLoginInfo";
            this.tpLoginInfo.Padding = new System.Windows.Forms.Padding(20);
            this.tpLoginInfo.Size = new System.Drawing.Size(838, 708);
            this.tpLoginInfo.TabIndex = 1;
            this.tpLoginInfo.Text = "Application Info";
            // 
            // pnlUserLoginInfo
            // 
            this.pnlUserLoginInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnlUserLoginInfo.Controls.Add(this.pictureBox6);
            this.pnlUserLoginInfo.Controls.Add(this.pictureBox5);
            this.pnlUserLoginInfo.Controls.Add(this.pictureBox4);
            this.pnlUserLoginInfo.Controls.Add(this.lbAppDate);
            this.pnlUserLoginInfo.Controls.Add(this.pictureBox3);
            this.pnlUserLoginInfo.Controls.Add(this.pictureBox2);
            this.pnlUserLoginInfo.Controls.Add(this.lbMadeByUser);
            this.pnlUserLoginInfo.Controls.Add(this.lbAppFees);
            this.pnlUserLoginInfo.Controls.Add(this.lbLocalAppID);
            this.pnlUserLoginInfo.Controls.Add(this.guna2HtmlLabel4);
            this.pnlUserLoginInfo.Controls.Add(this.guna2HtmlLabel2);
            this.pnlUserLoginInfo.Controls.Add(this.cbLicenseClass);
            this.pnlUserLoginInfo.Controls.Add(this.btnClose);
            this.pnlUserLoginInfo.Controls.Add(this.btnSave);
            this.pnlUserLoginInfo.Controls.Add(this.lbConfirmPassword);
            this.pnlUserLoginInfo.Controls.Add(this.guna2HtmlLabel1);
            this.pnlUserLoginInfo.Controls.Add(this.lbUserName);
            this.pnlUserLoginInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserLoginInfo.FillColor = System.Drawing.Color.White;
            this.pnlUserLoginInfo.Location = new System.Drawing.Point(20, 20);
            this.pnlUserLoginInfo.Name = "pnlUserLoginInfo";
            this.pnlUserLoginInfo.Radius = 20;
            this.pnlUserLoginInfo.ShadowColor = System.Drawing.Color.Black;
            this.pnlUserLoginInfo.ShadowDepth = 30;
            this.pnlUserLoginInfo.Size = new System.Drawing.Size(798, 668);
            this.pnlUserLoginInfo.TabIndex = 45;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD_Project.Properties.Resources.car__1_;
            this.pictureBox6.Location = new System.Drawing.Point(266, 240);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(69, 50);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 59;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_Project.Properties.Resources.credit_card;
            this.pictureBox5.Location = new System.Drawing.Point(266, 102);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(69, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 58;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_Project.Properties.Resources.calendar_week;
            this.pictureBox4.Location = new System.Drawing.Point(266, 172);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(69, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 57;
            this.pictureBox4.TabStop = false;
            // 
            // lbAppDate
            // 
            this.lbAppDate.BackColor = System.Drawing.Color.Transparent;
            this.lbAppDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAppDate.ForeColor = System.Drawing.Color.Orange;
            this.lbAppDate.Location = new System.Drawing.Point(341, 183);
            this.lbAppDate.Name = "lbAppDate";
            this.lbAppDate.Size = new System.Drawing.Size(411, 30);
            this.lbAppDate.TabIndex = 56;
            this.lbAppDate.Text = "Add New Local Driving License Application";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_Project.Properties.Resources.admin__7_;
            this.pictureBox3.Location = new System.Drawing.Point(266, 404);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(69, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 55;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Project.Properties.Resources.price_tag;
            this.pictureBox2.Location = new System.Drawing.Point(266, 330);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // lbMadeByUser
            // 
            this.lbMadeByUser.BackColor = System.Drawing.Color.Transparent;
            this.lbMadeByUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMadeByUser.ForeColor = System.Drawing.Color.Orange;
            this.lbMadeByUser.Location = new System.Drawing.Point(341, 415);
            this.lbMadeByUser.Name = "lbMadeByUser";
            this.lbMadeByUser.Size = new System.Drawing.Size(48, 30);
            this.lbMadeByUser.TabIndex = 54;
            this.lbMadeByUser.Text = "?????";
            // 
            // lbAppFees
            // 
            this.lbAppFees.BackColor = System.Drawing.Color.Transparent;
            this.lbAppFees.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAppFees.ForeColor = System.Drawing.Color.Orange;
            this.lbAppFees.Location = new System.Drawing.Point(341, 339);
            this.lbAppFees.Name = "lbAppFees";
            this.lbAppFees.Size = new System.Drawing.Size(411, 30);
            this.lbAppFees.TabIndex = 53;
            this.lbAppFees.Text = "Add New Local Driving License Application";
            // 
            // lbLocalAppID
            // 
            this.lbLocalAppID.BackColor = System.Drawing.Color.Transparent;
            this.lbLocalAppID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocalAppID.ForeColor = System.Drawing.Color.Orange;
            this.lbLocalAppID.Location = new System.Drawing.Point(341, 113);
            this.lbLocalAppID.Name = "lbLocalAppID";
            this.lbLocalAppID.Size = new System.Drawing.Size(183, 30);
            this.lbLocalAppID.TabIndex = 52;
            this.lbLocalAppID.Text = "AUTO-GENERATED";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(15, 418);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(234, 27);
            this.guna2HtmlLabel4.TabIndex = 49;
            this.guna2HtmlLabel4.Text = "Application Made By User  :";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(15, 330);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(153, 27);
            this.guna2HtmlLabel2.TabIndex = 47;
            this.guna2HtmlLabel2.Text = "Application Fees  :";
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.BackColor = System.Drawing.Color.Transparent;
            this.cbLicenseClass.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.cbLicenseClass.BorderRadius = 10;
            this.cbLicenseClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.cbLicenseClass.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.cbLicenseClass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.cbLicenseClass.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLicenseClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbLicenseClass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.cbLicenseClass.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.cbLicenseClass.ItemHeight = 32;
            this.cbLicenseClass.ItemsAppearance.SelectedFont = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLicenseClass.Location = new System.Drawing.Point(341, 252);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(270, 38);
            this.cbLicenseClass.TabIndex = 46;
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
            this.btnClose.Location = new System.Drawing.Point(325, 530);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(183, 84);
            this.btnClose.TabIndex = 44;
            this.btnClose.Text = "Close";
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
            this.btnSave.Location = new System.Drawing.Point(570, 530);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(130)))));
            this.btnSave.ShadowDecoration.BorderRadius = 4;
            this.btnSave.ShadowDecoration.Depth = 10;
            this.btnSave.Size = new System.Drawing.Size(199, 84);
            this.btnSave.TabIndex = 43;
            this.btnSave.Tag = "Male";
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // lbConfirmPassword
            // 
            this.lbConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.lbConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbConfirmPassword.Location = new System.Drawing.Point(24, 252);
            this.lbConfirmPassword.Name = "lbConfirmPassword";
            this.lbConfirmPassword.Size = new System.Drawing.Size(122, 27);
            this.lbConfirmPassword.TabIndex = 38;
            this.lbConfirmPassword.Text = "License Class :";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(19, 183);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(156, 27);
            this.guna2HtmlLabel1.TabIndex = 36;
            this.guna2HtmlLabel1.Text = "Application Date  :";
            // 
            // lbUserName
            // 
            this.lbUserName.BackColor = System.Drawing.Color.Transparent;
            this.lbUserName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lbUserName.Location = new System.Drawing.Point(19, 113);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(201, 27);
            this.lbUserName.TabIndex = 34;
            this.lbUserName.Text = "Driving License App.ID:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "card (1).png");
            this.imageList1.Images.SetKeyName(1, "exam_pass.png");
            this.imageList1.Images.SetKeyName(2, "report (4).png");
            this.imageList1.Images.SetKeyName(3, "report (3).png");
            this.imageList1.Images.SetKeyName(4, "world.png");
            this.imageList1.Images.SetKeyName(5, "arrow_right.png");
            this.imageList1.Images.SetKeyName(6, "car (2).png");
            this.imageList1.Images.SetKeyName(7, "car (1).png");
            this.imageList1.Images.SetKeyName(8, "car.png");
            this.imageList1.Images.SetKeyName(9, "credit_card.png");
            this.imageList1.Images.SetKeyName(10, "calendar_week.png");
            this.imageList1.Images.SetKeyName(11, "admin (7).png");
            this.imageList1.Images.SetKeyName(12, "ChatGPT Image 26 يوليو 2026، 05_49_22 ص.png");
            this.imageList1.Images.SetKeyName(13, "report (2).png");
            this.imageList1.Images.SetKeyName(14, "ChatGPT Image 25 يوليو 2026، 05_33_25 ص.png");
            this.imageList1.Images.SetKeyName(15, "ChatGPT Image 24 يوليو 2026، 10_24_11 م.png");
            this.imageList1.Images.SetKeyName(16, "attendance_list (4).png");
            this.imageList1.Images.SetKeyName(17, "attendance_list (3).png");
            this.imageList1.Images.SetKeyName(18, "attendance_list (2).png");
            this.imageList1.Images.SetKeyName(19, "attendance_list (1).png");
            this.imageList1.Images.SetKeyName(20, "attendance_list.png");
            this.imageList1.Images.SetKeyName(21, "document (1).png");
            this.imageList1.Images.SetKeyName(22, "report (1).png");
            this.imageList1.Images.SetKeyName(23, "price_tag.png");
            this.imageList1.Images.SetKeyName(24, "grades_report (3).png");
            this.imageList1.Images.SetKeyName(25, "grades_report (2).png");
            this.imageList1.Images.SetKeyName(26, "grades_report (1).png");
            this.imageList1.Images.SetKeyName(27, "grades_report.png");
            this.imageList1.Images.SetKeyName(28, "document.png");
            this.imageList1.Images.SetKeyName(29, "ChatGPT Image 23 يوليو 2026، 07_31_08 م.png");
            this.imageList1.Images.SetKeyName(30, "Gemini_Generated_Image_c5d17sc5d17sc5d1.png");
            this.imageList1.Images.SetKeyName(31, "Gemini_Generated_Image_gaeu4mgaeu4mgaeu.png");
            this.imageList1.Images.SetKeyName(32, "Gemini_Generated_Image_pqzmx1pqzmx1pqzm (3).png");
            this.imageList1.Images.SetKeyName(33, "Gemini_Generated_Image_pqzmx1pqzmx1pqzm (2).png");
            this.imageList1.Images.SetKeyName(34, "Gemini_Generated_Image_pqzmx1pqzmx1pqzm (1).png");
            this.imageList1.Images.SetKeyName(35, "Gemini_Generated_Image_pqzmx1pqzmx1pqzm.png");
            this.imageList1.Images.SetKeyName(36, "ChatGPT Image 22 يوليو 2026، 11_19_12 م.png");
            this.imageList1.Images.SetKeyName(37, "direct_x.png");
            this.imageList1.Images.SetKeyName(38, "login (1).png");
            this.imageList1.Images.SetKeyName(39, "login.png");
            this.imageList1.Images.SetKeyName(40, "Gemini_Generated_Image_k813ayk813ayk813.png");
            this.imageList1.Images.SetKeyName(41, "Gemini_Generated_Image_b0qmmgb0qmmgb0qm.png");
            this.imageList1.Images.SetKeyName(42, "Gemini_Generated_Image_1a5dgn1a5dgn1a5d.png");
            this.imageList1.Images.SetKeyName(43, "Gemini_Generated_Image_5ytj8f5ytj8f5ytj.png");
            this.imageList1.Images.SetKeyName(44, "Gemini_Generated_Image_l15k1cl15k1cl15k (1).png");
            this.imageList1.Images.SetKeyName(45, "Gemini_Generated_Image_l15k1cl15k1cl15k.png");
            this.imageList1.Images.SetKeyName(46, "Code_Generated_Image.png");
            this.imageList1.Images.SetKeyName(47, "Gemini_Generated_Image_zcs52wzcs52wzcs5.png");
            this.imageList1.Images.SetKeyName(48, "Gemini_Generated_Image_lche8clche8clche.png");
            this.imageList1.Images.SetKeyName(49, "Gemini_Generated_Image_59y2ud59y2ud59y2.png");
            this.imageList1.Images.SetKeyName(50, "sign_in.png");
            this.imageList1.Images.SetKeyName(51, "zoom.png");
            this.imageList1.Images.SetKeyName(52, "lock_open (1).png");
            this.imageList1.Images.SetKeyName(53, "transport.png");
            this.imageList1.Images.SetKeyName(54, "ChatGPT Image 21 يوليو 2026، 02_33_16 ص.png");
            this.imageList1.Images.SetKeyName(55, "sign_out.png");
            this.imageList1.Images.SetKeyName(56, "iamstillhere-ibzadza6.png");
            this.imageList1.Images.SetKeyName(57, "card (1).png");
            this.imageList1.Images.SetKeyName(58, "views.png");
            this.imageList1.Images.SetKeyName(59, "checkbox_check.png");
            this.imageList1.Images.SetKeyName(60, "contacts.png");
            this.imageList1.Images.SetKeyName(61, "password (1).png");
            this.imageList1.Images.SetKeyName(62, "password.png");
            this.imageList1.Images.SetKeyName(63, "person_boy (5).png");
            this.imageList1.Images.SetKeyName(64, "ChatGPT Image 19 يوليو 2026، 01_52_21 ص.png");
            this.imageList1.Images.SetKeyName(65, "ChatGPT Image 19 يوليو 2026، 01_39_19 ص.png");
            this.imageList1.Images.SetKeyName(66, "ChatGPT Image 19 يوليو 2026، 01_18_48 ص.png");
            this.imageList1.Images.SetKeyName(67, "ChatGPT Image 19 يوليو 2026، 01_17_30 ص.png");
            this.imageList1.Images.SetKeyName(68, "admin (6).png");
            this.imageList1.Images.SetKeyName(69, "diskette.png");
            this.imageList1.Images.SetKeyName(70, "check.png");
            this.imageList1.Images.SetKeyName(71, "lock_open.png");
            this.imageList1.Images.SetKeyName(72, "next.png");
            this.imageList1.Images.SetKeyName(73, "admin (5).png");
            this.imageList1.Images.SetKeyName(74, "admin (4).png");
            this.imageList1.Images.SetKeyName(75, "ChatGPT Image 17 يوليو 2026، 12_26_47 ص.png");
            this.imageList1.Images.SetKeyName(76, "admin (3).png");
            this.imageList1.Images.SetKeyName(77, "admin (2).png");
            this.imageList1.Images.SetKeyName(78, "DVLD Database.png");
            this.imageList1.Images.SetKeyName(79, "person_boy (4).png");
            this.imageList1.Images.SetKeyName(80, "person_boy (3).png");
            this.imageList1.Images.SetKeyName(81, "person_boy (2).png");
            this.imageList1.Images.SetKeyName(82, "person_boy (1).png");
            this.imageList1.Images.SetKeyName(83, "DVLD.drawio.png");
            this.imageList1.Images.SetKeyName(84, "icons8-badge-100.png");
            this.imageList1.Images.SetKeyName(85, "icons8-badge-50.png");
            this.imageList1.Images.SetKeyName(86, "person_badge_fill_icon_159461.png");
            this.imageList1.Images.SetKeyName(87, "person_man (2).png");
            this.imageList1.Images.SetKeyName(88, "person_man (1).png");
            this.imageList1.Images.SetKeyName(89, "loop (1).png");
            this.imageList1.Images.SetKeyName(90, "loop.png");
            this.imageList1.Images.SetKeyName(91, "down.png");
            this.imageList1.Images.SetKeyName(92, "admin (1).png");
            this.imageList1.Images.SetKeyName(93, "admin.png");
            this.imageList1.Images.SetKeyName(94, "system.png");
            this.imageList1.Images.SetKeyName(95, "power.png");
            this.imageList1.Images.SetKeyName(96, "multiple-users-silhouette.png");
            this.imageList1.Images.SetKeyName(97, "form.png");
            this.imageList1.Images.SetKeyName(98, "resume.png");
            this.imageList1.Images.SetKeyName(99, "driver.png");
            this.imageList1.Images.SetKeyName(100, "administrator.png");
            this.imageList1.Images.SetKeyName(101, "Perosn Wokring.png");
            this.imageList1.Images.SetKeyName(102, "black-steering-wheel-and-car-driver-hands-17665_128.png");
            this.imageList1.Images.SetKeyName(103, "report.png");
            this.imageList1.Images.SetKeyName(104, "Car DVLD Icon.png");
            this.imageList1.Images.SetKeyName(105, "notification-error_114458.ico");
            this.imageList1.Images.SetKeyName(106, "Error_36910.ico");
            this.imageList1.Images.SetKeyName(107, "error.png");
            this.imageList1.Images.SetKeyName(108, "add (1).png");
            this.imageList1.Images.SetKeyName(109, "add.png");
            this.imageList1.Images.SetKeyName(110, "user-256_256.png");
            this.imageList1.Images.SetKeyName(111, "demographic (1).png");
            this.imageList1.Images.SetKeyName(112, "ChatGPT Image 8 يوليو 2026، 01_03_40 م.png");
            this.imageList1.Images.SetKeyName(113, "demographic.png");
            this.imageList1.Images.SetKeyName(114, "ChatGPT Image 7 يوليو 2026، 07_36_32 ص.png");
            this.imageList1.Images.SetKeyName(115, "user-camera-3356_512.png");
            this.imageList1.Images.SetKeyName(116, "person_man.png");
            this.imageList1.Images.SetKeyName(117, "phone.png");
            this.imageList1.Images.SetKeyName(118, "home.png");
            this.imageList1.Images.SetKeyName(119, "geography (1).png");
            this.imageList1.Images.SetKeyName(120, "geography.png");
            this.imageList1.Images.SetKeyName(121, "mail (1).png");
            this.imageList1.Images.SetKeyName(122, "mail.png");
            this.imageList1.Images.SetKeyName(123, "card.png");
            this.imageList1.Images.SetKeyName(124, "person_boy.png");
            this.imageList1.Images.SetKeyName(125, "ChatGPT Image 5 يوليو 2026، 01_03_10 م.png");
            this.imageList1.Images.SetKeyName(126, "ChatGPT Image 5 يوليو 2026، 12_51_21 م.png");
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.pictureBox1);
            this.guna2ShadowPanel1.Controls.Add(this.lbAddUpdate);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(8, 12);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 20;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowDepth = 50;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(982, 124);
            this.guna2ShadowPanel1.TabIndex = 36;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.report__2_;
            this.pictureBox1.Location = new System.Drawing.Point(82, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // lbAddUpdate
            // 
            this.lbAddUpdate.BackColor = System.Drawing.Color.Transparent;
            this.lbAddUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddUpdate.ForeColor = System.Drawing.Color.DarkOrange;
            this.lbAddUpdate.Location = new System.Drawing.Point(196, 34);
            this.lbAddUpdate.Name = "lbAddUpdate";
            this.lbAddUpdate.Size = new System.Drawing.Size(683, 49);
            this.lbAddUpdate.TabIndex = 29;
            this.lbAddUpdate.Text = "Add New Local Driving License Application";
            // 
            // frmAddUpdateLocalDrivingLicenseApplication
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1026, 854);
            this.Controls.Add(this.tcUsers);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddUpdateLocalDrivingLicenseApplication";
            this.Load += new System.EventHandler(this.frmAddUpdateLocalDrivingLicenseApplication_Load);
            this.tcUsers.ResumeLayout(false);
            this.tpPersonalInfo.ResumeLayout(false);
            this.tpLoginInfo.ResumeLayout(false);
            this.pnlUserLoginInfo.ResumeLayout(false);
            this.pnlUserLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tcUsers;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        public Guna.UI2.WinForms.Guna2Button btnNext;
        private People.Controls.cntrlPersonCardWithFilter cntrlPersonCardWithFilter2;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnlUserLoginInfo;
        public Guna.UI2.WinForms.Guna2Button btnClose;
        public Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbConfirmPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbUserName;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbAddUpdate;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ComboBox cbLicenseClass;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbLocalAppID;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbMadeByUser;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbAppFees;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbAppDate;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.ImageList imageList1;
    }
}