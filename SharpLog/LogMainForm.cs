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

        }
    }
}
