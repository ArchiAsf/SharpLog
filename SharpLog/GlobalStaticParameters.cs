global using static SharpLog.GlobalStaticParameters;

using System;
using System.Collections.Generic;
using System.Text;

namespace SharpLog
{
    public static class GlobalStaticParameters
    {
        #region 设定一些要用到的颜色
        // Form（主窗体）
        public static Color logMainFormBackColor = Color.FromArgb(18, 20, 24); // 主窗体背景色
        public static Color logMainFormFontColor = Color.FromArgb(240, 242, 245); // 主窗体默认字体颜色

        // Panel（卡片容器）
        public static Color panelBackColor = Color.FromArgb(32, 35, 40); // 卡片容器背景色
        public static Color panelBorderColor = Color.FromArgb(60, 63, 70); // 卡片容器边框色

        // Label（主标题）
        public static Color labelMainTitleColor = Color.FromArgb(255, 255, 255); // 主标题标签字体颜色

        // Label（正文/提示）
        public static Color labelTextColor = Color.FromArgb(240, 242, 245); // 正文提示标签字体颜色

        // Label（次要备注）
        public static Color labelSecondaryNoteColor = Color.FromArgb(200, 203, 210); // 次要备注标签字体颜色

        // TextBox（输入框-正常状态）
        public static Color normalTextBoxBackColor = Color.FromArgb(45, 48, 55); // 输入框正常状态背景色
        public static Color normalTextBoxTextColor = Color.FromArgb(240, 242, 245); // 输入框正常状态字体颜色
        public static Color normalTextBoxBorderColor = Color.FromArgb(60, 63, 70); // 输入框正常状态边框色

        // TextBox（输入框-焦点状态）
        public static Color focusTextBoxTextColor = Color.FromArgb(255, 255, 255); // 输入框焦点状态字体颜色
        public static Color focusTextBoxBorderColor = Color.FromArgb(41, 98, 255); // 输入框焦点状态边框色

        // Button（主按钮-正常状态）
        public static Color buttonNormalBackColor = Color.FromArgb(41, 98, 255); // 主按钮正常状态背景色
        public static Color buttonNormalTextColor = Color.FromArgb(255, 255, 255); // 主按钮正常状态字体颜色

        // Button（主按钮-悬浮状态）
        public static Color buttonHoverBackColor = Color.FromArgb(72, 126, 255); // 主按钮悬浮状态背景色

        // Button（主按钮-点击状态）
        public static Color buttonClickBackColor = Color.FromArgb(22, 70, 180); // 主按钮点击状态背景色

        // Button（主按钮-禁用状态）
        public static Color buttonDisabledBackColor = Color.FromArgb(35, 50, 80); // 主按钮禁用状态背景色
        public static Color buttonDisabledTextColor = Color.FromArgb(120, 125, 135); // 主按钮禁用状态字体颜色

        // DataGridView（表头）
        public static Color dgvHeaderBackColor = Color.FromArgb(32, 35, 40); // 数据表格表头背景色
        public static Color dgvHeaderTextColor = Color.FromArgb(255, 255, 255); // 数据表格表头字体颜色
        public static Color dgvHeaderBorderColor = Color.FromArgb(60, 63, 70); // 数据表格表头边框色

        // DataGridView（行数据-正常）
        public static Color dgvRowNormalBackColor = Color.FromArgb(18, 20, 24); // 数据表格正常行背景色
        public static Color dgvRowNormalTextColor = Color.FromArgb(240, 242, 245); // 数据表格正常行字体颜色

        // DataGridView（行数据-选中）
        public static Color dgvRowSelectedBackColor = Color.FromArgb(41, 98, 255); // 数据表格选中行背景色
        public static Color dgvRowSelectedTextColor = Color.FromArgb(255, 255, 255); // 数据表格选中行字体颜色
        #endregion

        #region 无线电相关参数
        // C# 字符串数组 - SSTV全波段常用频点（全球通用）
        readonly static public string[] sstvCommonFrequencies = new string[]
        {
            "1.890MHz",    // 160米 - SSTV呼叫
            "3.845MHz",    // 80米 - 主呼叫（美洲/通用）
            "7.171MHz",    // 40米 - 主呼叫（美洲）
            "7.170MHz",    // 40米 - 主呼叫（亚非）
            "10.132MHz",   // 30米 - 窄带SSTV
            "14.230MHz",   // 20米 - 全球最活跃主呼叫
            "18.117MHz",   // 17米 - 常规通联
            "21.340MHz",   // 15米 - 主呼叫
            "24.927MHz",   // 12米 - 常规通联
            "28.680MHz",   // 10米 - 主呼叫
            "50.680MHz",   // 6米 - FM呼叫
            "144.195MHz",  // 2米 - SSB SSTV
            "144.500MHz",  // 2米 - FM常规通联
            "145.800MHz"   // 2米 - ISS卫星SSTV下行
        };

        // FT8常用热门频点
        readonly public static string[] Ft8CommonFrequencies = new string[]
        {
        "1.840MHz",    // 160米 - FT8主频点
        "3.570MHz",    // 80米 - FT8主频点
        "5.357MHz",    // 60米 - FT8专用（美洲/通用）
        "7.074MHz",    // 40米 - FT8全球核心频点（最活跃）
        "10.136MHz",   // 30米 - FT8主频点
        "14.074MHz",   // 20米 - FT8全球核心频点
        "18.095MHz",   // 17米 - FT8主频点
        "21.074MHz",   // 15米 - FT8主频点
        "24.915MHz",   // 12米 - FT8主频点
        "28.074MHz",   // 10米 - FT8主频点
        "50.313MHz",   // 6米 - FT8主频点
        "144.174MHz",  // 2米 - VHF FT8主频点
        "432.174MHz"   // 70厘米 - UHF FT8主频点
        };

        // FT4常用热门频点
        readonly public static string[] Ft4CommonFrequencies = new string[]
        {
        "1.841MHz",    // 160米 - FT4主频点（FT8+1kHz）
        "3.571MHz",    // 80米 - FT4主频点（FT8+1kHz）
        "7.078MHz",    // 40米 - FT4全球核心频点
        "10.138MHz",   // 30米 - FT4主频点
        "14.078MHz",   // 20米 - FT4全球核心频点
        "18.098MHz",   // 17米 - FT4主频点
        "21.078MHz",   // 15米 - FT4主频点
        "24.918MHz",   // 12米 - FT4主频点
        "28.078MHz",   // 10米 - FT4主频点
        "50.318MHz",   // 6米 - FT4主频点
        "144.178MHz",  // 2米 - VHF FT4主频点
        "432.178MHz"   // 70厘米 - UHF FT4主频点
        };




        #endregion

    }
}



