global using static SharpLog.GlobalStaticParameters;

using System;
using System.Collections.Generic;
using System.Text;

namespace SharpLog
{
    public static class GlobalStaticParameters
    {
        /*        #region 设定一些要用到的颜色

                public static Color logMainFormBackColor = Color.FromArgb(18, 20, 24);
                public static Color logMainFormFontColor = Color.FromArgb(240, 242, 245);

                public static Color boxBackColor = Color.FromArgb(32, 35, 40);
                public static Color boxBorderColor = Color.FromArgb(60, 63, 70);

                public static Color mainLabelColor = Color.FromArgb(255, 255, 255);
                public static Color textLabelColor = Color.FromArgb(240, 242, 245);
                public static Color secondaryLabelColor = Color.FromArgb(200, 203, 210);

                public static Color normalTextBoxBackColor = Color.FromArgb(45, 48, 55);
                public static Color normalTextBoxTextColor = Color.FromArgb(240, 242, 245);
                public static Color normalTextBoxBorderColor = Color.FromArgb(60, 63, 70);

                #endregion
        */

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



    }
}



