namespace DVLD_Project.Applications
{
    partial class frmUpdateApplicationTypes
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lbApplicationTypeID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtApplicationTypeFees = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtApplicationTypeTitle = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.guna2ShadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.BorderThickness = 3;
            this.guna2Panel2.Controls.Add(this.btnClose);
            this.guna2Panel2.Controls.Add(this.btnSave);
            this.guna2Panel2.Controls.Add(this.guna2ShadowPanel1);
            this.guna2Panel2.Controls.Add(this.txtApplicationTypeFees);
            this.guna2Panel2.Controls.Add(this.guna2HtmlLabel8);
            this.guna2Panel2.Controls.Add(this.txtApplicationTypeTitle);
            this.guna2Panel2.Controls.Add(this.guna2HtmlLabel6);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(704, 369);
            this.guna2Panel2.TabIndex = 35;
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
            this.btnClose.Location = new System.Drawing.Point(300, 257);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(160, 78);
            this.btnClose.TabIndex = 53;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
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
            this.btnSave.Location = new System.Drawing.Point(498, 257);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(130)))));
            this.btnSave.ShadowDecoration.BorderRadius = 4;
            this.btnSave.ShadowDecoration.Depth = 10;
            this.btnSave.Size = new System.Drawing.Size(193, 78);
            this.btnSave.TabIndex = 52;
            this.btnSave.Tag = "Male";
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.lbApplicationTypeID);
            this.guna2ShadowPanel1.Controls.Add(this.guna2HtmlLabel2);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(14, 3);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 16;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowShift = 3;
            this.guna2ShadowPanel1.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(262, 68);
            this.guna2ShadowPanel1.TabIndex = 49;
            // 
            // lbApplicationTypeID
            // 
            this.lbApplicationTypeID.BackColor = System.Drawing.Color.Transparent;
            this.lbApplicationTypeID.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationTypeID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbApplicationTypeID.Location = new System.Drawing.Point(211, 22);
            this.lbApplicationTypeID.Name = "lbApplicationTypeID";
            this.lbApplicationTypeID.Size = new System.Drawing.Size(38, 27);
            this.lbApplicationTypeID.TabIndex = 32;
            this.lbApplicationTypeID.Text = "N/A";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(15, 22);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(177, 27);
            this.guna2HtmlLabel2.TabIndex = 33;
            this.guna2HtmlLabel2.Text = "Application Type ID:";
            // 
            // txtApplicationTypeFees
            // 
            this.txtApplicationTypeFees.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.txtApplicationTypeFees.BorderRadius = 10;
            this.txtApplicationTypeFees.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtApplicationTypeFees.DefaultText = "";
            this.txtApplicationTypeFees.DisabledState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtApplicationTypeFees.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.txtApplicationTypeFees.FocusedState.FillColor = System.Drawing.Color.White;
            this.txtApplicationTypeFees.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtApplicationTypeFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtApplicationTypeFees.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.txtApplicationTypeFees.IconLeft = global::DVLD_Project.Properties.Resources.price_tag;
            this.txtApplicationTypeFees.IconLeftSize = new System.Drawing.Size(50, 50);
            this.txtApplicationTypeFees.Location = new System.Drawing.Point(138, 164);
            this.txtApplicationTypeFees.Margin = new System.Windows.Forms.Padding(5);
            this.txtApplicationTypeFees.Name = "txtApplicationTypeFees";
            this.txtApplicationTypeFees.PlaceholderText = "Enter Application Type Fees";
            this.txtApplicationTypeFees.SelectedText = "";
            this.txtApplicationTypeFees.Size = new System.Drawing.Size(322, 66);
            this.txtApplicationTypeFees.TabIndex = 48;
            this.txtApplicationTypeFees.Validating += new System.ComponentModel.CancelEventHandler(this.txtApplicationTypeFees_Validating);
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(14, 183);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(54, 32);
            this.guna2HtmlLabel8.TabIndex = 51;
            this.guna2HtmlLabel8.Text = "Fees:";
            // 
            // txtApplicationTypeTitle
            // 
            this.txtApplicationTypeTitle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.txtApplicationTypeTitle.BorderRadius = 10;
            this.txtApplicationTypeTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtApplicationTypeTitle.DefaultText = "";
            this.txtApplicationTypeTitle.DisabledState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtApplicationTypeTitle.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.txtApplicationTypeTitle.FocusedState.FillColor = System.Drawing.Color.White;
            this.txtApplicationTypeTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.txtApplicationTypeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtApplicationTypeTitle.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.txtApplicationTypeTitle.IconLeft = global::DVLD_Project.Properties.Resources.grades_report__3_;
            this.txtApplicationTypeTitle.IconLeftSize = new System.Drawing.Size(50, 50);
            this.txtApplicationTypeTitle.Location = new System.Drawing.Point(138, 79);
            this.txtApplicationTypeTitle.Margin = new System.Windows.Forms.Padding(5);
            this.txtApplicationTypeTitle.Name = "txtApplicationTypeTitle";
            this.txtApplicationTypeTitle.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtApplicationTypeTitle.PlaceholderText = "Enter Application Type Title";
            this.txtApplicationTypeTitle.SelectedText = "";
            this.txtApplicationTypeTitle.Size = new System.Drawing.Size(322, 65);
            this.txtApplicationTypeTitle.TabIndex = 47;
            this.txtApplicationTypeTitle.Validating += new System.ComponentModel.CancelEventHandler(this.txtApplicationTypeTitle_Validating);
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(14, 101);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(61, 32);
            this.guna2HtmlLabel6.TabIndex = 50;
            this.guna2HtmlLabel6.Text = "Title :";
            // 
            // frmUpdateApplicationTypes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(704, 369);
            this.Controls.Add(this.guna2Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUpdateApplicationTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmUpdateApplicationTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        public Guna.UI2.WinForms.Guna2Button btnClose;
        public Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbApplicationTypeID;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        public Guna.UI2.WinForms.Guna2TextBox txtApplicationTypeFees;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        public Guna.UI2.WinForms.Guna2TextBox txtApplicationTypeTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
    }
}