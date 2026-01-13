using System.Windows.Forms.VisualStyles;

namespace SharpLog
{
    public partial class LogMainForm : Form
    {
        public LogMainForm()
        {
            InitializeComponent();

            #region 设置窗体的一些基础样式以及属性

            LogMainFormStyles logMainFormStyles = new LogMainFormStyles();
            logMainFormStyles.SetAllControlsStyle(this);

            BackColor = logMainFormBackColor;
            ForeColor = logMainFormFontColor;


            // 核心设置：消除堆叠边框线
            LogShowList.BorderStyle = BorderStyle.None; // 去掉默认边框（关键）
            LogShowList.AutoSize = false; // 关闭自动尺寸，强制按Anchor拉伸

            FrequencyInput.BackColor = normalTextBoxBackColor;
            FrequencyInput.ForeColor = normalTextBoxTextColor;


            //此处犹豫，RST与RRST的第三位输入框默认不可用还是设置为空字符串
            RST_T.Text = "";
            RRST_T.Text = "";
            //RST_T.Visible = false;
            //RRST_T.Visible = false;


            SetTips(this);

            #endregion
        }

        #region 设定点击不同模式时，频率下拉框的常用频率选项


        private void SSTVMode_CheckedChanged(object sender, EventArgs e)
        {
            if (SSTVMode.Checked == true)
            {
                FrequencyInput.Items.Clear();
                FrequencyInput.Items.AddRange(sstvCommonFrequencies);
                FrequencyInput.SelectedIndex = 5;
            }
            else
            {
                FrequencyInput.Items.Clear();
                FrequencyInput.Text = "";
            }

        }

        private void FT8Mode_CheckedChanged(object sender, EventArgs e)
        {
            if (FT8Mode.Checked == true)
            {
                FrequencyInput.Items.Clear();
                FrequencyInput.Items.AddRange(Ft8CommonFrequencies);
                FrequencyInput.SelectedIndex = 5;
            }
            else
            {
                FrequencyInput.Items.Clear();
                FrequencyInput.Text = "";
            }

        }

        private void FT4Mode_CheckedChanged(object sender, EventArgs e)
        {
            if (FT4Mode.Checked == true)
            {
                FrequencyInput.Items.Clear();
                FrequencyInput.Items.AddRange(Ft4CommonFrequencies);
                FrequencyInput.SelectedIndex = 4;
            }
            else
            {
                FrequencyInput.Items.Clear();
                FrequencyInput.Text = "";
            }
        }
        /// <summary>
        /// 处于CW模式时，启用RST与RRST的第三位输入框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CWMode_CheckedChanged(object sender, EventArgs e)
        {
            if (CWMode.Checked == true)
            {
                RST_T.Enabled = true;
                RST_T.Text = "9";
                RRST_T.Text = "9";

                RRST_T.Enabled = true;

            }
            else
            {
                RST_T.Enabled = false;
                RST_T.Text = "";
                RRST_T.Text = "";
                RRST_T.Enabled = false;
            }
        }


        #endregion

        #region 窗体中的一些控件设置提示信息

