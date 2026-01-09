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


    }
}
