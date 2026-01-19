namespace SharpLog
{
    partial class UserDataForm
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
            label1 = new Label();
            UserCallSignText = new TextBox();
            OPNameText = new TextBox();
            label2 = new Label();
            label5 = new Label();
            groupBox1 = new GroupBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            groupBox2 = new GroupBox();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label3 = new Label();
            QSLCardAddress = new TextBox();
            SaveChange = new Button();
            CleanText = new Button();
            groupBox1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            groupBox2.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 53);
            label1.Margin = new Padding(3, 5, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(102, 25);
            label1.TabIndex = 0;
            label1.Text = "操作员姓名";
            // 
            // UserCallSignText
            // 
            UserCallSignText.BorderStyle = BorderStyle.None;
            UserCallSignText.CharacterCasing = CharacterCasing.Upper;
            UserCallSignText.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold);
            UserCallSignText.Location = new Point(103, 18);
            UserCallSignText.Name = "UserCallSignText";
            UserCallSignText.Size = new Size(218, 27);
            UserCallSignText.TabIndex = 1;
            // 
            // OPNameText
            // 
            OPNameText.BorderStyle = BorderStyle.None;
            OPNameText.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold);
            OPNameText.Location = new Point(121, 53);
            OPNameText.Margin = new Padding(3, 5, 3, 3);
            OPNameText.Name = "OPNameText";
            OPNameText.Size = new Size(200, 27);
            OPNameText.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 20);
            label2.Margin = new Padding(3, 5, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(84, 25);
            label2.TabIndex = 2;
            label2.Text = "台站呼号";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(87, 399);
            label5.Name = "label5";
            label5.Size = new Size(0, 25);
            label5.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(flowLayoutPanel3);
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(23, 23);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(347, 129);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "基础信息";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(label2);
            flowLayoutPanel3.Controls.Add(UserCallSignText);
            flowLayoutPanel3.Controls.Add(label1);
            flowLayoutPanel3.Controls.Add(OPNameText);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(3, 26);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Padding = new Padding(10, 15, 10, 10);
            flowLayoutPanel3.Size = new Size(341, 100);
            flowLayoutPanel3.TabIndex = 13;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(289, 150);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(300, 150);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(groupBox1);
            flowLayoutPanel2.Controls.Add(groupBox2);
            flowLayoutPanel2.Controls.Add(SaveChange);
            flowLayoutPanel2.Controls.Add(CleanText);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(20);
            flowLayoutPanel2.Size = new Size(395, 406);
            flowLayoutPanel2.TabIndex = 12;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(flowLayoutPanel4);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(23, 158);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(347, 165);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "其他信息";
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(label3);
            flowLayoutPanel4.Controls.Add(QSLCardAddress);
            flowLayoutPanel4.Dock = DockStyle.Fill;
            flowLayoutPanel4.Location = new Point(3, 26);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Padding = new Padding(10, 15, 10, 10);
            flowLayoutPanel4.Size = new Size(341, 136);
            flowLayoutPanel4.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(100, 15);
            label3.Margin = new Padding(90, 0, 0, 5);
            label3.Name = "label3";
            label3.Size = new Size(138, 25);
            label3.TabIndex = 2;
            label3.Text = "QSL卡邮寄地址";
            // 
            // QSLCardAddress
            // 
            QSLCardAddress.BorderStyle = BorderStyle.None;
            QSLCardAddress.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold);
            QSLCardAddress.Location = new Point(10, 45);
            QSLCardAddress.Margin = new Padding(0);
            QSLCardAddress.Multiline = true;
            QSLCardAddress.Name = "QSLCardAddress";
            QSLCardAddress.Size = new Size(320, 81);
            QSLCardAddress.TabIndex = 1;
            // 
            // SaveChange
            // 
            SaveChange.Location = new Point(25, 336);
            SaveChange.Margin = new Padding(5, 10, 3, 3);
            SaveChange.Name = "SaveChange";
            SaveChange.Size = new Size(142, 47);
            SaveChange.TabIndex = 13;
            SaveChange.Text = "提交";
            SaveChange.UseVisualStyleBackColor = true;
            SaveChange.Click += SaveChange_Click;
            // 
            // CleanText
            // 
            CleanText.Location = new Point(224, 336);
            CleanText.Margin = new Padding(54, 10, 3, 3);
            CleanText.Name = "CleanText";
            CleanText.Size = new Size(142, 47);
            CleanText.TabIndex = 14;
            CleanText.Text = "清空";
            CleanText.UseVisualStyleBackColor = true;
            CleanText.Click += CleanText_Click;
            // 
            // UserDataForm
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 406);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(label5);
            Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserDataForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "台站信息";
            groupBox1.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox UserCallSignText;
        private TextBox OPNameText;
        private Label label2;
        private Label label5;
        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private GroupBox groupBox2;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label label3;
        private TextBox QSLCardAddress;
        private Button SaveChange;
        private Button CleanText;
    }
}