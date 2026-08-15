namespace DVLD_Project.Licenses
{
    partial class frmDriversInfo
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
            this.cntrlDriverInfo1 = new DVLD_Project.Drivers.cntrlDriverInfo();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.guna2HtmlLabel19 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pbPersonPhoto = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // cntrlDriverInfo1
            // 
            this.cntrlDriverInfo1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cntrlDriverInfo1.Location = new System.Drawing.Point(0, 118);
            this.cntrlDriverInfo1.Name = "cntrlDriverInfo1";
            this.cntrlDriverInfo1.Size = new System.Drawing.Size(1248, 405);
            this.cntrlDriverInfo1.TabIndex = 0;
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.pbPersonPhoto);
            this.guna2ShadowPanel1.Controls.Add(this.guna2HtmlLabel19);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 20;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowDepth = 90;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(1248, 122);
            this.guna2ShadowPanel1.TabIndex = 61;
            // 
            // guna2HtmlLabel19
            // 
            this.guna2HtmlLabel19.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel19.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.guna2HtmlLabel19.Location = new System.Drawing.Point(461, 32);
            this.guna2HtmlLabel19.Name = "guna2HtmlLabel19";
            this.guna2HtmlLabel19.Size = new System.Drawing.Size(328, 52);
            this.guna2HtmlLabel19.TabIndex = 77;
            this.guna2HtmlLabel19.Text = "Driver License Info";
            // 
            // pbPersonPhoto
            // 
            this.pbPersonPhoto.BackColor = System.Drawing.Color.White;
            this.pbPersonPhoto.FillColor = System.Drawing.Color.Gray;
            this.pbPersonPhoto.Image = global::DVLD_Project.Properties.Resources.id__2_;
            this.pbPersonPhoto.ImageRotate = 0F;
            this.pbPersonPhoto.Location = new System.Drawing.Point(276, 6);
            this.pbPersonPhoto.Name = "pbPersonPhoto";
            this.pbPersonPhoto.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbPersonPhoto.Size = new System.Drawing.Size(179, 106);
            this.pbPersonPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonPhoto.TabIndex = 78;
            this.pbPersonPhoto.TabStop = false;
            // 
            // frmDriversInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1248, 523);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.cntrlDriverInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDriversInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Drivers.cntrlDriverInfo cntrlDriverInfo1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel19;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbPersonPhoto;
    }
}