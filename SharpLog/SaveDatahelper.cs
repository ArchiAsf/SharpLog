using System;
using System.Collections.Generic;
using System.Text;


namespace SharpLog
{
    internal static class SaveDatahelper
    {
   

        /// <summary>
        /// 获取选择的通讯模式名称
        /// </summary>
        /// <param name="modePanel">通讯模式按钮的容器</param>
        /// <returns>选择的模式名称，如果未选择则返回空字符串</returns>
        public static string GetSelectedMode(FlowLayoutPanel modePanel)
        {
            foreach (RadioButton rb in modePanel.Controls)
                if (rb.Checked)
                    return rb.Name;
            return string.Empty; // 如果没有选择任何模式，返回空字符串
        }
        /// <summary>
        /// 获取RST的数字并拼接为字符串返回
        /// </summary>
        /// <returns></returns>
        public static string GetRSTString(NumericUpDown R,NumericUpDown S,NumericUpDown T)
        {
            return $"{R.Value.ToString()}{S.Value.ToString()}{T.Value.ToString()}";
        }

    }
}
