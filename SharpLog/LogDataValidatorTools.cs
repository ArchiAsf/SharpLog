using System;
using System.Collections.Generic;
using System.Text;

namespace SharpLog
{
    /// <summary>
    /// 日志数据校验工具类
    /// </summary>
    public static class LogDataValidatorTools
    {
        /// <summary>
        /// 校验业余无线电呼号是否合规
        /// </summary>
        /// <param name="callSign">待校验的呼号（支持带操作后缀，如JA8ABZ/P）</param>
        /// <param name="errorMessage">输出参数：校验失败时返回具体原因，成功时返回"合规"</param>
        /// <returns>true=合规，false=不合规</returns>
        public static bool ValidateCallSign(string callSign, out string errorMessage)
        {
            // 初始化返回值
            errorMessage = string.Empty;

            // 1. 空值/空白校验
            if (string.IsNullOrWhiteSpace(callSign))
            {
                errorMessage = "呼号不能为空或仅包含空白字符";
                return false;
            }

            // 统一转为大写（呼号大小写不敏感）
            string upperCallSign = callSign.Trim().ToUpper();

            // 2. 拆分基础呼号和操作后缀
            string baseCallSign = upperCallSign;
            string suffixPart = string.Empty;
            bool hasSlash = upperCallSign.Contains("/");

            if (hasSlash)
            {
                // 拆分斜线前后部分（支持 呼号/后缀 或 前缀/呼号 格式）
                string[] parts = upperCallSign.Split('/');
                if (parts.Length != 2 || string.IsNullOrWhiteSpace(parts[0]) || string.IsNullOrWhiteSpace(parts[1]))
                {
                    errorMessage = "呼号后缀格式错误：斜线必须且仅能出现1次，且斜线前后不能为空（如JA8ABZ/P或HL/JA8ABZ）";
                    return false;
                }

                // 判断哪部分是基础呼号（含数字的为基础呼号）
                if (parts[0].Any(char.IsDigit))
                {
                    baseCallSign = parts[0];
                    suffixPart = parts[1];
                }
                else if (parts[1].Any(char.IsDigit))
                {
                    baseCallSign = parts[1];
                    suffixPart = parts[0];
                }
                else
                {
                    errorMessage = "斜线分隔的两部分中，必须有且仅有一部分包含数字（基础呼号）";
                    return false;
                }
            }

            // ========== 基础呼号核心校验 ==========
            // 3. 基础呼号位数校验（3-8位）
            if (baseCallSign.Length < 3 || baseCallSign.Length > 8)
            {
                errorMessage = $"基础呼号位数不合规：需3-8位，当前{baseCallSign.Length}位（{baseCallSign}）";
                return false;
            }

            // 4. 字符合法性校验（仅允许A-Z、0-9）
            foreach (char c in baseCallSign)
            {
                if (!char.IsLetterOrDigit(c) || (char.IsLetter(c) && !char.IsAsciiLetterUpper(c)))
                {
                    errorMessage = $"基础呼号包含非法字符：{c}（仅允许大写拉丁字母A-Z和数字0-9）";
                    return false;
                }
            }

            // 5. 分隔数字校验（必须有且仅有1位数字）
            int digitCount = baseCallSign.Count(char.IsDigit);
            if (digitCount == 0)
            {
                errorMessage = "基础呼号缺少分隔数字（必须包含1位数字区分前缀和后缀）";
                return false;
            }
            if (digitCount > 1)
            {
                errorMessage = $"基础呼号包含多个分隔数字：共{digitCount}位（仅允许1位）";
                return false;
            }

            // 6. 基础呼号最后一位必须是字母
            char lastChar = baseCallSign[baseCallSign.Length - 1];
            if (char.IsDigit(lastChar))
            {
                errorMessage = $"基础呼号最后一位为数字（{lastChar}），必须为字母";
                return false;
            }

            // 7. 前缀/后缀长度校验（前缀1-3位，后缀1-4位）
            int digitIndex = baseCallSign.IndexOfFirst(char.IsDigit);
            int prefixLength = digitIndex; // 分隔数字前的前缀长度
            int suffixLength = baseCallSign.Length - digitIndex - 1; // 分隔数字后的后缀长度

            if (prefixLength < 1 || prefixLength > 3)
            {
                errorMessage = $"基础呼号前缀长度不合规：需1-3位，当前{prefixLength}位（{baseCallSign.Substring(0, digitIndex)}）";
                return false;
            }
            if (suffixLength < 1 || suffixLength > 4)
            {
                errorMessage = $"基础呼号后缀长度不合规：需1-4位，当前{suffixLength}位（{baseCallSign.Substring(digitIndex + 1)}）";
                return false;
            }

            // 所有校验通过
            errorMessage = "合规";
            return true;
        }



        /// <summary>
        /// 判断输入频率是否为合法的业余无线电频率
        /// </summary>
        /// <param name="frequencyInMhz">输入频率（单位：MHz），string类型</param>
        /// <param name="showErrorMessage">是否显示错误提示弹窗</param>
        /// <returns>true：合法频率；false：非法频率或输入无效</returns>
        public static bool IsValidAmateurFrequency(string frequencyInMhz, bool showErrorMessage = true)
        {
            // 1. 验证输入是否为空或空白
            if (string.IsNullOrWhiteSpace(frequencyInMhz))
            {
                if (showErrorMessage)
                {
                    MessageBox.Show("错误：输入频率不能为空", "输入错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

            // 2. 清理输入格式（去除空格、多余字符）
            string cleanedInput = frequencyInMhz.Trim()
                                               .Replace(" ", "")
                                               .Replace(",", ".")
                                               .Replace("MHz", "");

            // 3. 尝试将输入转换为double类型
            if (!double.TryParse(cleanedInput, out double frequencyValue))
            {
                if (showErrorMessage)
                {
                    MessageBox.Show($"错误：输入'{frequencyInMhz}'不是有效的数字格式", "格式错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

            // 4. 验证频率值是否为正数
            if (frequencyValue <= 0)
            {
                if (showErrorMessage)
                {
                    MessageBox.Show($"错误：频率'{frequencyValue}MHz'不能为零或负数", "数值错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

            // 5. 基于公开字典检查频率是否在任何合法频段内
            bool isValid = ValidAmateurBands.Values.Any(range => range.Contains(frequencyValue));

             if (showErrorMessage && !isValid)
            {
                MessageBox.Show($"频率'{frequencyValue}MHz'不在合法的业余无线电频段范围内",
                    "频率非法", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        /// <summary>
        /// 扩展方法：查找第一个符合条件的字符索引
        /// </summary>
        /// <param name="str"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        private static int IndexOfFirst(this string str, Func<char, bool> predicate)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (predicate(str[i])) return i;
            }
            return -1;
        }
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
