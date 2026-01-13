using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;

namespace SharpLog
{

    /// <summary>
    /// 日志数据校验工具类
    /// </summary>
    public static class LogDataValidatorTools
    {
        /// <summary>
        /// 对外调用汇总合法性校验
        /// </summary>
        /// <returns>如果合法返回true，否则返回false</returns>
        public static bool IsValidity(string callSign, string frequency, FlowLayoutPanel modeSelectBox)
        {
            string outErrorText = string.Empty;

            bool isModeValid = IsValidAmateurFrequency(frequency, out string frequencyErrorText);
            bool isCallSignValid = HasIllegalCharacters(callSign, out string callSignErrorText);
            bool isModeSelected = IsSelectMode(modeSelectBox, out string modeErrorText);

            //判断呼号、频率和模式是否合法
            if (true && isCallSignValid && isModeValid && isModeSelected)
                /*都合法输出True*/
                return true;
            else
            {
                //有任意一项不合法，输出错误提示并返回False
                if (callSignErrorText != String.Empty) { outErrorText = $"{outErrorText}呼号输入错误：{callSignErrorText}\r\n"; }
                if (frequencyErrorText != String.Empty) { outErrorText = $"{outErrorText}频率输入错误：{frequencyErrorText}\r\n"; }
                if (modeErrorText != String.Empty) { outErrorText = $"{outErrorText}模式选择错误：{modeErrorText}\r\n"; }

                //显示错误提示
                MessageBox.Show(outErrorText, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //返回False
                return false;
            }

            /*            //判定呼号和频率是否都合法
                        if (IsSelectMode(modeSelectBox, out string modeErrorText))
                        {
                            isValidity = false;
                        }
                        //判定呼号是否合法
                        else if (HasIllegalCharacters(callSign, out string callSignErrorText))
                        {
                            MessageBox.Show($"呼号包含非法字符：{callSignErrorText}", "呼号格式错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        //判定频率是否合法
                        else if (!IsValidAmateurFrequency(frequency, out string frequencyErrorText))
                        {
                            MessageBox.Show($"{frequencyErrorText}", "频率格式错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }*/

        }

        /// <summary>
        /// 判断呼号中是否包含除字母、数字、斜杠外的非法字符
        /// </summary>
        /// <param name="callSign">待校验的呼号（String类型，如JA8ABZ/P、HL/JA8ABZ）</param>
        /// <param name="CallSignErrorText">输出参数：提取出的所有非法字符（无则为空字符串）</param>
        /// <returns>true=仅含合法字符，false=包含非法字符</returns>
        private static bool HasIllegalCharacters(string callSign, out string CallSignErrorText)
        {
            // 初始化输出参数
            CallSignErrorText = string.Empty;
            if (string.IsNullOrWhiteSpace(callSign))
            {
                CallSignErrorText = "呼号为空";
                return false; // 空值视为"含非法状态"
            }

            // 构建非法字符缓冲区
            StringBuilder illegalBuffer = new StringBuilder();

            // 逐字符校验
            foreach (char c in callSign)
            {
                // 合法字符判断：字母（大小写）、数字、斜杠
                bool isLegalChar =
                    (c >= 'A' && c <= 'Z') ||  // 大写字母
                    (c >= 'a' && c <= 'z') ||  // 小写字母
                    (c >= '0' && c <= '9') ||  // 数字
                    c == '/';                  // 斜杠

                if (!isLegalChar)
                {
                    // 去重添加非法字符（避免重复记录）
                    if (!illegalBuffer.ToString().Contains(c.ToString()))
                    {
                        illegalBuffer.Append(c);
                    }
                }
            }

            // 提取非法字符结果
            CallSignErrorText = illegalBuffer.ToString();

            // 返回是否包含非法字符
            return string.IsNullOrEmpty(CallSignErrorText);
        }


        /// <summary>
        /// 判断输入频率是否为合法的业余无线电频率
        /// </summary>
        /// <param name="frequencyInMhz">输入频率（单位：MHz），string类型</param>
        /// <param name="showErrorMessage">是否显示错误提示弹窗</param>
        /// <returns>true：合法频率；false：非法频率或输入无效</returns>
        private static bool IsValidAmateurFrequency(string frequencyInMhz, out string FreErrorText)
        {
            FreErrorText = string.Empty;

            // 1. 验证输入是否为空或空白
            if (string.IsNullOrWhiteSpace(frequencyInMhz))
            {
                FreErrorText = "输入频率不能为空";
                return false;
            }

            // 2. 清理输入格式（去除空格、多余字符）
            string cleanedInput = frequencyInMhz.Trim().Replace(" ", "").Replace(",", ".").Replace("MHz", "");

            // 3. 尝试将输入转换为double类型
            if (!double.TryParse(cleanedInput, out double frequencyValue))
            {
                FreErrorText = $"输入'{frequencyInMhz}'不是有效的数字格式";
                return false;
            }

            // 4. 验证频率值是否为正数
            if (frequencyValue <= 0)
            {

                FreErrorText = $"频率'{frequencyValue}MHz'不能为零或负数";

                return false;
            }

            // 5. 基于公开字典检查频率是否在任何合法频段内
            bool isValid = ValidAmateurBands.Values.Any(range => range.Contains(frequencyValue));

            if (!isValid)
            {
                FreErrorText = $"频率'{frequencyValue}MHz'不在合法的业余无线电频段范围内";
            }
            return isValid;
        }



        /// <summary>
        /// 判断是否选择了通讯模式
        /// </summary>
        /// <param name="modePanel">通讯模式按钮的容器</param>
        /// <param name="modeErrorText">传出错误提示文本</param>
        /// <returns>true：已选择模式；false：未选择模式</returns>
        private static bool IsSelectMode(FlowLayoutPanel modePanel, out string modeErrorText)
        {
            string selectedModeName = string.Empty;
            modeErrorText = string.Empty;
            //遍历容器内的单选按钮，找出被选中的模式
            //判断是否选择了通讯模式
            foreach (RadioButton rb in modePanel.Controls)
            {
                if (rb.Checked)
                {
                    selectedModeName = rb.Name;
                    return true;
                }
            }

            modeErrorText = "未选择任何模式";
            return false;
        }


        /*
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
        */


    }
    /// <summary>
    /// 频率区间模型 - 存储频段的上下限（单位：MHz）
    /// </summary>
    public class FrequencyRange
    {
        public double LowerLimit { get; }  // 频率下限（MHz）
        public double UpperLimit { get; }  // 频率上限（MHz）

        public FrequencyRange(double lowerLimit, double upperLimit)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }

        /// <summary>
        /// 检查指定频率是否在当前区间内
        /// </summary>
        public bool Contains(double frequencyMhz)
        {
            return frequencyMhz >= LowerLimit - double.Epsilon &&
                   frequencyMhz <= UpperLimit + double.Epsilon;
        }

        public override string ToString()
        {
            return $"{LowerLimit} - {UpperLimit} MHz";
        }
    }
}


