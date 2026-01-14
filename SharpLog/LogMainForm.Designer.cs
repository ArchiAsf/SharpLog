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
            SetStationInformation = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            HelpBtn = new ToolStripDropDownButton();
            LogShowList = new FlowLayoutPanel();
            panel1 = new Panel();
            groupBox13 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            IsRelayStation = new CheckBox();
            IsSatellite = new CheckBox();
            IsQRP = new CheckBox();
            IsQSL = new CheckBox();
            IsEME = new CheckBox();
            IsMeteoricTrail = new CheckBox();
            groupBox5 = new GroupBox();
            groupBox12 = new GroupBox();
            RMKSInPut = new TextBox();
            groupBox10 = new GroupBox();
            OPInPut = new TextBox();
            groupBox11 = new GroupBox();
            label10 = new Label();
            HeightInPut = new TextBox();
            groupBox9 = new GroupBox();
            ANTInPut = new TextBox();
            groupBox8 = new GroupBox();
            label7 = new Label();
            PowInPut = new TextBox();
            groupBox7 = new GroupBox();
            RIGInPut = new TextBox();
            groupBox6 = new GroupBox();
            QTHInPut = new TextBox();
            label11 = new Label();
            SaveLogBtn = new Button();
            label9 = new Label();
            groupBox4 = new GroupBox();
            label8 = new Label();
            groupBox3 = new GroupBox();
            RRSTBox = new FlowLayoutPanel();
            RRST_R = new NumericUpDown();
            RRST_S = new NumericUpDown();
            RRST_T = new NumericUpDown();
            label6 = new Label();
            groupBox2 = new GroupBox();
            RSTBox = new FlowLayoutPanel();
            RST_R = new NumericUpDown();
            RST_S = new NumericUpDown();
            RST_T = new NumericUpDown();
            label4 = new Label();
            FrequencyInput = new ComboBox();
            label5 = new Label();
            groupBox1 = new GroupBox();
            ModeSelectBox = new FlowLayoutPanel();
            FmMode = new RadioButton();
            AMMode = new RadioButton();
            SSBMode = new RadioButton();
            CWMode = new RadioButton();
            FT8Mode = new RadioButton();
            FT4Mode = new RadioButton();
            SSTVMode = new RadioButton();
            DMRMode = new RadioButton();
            C4FMMode = new RadioButton();
            D_STARMode = new RadioButton();
            NXDNMode = new RadioButton();
            PacketMode = new RadioButton();
            MSK144Mode = new RadioButton();
            CallSignInput = new TextBox();
            label3 = new Label();
            EndTime = new DateTimePicker();
            EndData = new DateTimePicker();
            label2 = new Label();
            StartTime = new DateTimePicker();
            StartData = new DateTimePicker();
            label1 = new Label();
            toolStrip2 = new ToolStrip();
            CallSignLab = new ToolStripLabel();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox13.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox12.SuspendLayout();
            groupBox10.SuspendLayout();
            groupBox11.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            RRSTBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RRST_R).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RRST_S).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RRST_T).BeginInit();
            groupBox2.SuspendLayout();
            RSTBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RST_R).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RST_S).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RST_T).BeginInit();
            groupBox1.SuspendLayout();
            ModeSelectBox.SuspendLayout();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(30, 30);
            toolStrip1.Items.AddRange(new ToolStripItem[] { OptionBtn, toolStripSeparator1, HelpBtn });
            toolStrip1.Location = new Point(8, 8);
            toolStrip1.Margin = new Padding(0, 0, 0, 8);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1328, 39);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // OptionBtn
            // 
            OptionBtn.DropDownItems.AddRange(new ToolStripItem[] { SetStationInformation });
            OptionBtn.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold);
            OptionBtn.Image = Properties.Resources.shezhi;
            OptionBtn.ImageTransparentColor = Color.Magenta;
            OptionBtn.Name = "OptionBtn";
            OptionBtn.Size = new Size(108, 34);
            OptionBtn.Text = " 选项";
            // 
            // SetStationInformation
            // 
            SetStationInformation.Name = "SetStationInformation";
            SetStationInformation.Size = new Size(240, 36);
            SetStationInformation.Text = "设置台站信息";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // HelpBtn
            // 
            HelpBtn.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold);
            HelpBtn.Image = Properties.Resources.bangzhu;
            HelpBtn.ImageTransparentColor = Color.Magenta;
            HelpBtn.Name = "HelpBtn";
            HelpBtn.Size = new Size(108, 34);
            HelpBtn.Text = " 帮助";
            HelpBtn.Click += HelpBtn_Click;
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
            LogShowList.Size = new Size(830, 652);
            LogShowList.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.AutoScrollMargin = new Size(0, 20);
            panel1.Controls.Add(groupBox13);
            panel1.Controls.Add(groupBox5);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(SaveLogBtn);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(groupBox4);
            panel1.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            panel1.Location = new Point(855, 60);
            panel1.Margin = new Padding(7, 5, 3, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(481, 652);
            panel1.TabIndex = 2;
            // 
            // groupBox13
            // 
            groupBox13.Controls.Add(tableLayoutPanel1);
            groupBox13.Dock = DockStyle.Top;
            groupBox13.Location = new Point(20, 1249);
            groupBox13.Name = "groupBox13";
            groupBox13.Size = new Size(415, 188);
            groupBox13.TabIndex = 27;
            groupBox13.TabStop = false;
            groupBox13.Text = "通联标记";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(IsRelayStation, 1, 1);
            tableLayoutPanel1.Controls.Add(IsSatellite, 0, 1);
            tableLayoutPanel1.Controls.Add(IsQRP, 2, 0);
            tableLayoutPanel1.Controls.Add(IsQSL, 0, 0);
            tableLayoutPanel1.Controls.Add(IsEME, 1, 0);
            tableLayoutPanel1.Controls.Add(IsMeteoricTrail, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 30);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(20);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(409, 155);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // IsRelayStation
            // 
            IsRelayStation.Anchor = AnchorStyles.None;
            IsRelayStation.AutoSize = true;
            IsRelayStation.Location = new Point(164, 90);
            IsRelayStation.Name = "IsRelayStation";
            IsRelayStation.Size = new Size(80, 32);
            IsRelayStation.TabIndex = 4;
            IsRelayStation.Text = "中继";
            IsRelayStation.UseVisualStyleBackColor = true;
            // 
            // IsSatellite
            // 
            IsSatellite.Anchor = AnchorStyles.None;
            IsSatellite.AutoSize = true;
            IsSatellite.Location = new Point(41, 90);
            IsSatellite.Name = "IsSatellite";
            IsSatellite.Size = new Size(80, 32);
            IsSatellite.TabIndex = 3;
            IsSatellite.Text = "卫星";
            IsSatellite.UseVisualStyleBackColor = true;
            // 
            // IsQRP
            // 
            IsQRP.Anchor = AnchorStyles.None;
            IsQRP.AutoSize = true;
            IsQRP.Location = new Point(285, 32);
            IsQRP.Name = "IsQRP";
            IsQRP.Size = new Size(84, 32);
            IsQRP.TabIndex = 2;
            IsQRP.Text = "QRP";
            IsQRP.UseVisualStyleBackColor = true;
            // 
            // IsQSL
            // 
            IsQSL.Anchor = AnchorStyles.None;
            IsQSL.AutoSize = true;
            IsQSL.Location = new Point(42, 32);
            IsQSL.Name = "IsQSL";
            IsQSL.Size = new Size(79, 32);
            IsQSL.TabIndex = 0;
            IsQSL.Text = "QSL";
            IsQSL.UseVisualStyleBackColor = true;
            // 
            // IsEME
            // 
            IsEME.Anchor = AnchorStyles.None;
            IsEME.AutoSize = true;
            IsEME.Location = new Point(162, 32);
            IsEME.Name = "IsEME";
            IsEME.Size = new Size(84, 32);
            IsEME.TabIndex = 6;
            IsEME.Text = "EME";
            IsEME.UseVisualStyleBackColor = true;
            // 
            // IsMeteoricTrail
            // 
            IsMeteoricTrail.Anchor = AnchorStyles.None;
            IsMeteoricTrail.AutoSize = true;
            IsMeteoricTrail.Location = new Point(287, 90);
            IsMeteoricTrail.Name = "IsMeteoricTrail";
            IsMeteoricTrail.Size = new Size(80, 32);
            IsMeteoricTrail.TabIndex = 7;
            IsMeteoricTrail.Text = "流星";
            IsMeteoricTrail.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(groupBox12);
            groupBox5.Controls.Add(groupBox10);
            groupBox5.Controls.Add(groupBox11);
            groupBox5.Controls.Add(groupBox9);
            groupBox5.Controls.Add(groupBox8);
            groupBox5.Controls.Add(groupBox7);
            groupBox5.Controls.Add(groupBox6);
            groupBox5.Dock = DockStyle.Top;
            groupBox5.Location = new Point(20, 657);
            groupBox5.Margin = new Padding(3, 20, 3, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(10, 3, 10, 3);
            groupBox5.Size = new Size(415, 592);
            groupBox5.TabIndex = 26;
            groupBox5.TabStop = false;
            groupBox5.Text = "其他通联信息";
            // 
            // groupBox12
            // 
            groupBox12.Controls.Add(RMKSInPut);
            groupBox12.Location = new Point(10, 428);
            groupBox12.Name = "groupBox12";
            groupBox12.Padding = new Padding(5);
            groupBox12.Size = new Size(395, 153);
            groupBox12.TabIndex = 7;
            groupBox12.TabStop = false;
            groupBox12.Text = "备注信息";
            // 
            // RMKSInPut
            // 
            RMKSInPut.BorderStyle = BorderStyle.FixedSingle;
            RMKSInPut.Dock = DockStyle.Fill;
            RMKSInPut.Location = new Point(5, 32);
            RMKSInPut.Multiline = true;
            RMKSInPut.Name = "RMKSInPut";
            RMKSInPut.Size = new Size(385, 116);
            RMKSInPut.TabIndex = 0;
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(OPInPut);
            groupBox10.Location = new Point(139, 347);
            groupBox10.Name = "groupBox10";
            groupBox10.Padding = new Padding(5);
            groupBox10.Size = new Size(266, 75);
            groupBox10.TabIndex = 6;
            groupBox10.TabStop = false;
            groupBox10.Text = "OP";
            // 
            // OPInPut
            // 
            OPInPut.BorderStyle = BorderStyle.FixedSingle;
            OPInPut.Dock = DockStyle.Fill;
            OPInPut.Location = new Point(5, 32);
            OPInPut.Name = "OPInPut";
            OPInPut.Size = new Size(256, 34);
            OPInPut.TabIndex = 0;
            // 
            // groupBox11
            // 
            groupBox11.Controls.Add(label10);
            groupBox11.Controls.Add(HeightInPut);
            groupBox11.Location = new Point(10, 347);
            groupBox11.Name = "groupBox11";
            groupBox11.Padding = new Padding(5);
            groupBox11.Size = new Size(123, 75);
            groupBox11.TabIndex = 5;
            groupBox11.TabStop = false;
            groupBox11.Text = "发射高度";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(85, 40);
            label10.Name = "label10";
            label10.Size = new Size(34, 28);
            label10.TabIndex = 3;
            label10.Text = "M";
            // 
            // HeightInPut
            // 
            HeightInPut.BorderStyle = BorderStyle.FixedSingle;
            HeightInPut.Location = new Point(5, 32);
            HeightInPut.Name = "HeightInPut";
            HeightInPut.Size = new Size(77, 34);
            HeightInPut.TabIndex = 0;
            HeightInPut.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(ANTInPut);
            groupBox9.Location = new Point(10, 270);
            groupBox9.Name = "groupBox9";
            groupBox9.Padding = new Padding(5);
            groupBox9.Size = new Size(395, 71);
            groupBox9.TabIndex = 3;
            groupBox9.TabStop = false;
            groupBox9.Text = "天馈情况";
            // 
            // ANTInPut
            // 
            ANTInPut.BorderStyle = BorderStyle.FixedSingle;
            ANTInPut.Dock = DockStyle.Fill;
            ANTInPut.Location = new Point(5, 32);
            ANTInPut.Name = "ANTInPut";
            ANTInPut.Size = new Size(385, 34);
            ANTInPut.TabIndex = 0;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(label7);
            groupBox8.Controls.Add(PowInPut);
            groupBox8.Location = new Point(292, 189);
            groupBox8.Name = "groupBox8";
            groupBox8.Padding = new Padding(5);
            groupBox8.Size = new Size(113, 75);
            groupBox8.TabIndex = 2;
            groupBox8.TabStop = false;
            groupBox8.Text = "功率";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(73, 38);
            label7.Name = "label7";
            label7.Size = new Size(35, 28);
            label7.TabIndex = 3;
            label7.Text = "W";
            // 
            // PowInPut
            // 
            PowInPut.BorderStyle = BorderStyle.FixedSingle;
            PowInPut.Location = new Point(5, 32);
            PowInPut.Name = "PowInPut";
            PowInPut.Size = new Size(65, 34);
            PowInPut.TabIndex = 0;
            PowInPut.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(RIGInPut);
            groupBox7.Location = new Point(10, 189);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new Padding(5);
            groupBox7.Size = new Size(276, 75);
            groupBox7.TabIndex = 1;
            groupBox7.TabStop = false;
            groupBox7.Text = "设备";
            // 
            // RIGInPut
            // 
            RIGInPut.BorderStyle = BorderStyle.FixedSingle;
            RIGInPut.Dock = DockStyle.Fill;
            RIGInPut.Location = new Point(5, 32);
            RIGInPut.Name = "RIGInPut";
            RIGInPut.Size = new Size(266, 34);
            RIGInPut.TabIndex = 0;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(QTHInPut);
            groupBox6.Dock = DockStyle.Top;
            groupBox6.Location = new Point(10, 30);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(5);
            groupBox6.Size = new Size(395, 153);
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
            QTHInPut.Size = new Size(385, 116);
            QTHInPut.TabIndex = 0;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = DockStyle.Top;
            label11.Font = new Font("Microsoft YaHei UI", 5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label11.Location = new Point(20, 642);
            label11.Name = "label11";
            label11.Size = new Size(0, 15);
            label11.TabIndex = 30;
            // 
            // SaveLogBtn
            // 
            SaveLogBtn.AutoSize = true;
            SaveLogBtn.Dock = DockStyle.Top;
            SaveLogBtn.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            SaveLogBtn.Location = new Point(20, 592);
            SaveLogBtn.Margin = new Padding(20);
            SaveLogBtn.Name = "SaveLogBtn";
            SaveLogBtn.Size = new Size(415, 50);
            SaveLogBtn.TabIndex = 28;
            SaveLogBtn.Text = "添 加 纪 录";
            SaveLogBtn.UseVisualStyleBackColor = true;
            SaveLogBtn.Click += SaveLogBtn_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Top;
            label9.Font = new Font("Microsoft YaHei UI", 5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label9.Location = new Point(20, 577);
            label9.Name = "label9";
            label9.Size = new Size(0, 15);
            label9.TabIndex = 29;
            // 
            // groupBox4
            // 
            groupBox4.BackgroundImageLayout = ImageLayout.Center;
            groupBox4.Controls.Add(label8);
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
            groupBox4.Size = new Size(415, 557);
            groupBox4.TabIndex = 25;
            groupBox4.TabStop = false;
            groupBox4.Text = "基本通联信息";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(346, 433);
            label8.Name = "label8";
            label8.Size = new Size(62, 28);
            label8.TabIndex = 4;
            label8.Text = "MHz";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(RRSTBox);
            groupBox3.Location = new Point(207, 467);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(194, 73);
            groupBox3.TabIndex = 39;
            groupBox3.TabStop = false;
            groupBox3.Text = "RRST";
            // 
            // RRSTBox
            // 
            RRSTBox.Controls.Add(RRST_R);
            RRSTBox.Controls.Add(RRST_S);
            RRSTBox.Controls.Add(RRST_T);
            RRSTBox.Dock = DockStyle.Fill;
            RRSTBox.Location = new Point(3, 30);
            RRSTBox.Name = "RRSTBox";
            RRSTBox.Size = new Size(188, 40);
            RRSTBox.TabIndex = 23;
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
            RRST_T.Enabled = false;
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
            label6.Location = new Point(237, 482);
            label6.Name = "label6";
            label6.Size = new Size(0, 28);
            label6.TabIndex = 38;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(RSTBox);
            groupBox2.Location = new Point(10, 467);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(194, 73);
            groupBox2.TabIndex = 37;
            groupBox2.TabStop = false;
            groupBox2.Text = "RST";
            // 
            // RSTBox
            // 
            RSTBox.Controls.Add(RST_R);
            RSTBox.Controls.Add(RST_S);
            RSTBox.Controls.Add(RST_T);
            RSTBox.Dock = DockStyle.Fill;
            RSTBox.Location = new Point(3, 30);
            RSTBox.Name = "RSTBox";
            RSTBox.Size = new Size(188, 40);
            RSTBox.TabIndex = 23;
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
            RST_T.Enabled = false;
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
            label4.Location = new Point(48, 482);
            label4.Name = "label4";
            label4.Size = new Size(0, 28);
            label4.TabIndex = 36;
            // 
            // FrequencyInput
            // 
            FrequencyInput.BackColor = SystemColors.Control;
            FrequencyInput.FormattingEnabled = true;
            FrequencyInput.Location = new Point(137, 425);
            FrequencyInput.Name = "FrequencyInput";
            FrequencyInput.Size = new Size(208, 36);
            FrequencyInput.TabIndex = 35;
            FrequencyInput.Leave += FrequencyInput_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 429);
            label5.Name = "label5";
            label5.Size = new Size(96, 28);
            label5.TabIndex = 33;
            label5.Text = "频       率";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ModeSelectBox);
            groupBox1.Location = new Point(10, 179);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(391, 240);
            groupBox1.TabIndex = 34;
            groupBox1.TabStop = false;
            groupBox1.Text = "模    式";
            // 
            // ModeSelectBox
            // 
            ModeSelectBox.Controls.Add(FmMode);
            ModeSelectBox.Controls.Add(AMMode);
            ModeSelectBox.Controls.Add(SSBMode);
            ModeSelectBox.Controls.Add(CWMode);
            ModeSelectBox.Controls.Add(FT8Mode);
            ModeSelectBox.Controls.Add(FT4Mode);
            ModeSelectBox.Controls.Add(SSTVMode);
            ModeSelectBox.Controls.Add(DMRMode);
            ModeSelectBox.Controls.Add(C4FMMode);
            ModeSelectBox.Controls.Add(D_STARMode);
            ModeSelectBox.Controls.Add(NXDNMode);
            ModeSelectBox.Controls.Add(PacketMode);
            ModeSelectBox.Controls.Add(MSK144Mode);
            ModeSelectBox.Dock = DockStyle.Fill;
            ModeSelectBox.Location = new Point(3, 30);
            ModeSelectBox.Name = "ModeSelectBox";
            ModeSelectBox.Padding = new Padding(10);
            ModeSelectBox.Size = new Size(385, 207);
            ModeSelectBox.TabIndex = 18;
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
            CWMode.CheckedChanged += CWMode_CheckedChanged;
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
            FT8Mode.CheckedChanged += FT8Mode_CheckedChanged;
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
            FT4Mode.CheckedChanged += FT4Mode_CheckedChanged;
            // 
            // SSTVMode
            // 
            SSTVMode.AutoSize = true;
            ModeSelectBox.SetFlowBreak(SSTVMode, true);
            SSTVMode.Location = new Point(175, 51);
            SSTVMode.Name = "SSTVMode";
            SSTVMode.Size = new Size(91, 32);
            SSTVMode.TabIndex = 20;
            SSTVMode.TabStop = true;
            SSTVMode.Text = "SSTV";
            SSTVMode.UseVisualStyleBackColor = true;
            SSTVMode.CheckedChanged += SSTVMode_CheckedChanged;
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
            ModeSelectBox.SetFlowBreak(NXDNMode, true);
            NXDNMode.Location = new Point(13, 127);
            NXDNMode.Name = "NXDNMode";
            NXDNMode.Size = new Size(105, 32);
            NXDNMode.TabIndex = 26;
            NXDNMode.TabStop = true;
            NXDNMode.Text = "NXDN";
            NXDNMode.UseVisualStyleBackColor = true;
            // 
            // PacketMode
            // 
            PacketMode.AutoSize = true;
            PacketMode.Location = new Point(13, 165);
            PacketMode.Name = "PacketMode";
            PacketMode.Size = new Size(108, 32);
            PacketMode.TabIndex = 27;
            PacketMode.TabStop = true;
            PacketMode.Text = "Packet";
            PacketMode.UseVisualStyleBackColor = true;
            // 
            // MSK144Mode
            // 
            MSK144Mode.AutoSize = true;
            MSK144Mode.Location = new Point(127, 165);
            MSK144Mode.Name = "MSK144Mode";
            MSK144Mode.Size = new Size(126, 32);
            MSK144Mode.TabIndex = 28;
            MSK144Mode.TabStop = true;
            MSK144Mode.Text = "MSK144";
            MSK144Mode.UseVisualStyleBackColor = true;
            // 
            // CallSignInput
            // 
            CallSignInput.BorderStyle = BorderStyle.FixedSingle;
            CallSignInput.CharacterCasing = CharacterCasing.Upper;
            CallSignInput.Location = new Point(130, 131);
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
            label3.Location = new Point(35, 135);
            label3.Name = "label3";
            label3.Size = new Size(96, 28);
            label3.TabIndex = 31;
            label3.Text = "对方呼号";
            // 
            // EndTime
            // 
            EndTime.CustomFormat = "HH:mm";
            EndTime.Format = DateTimePickerFormat.Custom;
            EndTime.Location = new Point(292, 88);
            EndTime.Name = "EndTime";
            EndTime.ShowUpDown = true;
            EndTime.Size = new Size(95, 34);
            EndTime.TabIndex = 30;
            // 
            // EndData
            // 
            EndData.CustomFormat = "yyyy-MM-dd";
            EndData.Format = DateTimePickerFormat.Custom;
            EndData.Location = new Point(130, 88);
            EndData.Name = "EndData";
            EndData.ShowUpDown = true;
            EndData.Size = new Size(156, 34);
            EndData.TabIndex = 29;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 90);
            label2.Name = "label2";
            label2.Size = new Size(96, 28);
            label2.TabIndex = 26;
            label2.Text = "结束时间";
            // 
            // StartTime
            // 
            StartTime.CustomFormat = "HH:mm";
            StartTime.Format = DateTimePickerFormat.Custom;
            StartTime.Location = new Point(292, 39);
            StartTime.Name = "StartTime";
            StartTime.ShowUpDown = true;
            StartTime.Size = new Size(95, 34);
            StartTime.TabIndex = 28;
            // 
            // StartData
            // 
            StartData.CustomFormat = "yyyy-MM-dd";
            StartData.Format = DateTimePickerFormat.Custom;
            StartData.Location = new Point(130, 39);
            StartData.Name = "StartData";
            StartData.ShowUpDown = true;
            StartData.Size = new Size(156, 34);
            StartData.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 42);
            label1.Name = "label1";
            label1.Size = new Size(96, 28);
            label1.TabIndex = 25;
            label1.Text = "开始时间";
            // 
            // toolStrip2
            // 
            toolStrip2.Dock = DockStyle.Bottom;
            toolStrip2.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip2.ImageScalingSize = new Size(30, 30);
            toolStrip2.Items.AddRange(new ToolStripItem[] { CallSignLab });
            toolStrip2.Location = new Point(8, 723);
            toolStrip2.Margin = new Padding(0, 8, 0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(1328, 33);
            toolStrip2.TabIndex = 3;
            toolStrip2.Text = "toolStrip2";
            // 
            // CallSignLab
            // 
            CallSignLab.Alignment = ToolStripItemAlignment.Right;
            CallSignLab.DisplayStyle = ToolStripItemDisplayStyle.Text;
            CallSignLab.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            CallSignLab.Image = (Image)resources.GetObject("CallSignLab.Image");
            CallSignLab.ImageTransparentColor = Color.Magenta;
            CallSignLab.Name = "CallSignLab";
            CallSignLab.Size = new Size(96, 28);
            CallSignLab.Text = "台站信息";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(240, 36);
            toolStripMenuItem1.Text = "设置台站信息";
            // 
            // LogMainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1344, 764);
            Controls.Add(panel1);
            Controls.Add(LogShowList);
            Controls.Add(toolStrip1);
            Controls.Add(toolStrip2);
            Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MinimumSize = new Size(1366, 768);
            Name = "LogMainForm";
            Padding = new Padding(8);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SharpLog";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox13.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox12.ResumeLayout(false);
            groupBox12.PerformLayout();
            groupBox10.ResumeLayout(false);
            groupBox10.PerformLayout();
            groupBox11.ResumeLayout(false);
            groupBox11.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            RRSTBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)RRST_R).EndInit();
            ((System.ComponentModel.ISupportInitialize)RRST_S).EndInit();
            ((System.ComponentModel.ISupportInitialize)RRST_T).EndInit();
            groupBox2.ResumeLayout(false);
            RSTBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)RST_R).EndInit();
            ((System.ComponentModel.ISupportInitialize)RST_S).EndInit();
            ((System.ComponentModel.ISupportInitialize)RST_T).EndInit();
            groupBox1.ResumeLayout(false);
            ModeSelectBox.ResumeLayout(false);
            ModeSelectBox.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripDropDownButton OptionBtn;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton HelpBtn;
        private FlowLayoutPanel LogShowList;
        private Panel panel1;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private FlowLayoutPanel RRSTBox;
        private NumericUpDown RRST_R;
        private NumericUpDown RRST_S;
        private NumericUpDown RRST_T;
        private Label label6;
        private GroupBox groupBox2;
        private FlowLayoutPanel RSTBox;
        private NumericUpDown RST_R;
        private NumericUpDown RST_S;
        private NumericUpDown RST_T;
        private Label label4;
        private ComboBox FrequencyInput;
        private Label label5;
        private GroupBox groupBox1;
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
        private RadioButton PacketMode;
        private RadioButton MSK144Mode;
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
        private GroupBox groupBox7;
        private TextBox RIGInPut;
        private GroupBox groupBox8;
        private TextBox PowInPut;
        private Label label7;
        private Label label8;
        private GroupBox groupBox9;
        private TextBox ANTInPut;
        private GroupBox groupBox11;
        private Label label10;
        private TextBox HeightInPut;
        private GroupBox groupBox12;
        private TextBox RMKSInPut;
        private GroupBox groupBox10;
        private TextBox OPInPut;
        private GroupBox groupBox13;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox IsEME;
        private CheckBox IsRelayStation;
        private CheckBox IsSatellite;
        private CheckBox IsQSL;
        private CheckBox IsQRP;
        private CheckBox IsMeteoricTrail;
        private Button SaveLogBtn;
        private Label label9;
        private Label label11;
        internal FlowLayoutPanel ModeSelectBox;
        private ToolStripMenuItem SetStationInformation;
        private ToolStrip toolStrip2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripLabel CallSignLab;
    }
}
