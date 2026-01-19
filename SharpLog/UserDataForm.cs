using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SharpLog
{
    public partial class UserDataForm : Form
    {
        public UserDataForm()
        {
            InitializeComponent();

            FormStyles logMainFormStyles = new FormStyles();
            logMainFormStyles.SetAllControlsStyle(this);

            //加载json用户数据并附到对应文本框，如果文件不存在则跳过
            if (File.Exists(Path.Combine(RelativePath, "UserData.json")))
            {
                try
                {
                    UserData userData = JSONTools.JSONLoad<UserData>(Path.Combine(RelativePath, "UserData.json"));
                    UserCallSignText.Text = userData.UserCallSign;
                    OPNameText.Text = userData.OPName;
                    QSLCardAddress.Text = userData.QSLAddress;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载用户数据时发生错误：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        /// <summary>
        /// 保存修改按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveChange_Click(object sender, EventArgs e)
        {
            UserData userData = new UserData
            {
                UserCallSign = UserCallSignText.Text.Trim(),
                OPName = OPNameText.Text.Trim(),
                QSLAddress = QSLCardAddress.Text.Trim()
            };

            JSONTools.JSONSave(Path.Combine(RelativePath, "UserData.json"), userData);

            Close();
        }

        /// <summary>
        /// 清空文本框按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CleanText_Click(object sender, EventArgs e)
        {
            UserCallSignText.Text = string.Empty;
            OPNameText.Text = string.Empty;
            QSLCardAddress.Text = string.Empty;

            UserCallSignText.Focus();
        }

    }
}
