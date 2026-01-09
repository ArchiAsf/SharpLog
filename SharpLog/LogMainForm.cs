using System.Windows.Forms.VisualStyles;

namespace SharpLog
{
    public partial class LogMainForm : Form
    {
        public LogMainForm()
        {
            InitializeComponent();

            LogMainFormStyles logMainFormStyles = new LogMainFormStyles();
            logMainFormStyles.SetAllControlsStyle(this);

            BackColor = logMainFormBackColor;
            ForeColor = logMainFormFontColor;


            // 核心设置：消除堆叠边框线
            LogShowList.BorderStyle = BorderStyle.None; // 去掉默认边框（关键）
            LogShowList.AutoSize = false; // 关闭自动尺寸，强制按Anchor拉伸

            FrequencyInput.BackColor = normalTextBoxBackColor;
            FrequencyInput.ForeColor = normalTextBoxTextColor;




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
        #endregion
    }
}
