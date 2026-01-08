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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogMainForm));
            toolStrip1 = new ToolStrip();
            OptionBtn = new ToolStripDropDownButton();
            toolStripSeparator1 = new ToolStripSeparator();
            HelpBtn = new ToolStripDropDownButton();
            CallSignLab = new ToolStripLabel();
            LogShowList = new FlowLayoutPanel();
            panel1 = new Panel();
            groupBox5 = new GroupBox();
            groupBox6 = new GroupBox();
            QTHInPut = new TextBox();
            groupBox4 = new GroupBox();
            groupBox3 = new GroupBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            RRST_R = new NumericUpDown();
            RRST_S = new NumericUpDown();
            RRST_T = new NumericUpDown();
            label6 = new Label();
            groupBox2 = new GroupBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            RST_R = new NumericUpDown();
            RST_S = new NumericUpDown();
            RST_T = new NumericUpDown();
            label4 = new Label();
            FrequencyInput = new ComboBox();
            label5 = new Label();
            groupBox1 = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            FmMode = new RadioButton();
            AMMode = new RadioButton();
            SSBMode = new RadioButton();
            FT8Mode = new RadioButton();
            FT4Mode = new RadioButton();
            SSTVMode = new RadioButton();
            CWMode = new RadioButton();
            DMRMode = new RadioButton();
            C4FMMode = new RadioButton();
            D_STARMode = new RadioButton();
            NXDNMode = new RadioButton();
            radioButton11 = new RadioButton();
            radioButton12 = new RadioButton();
            CallSignInput = new TextBox();
            label3 = new Label();
            EndTime = new DateTimePicker();
            EndData = new DateTimePicker();
            label2 = new Label();
            StartTime = new DateTimePicker();
            StartData = new DateTimePicker();
            label1 = new Label();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RRST_R).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RRST_S).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RRST_T).BeginInit();
            groupBox2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RST_R).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RST_S).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RST_T).BeginInit();
            groupBox1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(30, 30);
            toolStrip1.Items.AddRange(new ToolStripItem[] { OptionBtn, toolStripSeparator1, HelpBtn, CallSignLab });
            toolStrip1.Location = new Point(8, 8);
            toolStrip1.Margin = new Padding(0, 0, 0, 8);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(2522, 39);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // OptionBtn
            // 
            OptionBtn.Image = (Image)resources.GetObject("OptionBtn.Image");
            OptionBtn.ImageTransparentColor = Color.Magenta;
            OptionBtn.Name = "OptionBtn";
            OptionBtn.Size = new Size(94, 34);
            OptionBtn.Text = "选项";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // HelpBtn
            // 
            HelpBtn.Image = (Image)resources.GetObject("HelpBtn.Image");
            HelpBtn.ImageTransparentColor = Color.Magenta;
            HelpBtn.Name = "HelpBtn";
            HelpBtn.Size = new Size(94, 34);
            HelpBtn.Text = "帮助";
            // 
            // CallSignLab
            // 
            CallSignLab.Alignment = ToolStripItemAlignment.Right;
            CallSignLab.DisplayStyle = ToolStripItemDisplayStyle.Text;
            CallSignLab.Image = (Image)resources.GetObject("CallSignLab.Image");
            CallSignLab.ImageTransparentColor = Color.Magenta;
            CallSignLab.Name = "CallSignLab";
            CallSignLab.Size = new Size(46, 34);
            CallSignLab.Text = "呼号";
            // 
            // LogShowList
            // 
            LogShowList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogShowList.AutoScroll = true;
            LogShowList.AutoSize = true;
            LogShowList.Location = new Point(11, 60);
            LogShowList.Margin = new Padding(3, 5, 7, 3);
            LogShowList.Name = "LogShowList";
            LogShowList.Padding = new Padding(3);
            LogShowList.Size = new Size(2028, 1313);
            LogShowList.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.AutoScrollMargin = new Size(0, 20);
            panel1.Controls.Add(groupBox5);
            panel1.Controls.Add(groupBox4);
            panel1.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            panel1.Location = new Point(2053, 60);
            panel1.Margin = new Padding(7, 5, 3, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(477, 1313);
            panel1.TabIndex = 2;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(groupBox6);
            groupBox5.Dock = DockStyle.Top;
            groupBox5.Location = new Point(20, 577);
            groupBox5.Margin = new Padding(3, 20, 3, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(10, 3, 10, 3);
            groupBox5.Size = new Size(437, 713);
            groupBox5.TabIndex = 26;
            groupBox5.TabStop = false;
            groupBox5.Text = "其他通联信息";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(QTHInPut);
            groupBox6.Dock = DockStyle.Top;
            groupBox6.Location = new Point(10, 30);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(5);
            groupBox6.Size = new Size(417, 153);
            groupBox6.TabIndex = 0;
            groupBox6.TabStop = false;
            groupBox6.Text = "QTH";
            // 
            // QTHInPut
            // 
            QTHInPut.BorderStyle = BorderStyle.FixedSingle;
            QTHInPut.Dock = DockStyle.Fill;
            QTHInPut.Location = new Point(5, 32);
            QTHInPut.Multiline = true;
            QTHInPut.Name = "QTHInPut";
            QTHInPut.Size = new Size(407, 116);
            QTHInPut.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.BackgroundImageLayout = ImageLayout.Center;
            groupBox4.Controls.Add(groupBox3);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(groupBox2);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(FrequencyInput);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(groupBox1);
            groupBox4.Controls.Add(CallSignInput);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(EndTime);
            groupBox4.Controls.Add(EndData);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(StartTime);
            groupBox4.Controls.Add(StartData);
            groupBox4.Controls.Add(label1);
            groupBox4.Dock = DockStyle.Top;
            groupBox4.Location = new Point(20, 20);
            groupBox4.Margin = new Padding(3, 3, 3, 20);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(10, 3, 10, 3);
            groupBox4.Size = new Size(437, 557);
            groupBox4.TabIndex = 25;
            groupBox4.TabStop = false;
            groupBox4.Text = "基本通联信息";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(flowLayoutPanel3);
            groupBox3.Location = new Point(222, 467);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(192, 73);
            groupBox3.TabIndex = 39;
            groupBox3.TabStop = false;
            groupBox3.Text = "RRST";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(RRST_R);
            flowLayoutPanel3.Controls.Add(RRST_S);
            flowLayoutPanel3.Controls.Add(RRST_T);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(3, 30);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(186, 40);
            flowLayoutPanel3.TabIndex = 23;
            // 
            // RRST_R
            // 
            RRST_R.BorderStyle = BorderStyle.FixedSingle;
            RRST_R.Cursor = Cursors.Hand;
            RRST_R.Location = new Point(3, 3);
            RRST_R.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            RRST_R.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RRST_R.Name = "RRST_R";
            RRST_R.Size = new Size(56, 34);
            RRST_R.TabIndex = 22;
            RRST_R.TextAlign = HorizontalAlignment.Center;
            RRST_R.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // RRST_S
            // 
            RRST_S.BorderStyle = BorderStyle.FixedSingle;
            RRST_S.Cursor = Cursors.Hand;
            RRST_S.Location = new Point(65, 3);
            RRST_S.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            RRST_S.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RRST_S.Name = "RRST_S";
            RRST_S.Size = new Size(56, 34);
            RRST_S.TabIndex = 23;
            RRST_S.TextAlign = HorizontalAlignment.Center;
            RRST_S.Value = new decimal(new int[] { 9, 0, 0, 0 });
            // 
            // RRST_T
            // 
            RRST_T.BorderStyle = BorderStyle.FixedSingle;
            RRST_T.Cursor = Cursors.Hand;
            RRST_T.Location = new Point(127, 3);
            RRST_T.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            RRST_T.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RRST_T.Name = "RRST_T";
            RRST_T.Size = new Size(56, 34);
            RRST_T.TabIndex = 24;
            RRST_T.TextAlign = HorizontalAlignment.Center;
            RRST_T.Value = new decimal(new int[] { 9, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(252, 482);
            label6.Name = "label6";
            label6.Size = new Size(0, 28);
            label6.TabIndex = 38;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(flowLayoutPanel2);
            groupBox2.Location = new Point(27, 467);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(192, 73);
            groupBox2.TabIndex = 37;
            groupBox2.TabStop = false;
            groupBox2.Text = "RST";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(RST_R);
            flowLayoutPanel2.Controls.Add(RST_S);
            flowLayoutPanel2.Controls.Add(RST_T);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(3, 30);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(186, 40);
            flowLayoutPanel2.TabIndex = 23;
            // 
            // RST_R
            // 
            RST_R.BorderStyle = BorderStyle.FixedSingle;
            RST_R.Cursor = Cursors.Hand;
            RST_R.Location = new Point(3, 3);
            RST_R.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            RST_R.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RST_R.Name = "RST_R";
            RST_R.Size = new Size(56, 34);
            RST_R.TabIndex = 22;
            RST_R.TextAlign = HorizontalAlignment.Center;
            RST_R.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // RST_S
            // 
            RST_S.BorderStyle = BorderStyle.FixedSingle;
            RST_S.Cursor = Cursors.Hand;
            RST_S.Location = new Point(65, 3);
            RST_S.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            RST_S.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RST_S.Name = "RST_S";
            RST_S.Size = new Size(56, 34);
            RST_S.TabIndex = 23;
            RST_S.TextAlign = HorizontalAlignment.Center;
            RST_S.Value = new decimal(new int[] { 9, 0, 0, 0 });
            // 
            // RST_T
            // 
            RST_T.BorderStyle = BorderStyle.FixedSingle;
            RST_T.Cursor = Cursors.Hand;
            RST_T.Location = new Point(127, 3);
            RST_T.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            RST_T.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            RST_T.Name = "RST_T";
            RST_T.Size = new Size(56, 34);
            RST_T.TabIndex = 24;
            RST_T.TextAlign = HorizontalAlignment.Center;
            RST_T.Value = new decimal(new int[] { 9, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(63, 482);
            label4.Name = "label4";
            label4.Size = new Size(0, 28);
            label4.TabIndex = 36;
            // 
            // FrequencyInput
            // 
            FrequencyInput.BackColor = SystemColors.Control;
            FrequencyInput.FormattingEnabled = true;
            FrequencyInput.Location = new Point(142, 425);
            FrequencyInput.Name = "FrequencyInput";
            FrequencyInput.Size = new Size(257, 36);
            FrequencyInput.TabIndex = 35;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 428);
            label5.Name = "label5";
            label5.Size = new Size(96, 28);
            label5.TabIndex = 33;
            label5.Text = "频       率";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Location = new Point(10, 176);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(417, 240);
            groupBox1.TabIndex = 34;
            groupBox1.TabStop = false;
            groupBox1.Text = "模    式";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(FmMode);
            flowLayoutPanel1.Controls.Add(AMMode);
            flowLayoutPanel1.Controls.Add(SSBMode);
            flowLayoutPanel1.Controls.Add(CWMode);
            flowLayoutPanel1.Controls.Add(FT8Mode);
            flowLayoutPanel1.Controls.Add(FT4Mode);
            flowLayoutPanel1.Controls.Add(SSTVMode);
            flowLayoutPanel1.Controls.Add(DMRMode);
            flowLayoutPanel1.Controls.Add(C4FMMode);
            flowLayoutPanel1.Controls.Add(D_STARMode);
            flowLayoutPanel1.Controls.Add(NXDNMode);
            flowLayoutPanel1.Controls.Add(radioButton11);
            flowLayoutPanel1.Controls.Add(radioButton12);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 30);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Size = new Size(411, 207);
            flowLayoutPanel1.TabIndex = 18;
            // 
            // FmMode
            // 
            FmMode.AutoSize = true;
            FmMode.Location = new Point(13, 13);
            FmMode.Name = "FmMode";
            FmMode.Size = new Size(71, 32);
            FmMode.TabIndex = 17;
            FmMode.TabStop = true;
            FmMode.Text = "FM";
            FmMode.UseVisualStyleBackColor = true;
            // 
            // AMMode
            // 
            AMMode.AutoSize = true;
            AMMode.Location = new Point(90, 13);
            AMMode.Name = "AMMode";
            AMMode.Size = new Size(75, 32);
            AMMode.TabIndex = 18;
            AMMode.TabStop = true;
            AMMode.Text = "AM";
            AMMode.UseVisualStyleBackColor = true;
            // 
            // SSBMode
            // 
            SSBMode.AutoSize = true;
            SSBMode.Location = new Point(171, 13);
            SSBMode.Name = "SSBMode";
            SSBMode.Size = new Size(77, 32);
            SSBMode.TabIndex = 16;
            SSBMode.TabStop = true;
            SSBMode.Text = "SSB";
            SSBMode.UseVisualStyleBackColor = true;
            // 
            // FT8Mode
            // 
            FT8Mode.AutoSize = true;
            FT8Mode.Location = new Point(13, 51);
            FT8Mode.Name = "FT8Mode";
            FT8Mode.Size = new Size(75, 32);
            FT8Mode.TabIndex = 19;
            FT8Mode.TabStop = true;
            FT8Mode.Text = "FT8";
            FT8Mode.UseVisualStyleBackColor = true;
            // 
            // FT4Mode
            // 
            FT4Mode.AutoSize = true;
            FT4Mode.Location = new Point(94, 51);
            FT4Mode.Name = "FT4Mode";
            FT4Mode.Size = new Size(75, 32);
            FT4Mode.TabIndex = 21;
            FT4Mode.TabStop = true;
            FT4Mode.Text = "FT4";
            FT4Mode.UseVisualStyleBackColor = true;
            // 
            // SSTVMode
            // 
            SSTVMode.AutoSize = true;
            flowLayoutPanel1.SetFlowBreak(SSTVMode, true);
            SSTVMode.Location = new Point(175, 51);
            SSTVMode.Name = "SSTVMode";
            SSTVMode.Size = new Size(91, 32);
            SSTVMode.TabIndex = 20;
            SSTVMode.TabStop = true;
            SSTVMode.Text = "SSTV";
            SSTVMode.UseVisualStyleBackColor = true;
            // 
            // CWMode
            // 
            CWMode.AutoSize = true;
            CWMode.Location = new Point(254, 13);
            CWMode.Name = "CWMode";
            CWMode.Size = new Size(74, 32);
            CWMode.TabIndex = 22;
            CWMode.TabStop = true;
            CWMode.Text = "CW";
            CWMode.UseVisualStyleBackColor = true;
            // 
            // DMRMode
            // 
            DMRMode.AutoSize = true;
            DMRMode.Location = new Point(13, 89);
            DMRMode.Name = "DMRMode";
            DMRMode.Size = new Size(91, 32);
            DMRMode.TabIndex = 25;
            DMRMode.TabStop = true;
            DMRMode.Text = "DMR";
            DMRMode.UseVisualStyleBackColor = true;
            // 
            // C4FMMode
            // 
            C4FMMode.AutoSize = true;
            C4FMMode.Location = new Point(110, 89);
            C4FMMode.Name = "C4FMMode";
            C4FMMode.Size = new Size(98, 32);
            C4FMMode.TabIndex = 23;
            C4FMMode.TabStop = true;
            C4FMMode.Text = "C4FM";
            C4FMMode.UseVisualStyleBackColor = true;
            // 
            // D_STARMode
            // 
            D_STARMode.AutoSize = true;
            D_STARMode.Location = new Point(214, 89);
            D_STARMode.Name = "D_STARMode";
            D_STARMode.Size = new Size(120, 32);
            D_STARMode.TabIndex = 24;
            D_STARMode.TabStop = true;
            D_STARMode.Text = "D-STAR";
            D_STARMode.UseVisualStyleBackColor = true;
            // 
            // NXDNMode
            // 
            NXDNMode.AutoSize = true;
            flowLayoutPanel1.SetFlowBreak(NXDNMode, true);
            NXDNMode.Location = new Point(13, 127);
            NXDNMode.Name = "NXDNMode";
            NXDNMode.Size = new Size(105, 32);
            NXDNMode.TabIndex = 26;
            NXDNMode.TabStop = true;
            NXDNMode.Text = "NXDN";
            NXDNMode.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            radioButton11.AutoSize = true;
            radioButton11.Location = new Point(13, 165);
            radioButton11.Name = "radioButton11";
            radioButton11.Size = new Size(108, 32);
            radioButton11.TabIndex = 27;
            radioButton11.TabStop = true;
            radioButton11.Text = "Packet";
            radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            radioButton12.AutoSize = true;
            radioButton12.Location = new Point(127, 165);
            radioButton12.Name = "radioButton12";
            radioButton12.Size = new Size(126, 32);
            radioButton12.TabIndex = 28;
            radioButton12.TabStop = true;
            radioButton12.Text = "MSK144";
            radioButton12.UseVisualStyleBackColor = true;
            // 
            // CallSignInput
            // 
            CallSignInput.BorderStyle = BorderStyle.FixedSingle;
            CallSignInput.CharacterCasing = CharacterCasing.Upper;
            CallSignInput.Location = new Point(142, 131);
            CallSignInput.Multiline = true;
            CallSignInput.Name = "CallSignInput";
            CallSignInput.Size = new Size(257, 35);
            CallSignInput.TabIndex = 32;
            CallSignInput.TextAlign = HorizontalAlignment.Center;
            CallSignInput.WordWrap = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 135);
            label3.Name = "label3";
            label3.Size = new Size(96, 28);
            label3.TabIndex = 31;
            label3.Text = "对方呼号";
            // 
            // EndTime
            // 
            EndTime.CustomFormat = "HH:mm";
            EndTime.Format = DateTimePickerFormat.Custom;
            EndTime.Location = new Point(304, 88);
            EndTime.Name = "EndTime";
            EndTime.ShowUpDown = true;
            EndTime.Size = new Size(95, 34);
            EndTime.TabIndex = 30;
            // 
            // EndData
            // 
            EndData.CustomFormat = "yyyy-MM-dd";
            EndData.Format = DateTimePickerFormat.Custom;
            EndData.Location = new Point(142, 88);
            EndData.Name = "EndData";
            EndData.ShowUpDown = true;
            EndData.Size = new Size(156, 34);
            EndData.TabIndex = 29;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 90);
            label2.Name = "label2";
            label2.Size = new Size(96, 28);
            label2.TabIndex = 26;
            label2.Text = "结束时间";
            // 
            // StartTime
            // 
            StartTime.CustomFormat = "HH:mm";
            StartTime.Format = DateTimePickerFormat.Custom;
            StartTime.Location = new Point(304, 39);
            StartTime.Name = "StartTime";
            StartTime.ShowUpDown = true;
            StartTime.Size = new Size(95, 34);
            StartTime.TabIndex = 28;
            // 
            // StartData
            // 
            StartData.CustomFormat = "yyyy-MM-dd";
            StartData.Format = DateTimePickerFormat.Custom;
            StartData.Location = new Point(142, 39);
            StartData.Name = "StartData";
            StartData.ShowUpDown = true;
            StartData.Size = new Size(156, 34);
            StartData.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 42);
            label1.Name = "label1";
            label1.Size = new Size(96, 28);
            label1.TabIndex = 25;
            label1.Text = "开始时间";
            // 
            // LogMainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(2538, 1384);
            Controls.Add(panel1);
            Controls.Add(LogShowList);
            Controls.Add(toolStrip1);
            Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Margin = new Padding(4);
            MinimumSize = new Size(1366, 768);
            Name = "LogMainForm";
            Padding = new Padding(8);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SharpLog";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)RRST_R).EndInit();
            ((System.ComponentModel.ISupportInitialize)RRST_S).EndInit();
            ((System.ComponentModel.ISupportInitialize)RRST_T).EndInit();
            groupBox2.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)RST_R).EndInit();
            ((System.ComponentModel.ISupportInitialize)RST_S).EndInit();
            ((System.ComponentModel.ISupportInitialize)RST_T).EndInit();
            groupBox1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripDropDownButton OptionBtn;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton HelpBtn;
        private ToolStripLabel CallSignLab;
        private FlowLayoutPanel LogShowList;
        private Panel panel1;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private FlowLayoutPanel flowLayoutPanel3;
        private NumericUpDown RRST_R;
        private NumericUpDown RRST_S;
        private NumericUpDown RRST_T;
        private Label label6;
        private GroupBox groupBox2;
        private FlowLayoutPanel flowLayoutPanel2;
        private NumericUpDown RST_R;
        private NumericUpDown RST_S;
        private NumericUpDown RST_T;
        private Label label4;
        private ComboBox FrequencyInput;
        private Label label5;
        private GroupBox groupBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private RadioButton FmMode;
        private RadioButton AMMode;
        private RadioButton SSBMode;
        private RadioButton FT8Mode;
        private RadioButton FT4Mode;
        private RadioButton SSTVMode;
        private RadioButton CWMode;
        private RadioButton DMRMode;
        private RadioButton C4FMMode;
        private RadioButton D_STARMode;
        private RadioButton NXDNMode;
        private RadioButton radioButton11;
        private RadioButton radioButton12;
        private TextBox CallSignInput;
        private Label label3;
        private DateTimePicker EndTime;
        private DateTimePicker EndData;
        private Label label2;
        private DateTimePicker StartTime;
        private DateTimePicker StartData;
        private Label label1;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private TextBox QTHInPut;
    }
}
