namespace DVLD_Project.People.Controls
{
    partial class cntrlPersonCardWithFilter
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
            this.pnFilter = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btnAddPerson = new Guna.UI2.WinForms.Guna2Button();
            this.txtFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2HtmlToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.cntrlPersonCard1 = new DVLD_Project.Controls.cntrlPersonCard();
            this.pnFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnFilter
            // 
            this.pnFilter.BackColor = System.Drawing.Color.Transparent;
            this.pnFilter.Controls.Add(this.btnAddPerson);
            this.pnFilter.Controls.Add(this.txtFilter);
            this.pnFilter.Controls.Add(this.btnSearch);
            this.pnFilter.Controls.Add(this.guna2HtmlLabel9);
            this.pnFilter.Controls.Add(this.cbFilter);
            this.pnFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnFilter.FillColor = System.Drawing.Color.White;
            this.pnFilter.Location = new System.Drawing.Point(0, 0);
            this.pnFilter.Name = "pnFilter";
            this.pnFilter.Radius = 20;
            this.pnFilter.ShadowColor = System.Drawing.Color.Black;
            this.pnFilter.ShadowDepth = 30;
            this.pnFilter.Size = new System.Drawing.Size(797, 120);
            this.pnFilter.TabIndex = 4;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPerson.Animated = true;
            this.btnAddPerson.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.btnAddPerson.BorderRadius = 18;
            this.btnAddPerson.BorderThickness = 2;
            this.btnAddPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPerson.DisabledState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddPerson.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnAddPerson.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAddPerson.ForeColor = System.Drawing.Color.White;
            this.btnAddPerson.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnAddPerson.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddPerson.Image = global::DVLD_Project.Properties.Resources.person_boy__3_;
            this.btnAddPerson.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAddPerson.Location = new System.Drawing.Point(650, 35);
            this.btnAddPerson.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(130)))));
            this.btnAddPerson.Size = new System.Drawing.Size(65, 51);
            this.btnAddPerson.TabIndex = 29;
            this.btnAddPerson.Tag = "Male";
            this.guna2HtmlToolTip1.SetToolTip(this.btnAddPerson, "Add Person");
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
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
            this.txtFilter.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtFilter.Location = new System.Drawing.Point(319, 35);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(5);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtFilter.PlaceholderText = "Enter Person ID";
            this.txtFilter.SelectedText = "";
            this.txtFilter.Size = new System.Drawing.Size(248, 51);
            this.txtFilter.TabIndex = 28;
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
            this.btnSearch.Image = global::DVLD_Project.Properties.Resources.person_boy__2_;
            this.btnSearch.ImageSize = new System.Drawing.Size(40, 40);
            this.btnSearch.Location = new System.Drawing.Point(577, 35);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(130)))));
            this.btnSearch.Size = new System.Drawing.Size(65, 51);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Tag = "Male";
            this.guna2HtmlToolTip1.SetToolTip(this.btnSearch, "Search for person");
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // guna2HtmlToolTip1
            // 
            this.guna2HtmlToolTip1.AllowLinksHandling = true;
            this.guna2HtmlToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
            // 
            // cntrlPersonCard1
            // 
            this.cntrlPersonCard1.BackColor = System.Drawing.Color.Transparent;
            this.cntrlPersonCard1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cntrlPersonCard1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cntrlPersonCard1.Location = new System.Drawing.Point(0, 127);
            this.cntrlPersonCard1.Margin = new System.Windows.Forms.Padding(4);
            this.cntrlPersonCard1.Name = "cntrlPersonCard1";
            this.cntrlPersonCard1.Size = new System.Drawing.Size(797, 541);
            this.cntrlPersonCard1.TabIndex = 0;
            this.cntrlPersonCard1.Load += new System.EventHandler(this.cntrlPersonCard1_Load);
            // 
            // cntrlPersonCardWithFilter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnFilter);
            this.Controls.Add(this.cntrlPersonCard1);
            this.Name = "cntrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(797, 668);
            this.pnFilter.ResumeLayout(false);
            this.pnFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DVLD_Project.Controls.cntrlPersonCard cntrlPersonCard1;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnFilter;
        public Guna.UI2.WinForms.Guna2TextBox txtFilter;
        public Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        public Guna.UI2.WinForms.Guna2Button btnAddPerson;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2HtmlToolTip guna2HtmlToolTip1;
    }
}
