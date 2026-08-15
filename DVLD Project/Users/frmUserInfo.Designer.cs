namespace DVLD_Project.Users
{
    partial class frmUserInfo
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
            this.cntrlUserCard1 = new DVLD_Project.Users.Controls.cntrlUserCard();
            this.SuspendLayout();
            // 
            // cntrlUserCard1
            // 
            this.cntrlUserCard1.BackColor = System.Drawing.SystemColors.Control;
            this.cntrlUserCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cntrlUserCard1.Location = new System.Drawing.Point(0, 0);
            this.cntrlUserCard1.Name = "cntrlUserCard1";
            this.cntrlUserCard1.Size = new System.Drawing.Size(855, 656);
            this.cntrlUserCard1.TabIndex = 0;
            this.cntrlUserCard1.Load += new System.EventHandler(this.cntrlUserCard1_Load);
            // 
            // frmUserCard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(855, 656);
            this.Controls.Add(this.cntrlUserCard1);
            this.Name = "frmUserCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUserCard";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.cntrlUserCard cntrlUserCard1;
    }
}