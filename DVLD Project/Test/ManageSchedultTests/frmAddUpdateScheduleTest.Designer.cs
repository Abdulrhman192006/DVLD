namespace DVLD_Project.Test.ManageSchedultTests
{
    partial class frmAddUpdateScheduleTest
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
            this.cntrlShceduleTest1 = new DVLD_Project.Test.ManageSchedultTests.cntrlShceduleTest();
            this.SuspendLayout();
            // 
            // cntrlShceduleTest1
            // 
            this.cntrlShceduleTest1.BackColor = System.Drawing.Color.White;
            this.cntrlShceduleTest1.Location = new System.Drawing.Point(0, 0);
            this.cntrlShceduleTest1.Name = "cntrlShceduleTest1";
            this.cntrlShceduleTest1.Size = new System.Drawing.Size(764, 807);
            this.cntrlShceduleTest1.TabIndex = 0;
            this.cntrlShceduleTest1.TestTypeID = clsTestTypes.TestType.PracticalTest;
            // 
            // frmAddUpdateScheduleTest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(764, 800);
            this.Controls.Add(this.cntrlShceduleTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdateScheduleTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddUpdateScheduleTest";
            this.Load += new System.EventHandler(this.frmAddUpdateScheduleTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private cntrlShceduleTest cntrlShceduleTest1;
    }
}