        static private void SetTips(LogMainForm LMF)
        {
            // 1. 初始化ToolTip（可配置显示延迟等参数）
            ToolTip Tip = new ToolTip();
            // 可选：设置提示的显示规则
            Tip.InitialDelay = 1000;    // 鼠标悬浮后延迟1000毫秒显示
            Tip.AutoPopDelay = 3000;   // 提示显示3000毫秒后自动消失
            Tip.ReshowDelay = 200;     // 重复悬浮时的延迟
            Tip.ShowAlways = true;     // 即使控件禁用，也显示提示

            Tip.SetToolTip(LMF.FrequencyInput, "选择或输入通信频率（MHz）");
            Tip.SetToolTip(LMF.CallSignInput, "输入您的呼号（例如：AB1CDE）");

            Tip.SetToolTip(LMF.RST_R, "请输入接收信号报告（RST）");
            Tip.SetToolTip(LMF.RST_S, "请输入接受信号报告（RST）");
            Tip.SetToolTip(LMF.RST_T, "请输入接受信号报告（RST）");

            Tip.SetToolTip(LMF.RRST_R, "请输入发射信号报告（RST）");
            Tip.SetToolTip(LMF.RRST_S, "请输入发射信号报告（RST）");
            Tip.SetToolTip(LMF.RRST_T, "请输入发射信号报告（RST）");

            Tip.SetToolTip(LMF.StartData, "选择通信开始的日期");
            Tip.SetToolTip(LMF.StartTime, "选择通信开始的时间");

            Tip.SetToolTip(LMF.EndData, "选择通信结束的日期");
            Tip.SetToolTip(LMF.EndTime, "选择通信结束的时间");


            /*
            //C4FM（C4FM / Fusion 数字语音）		
            //D - STAR（D - STAR 数字语音）		
            //DMR（DMR 数字语音）		
            //NXDN（NXDN48 数字语音）
            //Packet (APRS)（APRS 分组数据）
            //MSK144（MSK144 数字模式）
            */

            Tip.SetToolTip(LMF.FmMode, "FM（调频模式）");
            Tip.SetToolTip(LMF.SSBMode, "SSB（单边带模式，包含上边带（USB）与下边带（LSB））");
            Tip.SetToolTip(LMF.CWMode, "CW（等幅电报模式）");
            Tip.SetToolTip(LMF.SSTVMode, "SSTV（慢扫描电视模式）");
            Tip.SetToolTip(LMF.FT8Mode, "FT8（弱信号数字模式）");
            Tip.SetToolTip(LMF.FT4Mode, "FT4（弱信号数字模式）");
            Tip.SetToolTip(LMF.AMMode, "AM（调幅模式）");
            Tip.SetToolTip(LMF.DMRMode, "DMR（DMR数字语音）");
            Tip.SetToolTip(LMF.D_STARMode, "D-STAR（D-STAR数字语音）");
            Tip.SetToolTip(LMF.C4FMMode, "C4FM（C4FM/Fusion数字语音）");
            Tip.SetToolTip(LMF.NXDNMode, "NXDN（NXDN48数字语音）");
            Tip.SetToolTip(LMF.PacketMode, "Packet (APRS)（APRS分组数据）");
            Tip.SetToolTip(LMF.MSK144Mode, "MSK144（MSK144数字模式，多用于流星余迹通信）");

            Tip.SetToolTip(LMF.SaveLogBtn, "点击按钮保存日志");
            Tip.SetToolTip(LMF.QTHInPut, "输入所通联电台的位置（QTH信息）");
            Tip.SetToolTip(LMF.RIGInPut, "输入所使用的设备型号（RIG信息）");
            Tip.SetToolTip(LMF.PowInPut, "输入所使用的功率（Power信息）");
            Tip.SetToolTip(LMF.ANTInPut, "输入所使用的天线型号（ANT信息）");
            Tip.SetToolTip(LMF.RMKSInPut, "输入备注信息");
            Tip.SetToolTip(LMF.HeightInPut, "输入所在地点的海拔高度（Height信息）");

            Tip.SetToolTip(LMF.IsQSL, "勾选表示已收发QSL卡片或电子QSL确认");
            Tip.SetToolTip(LMF.IsEME, "勾选表示此次通信为月球反射通信（EME）");
            Tip.SetToolTip(LMF.IsQRP, "勾选表示此次通信为低功率通信（QRP）");
            Tip.SetToolTip(LMF.IsSatellite, "勾选表示此次通信为卫星通信");
            Tip.SetToolTip(LMF.IsRelayStation, "勾选表示此次通信为中继台通信");
            Tip.SetToolTip(LMF.IsMeteoricTrail, "勾选表示此次通信为流星余迹通信");

        }
        #endregion

        /// <summary>
        /// 判断频率输入框中是否为例如14.270Mhz格式或是列如14.270格式，如果为前者则去掉MHz后缀，统一保存为纯数字的字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrequencyInput_Leave(object sender, EventArgs e)
        {
            string freqText = FrequencyInput.Text.Trim().ToUpper();
            if (freqText.EndsWith("MHZ"))
            {
                freqText = freqText.Substring(0, freqText.Length - 3).Trim();
                FrequencyInput.Text = freqText;
            }
        }


        /// <summary>
        /// 保存日志按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveLogBtn_Click(object sender, EventArgs e)
        {
            if(LogDataValidatorTools.IsValidity(CallSignInput.Text.Trim().ToUpper(), FrequencyInput.Text.Trim(),ModeSelectBox))
            {
                





            }


        }
    }
}
