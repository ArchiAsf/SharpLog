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
            SuspendLayout();
            // 
            // LogMainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(18, 20, 24);
            ClientSize = new Size(1344, 712);
            Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            ForeColor = Color.FromArgb(240, 242, 245);
            Margin = new Padding(4);
            MinimumSize = new Size(1366, 768);
            Name = "LogMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SharpLog";
            WindowState = FormWindowState.Minimized;
            ResumeLayout(false);
        }

        #endregion
    }
}
