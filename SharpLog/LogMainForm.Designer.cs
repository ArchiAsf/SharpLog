namespace SharpLog
{
    partial class LogMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(876, 363);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(300, 150);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 37);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(292, 109);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 33);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(292, 113);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // LogMainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1344, 712);
            Controls.Add(tabControl1);
            Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Margin = new Padding(4);
            MinimumSize = new Size(1366, 768);
            Name = "LogMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SharpLog";
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}
