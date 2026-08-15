namespace DVLD_Project.Applications.LocalDrivingLisence
{
    partial class cntrlFindDrivingLicenseApplication
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
            this.guna2ShadowPanel4 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.txtFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cntrlDivingLicneseApplicationInfo1 = new DVLD_Project.Applications.cntrlDivingLicneseApplicationInfo();
            this.guna2ShadowPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel4
            // 
            this.guna2ShadowPanel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel4.Controls.Add(this.txtFilter);
            this.guna2ShadowPanel4.Controls.Add(this.btnSearch);
            this.guna2ShadowPanel4.Controls.Add(this.guna2HtmlLabel9);
            this.guna2ShadowPanel4.Controls.Add(this.cbFilter);
            this.guna2ShadowPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ShadowPanel4.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel4.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel4.Name = "guna2ShadowPanel4";
            this.guna2ShadowPanel4.Radius = 20;
            this.guna2ShadowPanel4.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel4.ShadowDepth = 30;
            this.guna2ShadowPanel4.Size = new System.Drawing.Size(1143, 120);
            this.guna2ShadowPanel4.TabIndex = 5;
            // 
            // txtFilter
            // 
            this.txtFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.txtFilter.BorderRadius = 10;
            this.txtFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilter.DefaultText = "";
            this.txtFilter.DisabledState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.txtFilter.FocusedState.FillColor = System.Drawing.Color.White;
            this.txtFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.txtFilter.IconLeft = global::DVLD_Project.Properties.Resources.card;
            this.txtFilter.IconLeftSize = new System.Drawing.Size(40, 40);
            this.txtFilter.Location = new System.Drawing.Point(325, 32);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(5);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtFilter.PlaceholderText = "Enter Person ID";
            this.txtFilter.SelectedText = "";
            this.txtFilter.Size = new System.Drawing.Size(290, 51);
            this.txtFilter.TabIndex = 28;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Animated = true;
            this.btnSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.btnSearch.BorderRadius = 18;
            this.btnSearch.BorderThickness = 2;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnSearch.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSearch.Image = global::DVLD_Project.Properties.Resources.exam__2_;
            this.btnSearch.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSearch.Location = new System.Drawing.Point(640, 32);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(130)))));
            this.btnSearch.Size = new System.Drawing.Size(66, 62);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Tag = "Male";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // guna2HtmlLabel9
            // 
            this.guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(27, 44);
            this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            this.guna2HtmlLabel9.Size = new System.Drawing.Size(87, 30);
            this.guna2HtmlLabel9.TabIndex = 26;
            this.guna2HtmlLabel9.Text = "Filter By:";
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.cbFilter.BorderRadius = 10;
            this.cbFilter.DisabledState.FillColor = System.Drawing.Color.White;
            this.cbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilter.DropDownHeight = 240;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.DropDownWidth = 200;
            this.cbFilter.FillColor = System.Drawing.Color.LightGray;
            this.cbFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.cbFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.cbFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(0)))));
            this.cbFilter.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbFilter.IntegralHeight = false;
            this.cbFilter.ItemHeight = 25;
            this.cbFilter.Items.AddRange(new object[] {
            "Person ID",
            "National Number"});
            this.cbFilter.Location = new System.Drawing.Point(120, 43);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(191, 31);
            this.cbFilter.StartIndex = 0;
            this.cbFilter.TabIndex = 9;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // cntrlDivingLicneseApplicationInfo1
            // 
            this.cntrlDivingLicneseApplicationInfo1.BackColor = System.Drawing.Color.White;
            this.cntrlDivingLicneseApplicationInfo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cntrlDivingLicneseApplicationInfo1.Location = new System.Drawing.Point(0, 120);
            this.cntrlDivingLicneseApplicationInfo1.Name = "cntrlDivingLicneseApplicationInfo1";
            this.cntrlDivingLicneseApplicationInfo1.Size = new System.Drawing.Size(1143, 356);
            this.cntrlDivingLicneseApplicationInfo1.TabIndex = 6;
            // 
            // cntrlFindDrivingLicenseApplication
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.cntrlDivingLicneseApplicationInfo1);
            this.Controls.Add(this.guna2ShadowPanel4);
            this.Name = "cntrlFindDrivingLicenseApplication";
            this.Size = new System.Drawing.Size(1143, 476);
            this.Load += new System.EventHandler(this.cntrlFindDrivingLicenseApplication_Load);
            this.guna2ShadowPanel4.ResumeLayout(false);
            this.guna2ShadowPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel4;
        public Guna.UI2.WinForms.Guna2TextBox txtFilter;
        public Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private cntrlDivingLicneseApplicationInfo cntrlDivingLicneseApplicationInfo1;
    }
}
