using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SharpLog
{
    internal class LogMainFormStyles
    {
        /// <summary>
        /// 递归遍历所有控件，批量设置样式（Label/TextBox+按钮）
        /// </summary>
        /// <param name="parentControl">父控件（窗体/Panel等）</param>
        internal void SetAllControlsStyle(Control parentControl)
        {
            foreach (Control ctrl in parentControl.Controls)
            {
                // 处理 Label
                if (ctrl is Label label)
                {
                    label.ForeColor = labelSecondaryNoteColor;
                }

                // 处理 TextBox
                if (ctrl is TextBox textBox)
                {
                    textBox.BackColor = normalTextBoxBackColor;
                    textBox.ForeColor = normalTextBoxTextColor;
                    textBox.Click += (sender, e) =>
                    {
                        textBox.ForeColor = focusTextBoxTextColor;
                        ControlPaint.DrawBorder(textBox.CreateGraphics(), textBox.ClientRectangle,
                            Color.FromArgb(41, 98, 255), 1, ButtonBorderStyle.Solid,
                            Color.FromArgb(41, 98, 255), 1, ButtonBorderStyle.Solid,
                            Color.FromArgb(41, 98, 255), 1, ButtonBorderStyle.Solid,
                            Color.FromArgb(41, 98, 255), 1, ButtonBorderStyle.Solid);
                    };

                }

                // 处理 Button（核心：绑定鼠标事件+设置基础样式）
                if (ctrl is Button btn)
                {
                    // 设置按钮基础样式
                    btn.BackColor = buttonNormalBackColor;
                    btn.ForeColor = buttonNormalTextColor;
                    btn.FlatStyle = FlatStyle.Flat; // 扁平化样式（可选，效果更统一）
                    btn.FlatAppearance.BorderSize = 0; // 去掉边框（可选）

                    // 绑定鼠标事件（实现交互色效）
                    btn.MouseEnter += Btn_MouseEnter;       // 鼠标悬浮
                    btn.MouseLeave += Btn_MouseLeave;       // 鼠标离开
                    btn.MouseDown += Btn_MouseDown;         // 鼠标按下（点击）
                    btn.MouseUp += Btn_MouseUp;             // 鼠标松开

                    if (btn.Enabled == false)        //按钮被禁用时的样式
                    {
                        btn.BackColor = buttonDisabledBackColor;
                        btn.ForeColor = buttonDisabledTextColor;
                    }
                }

                //设定分类框的样式
                if(ctrl is Panel panel)
                {
                    panel.BackColor = panelBackColor;
                    panel.Paint += (sender, e) =>
                    {
                        ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle,
                            Color.FromArgb(60, 63, 70), 1, ButtonBorderStyle.Solid,
                            Color.FromArgb(60, 63, 70), 1, ButtonBorderStyle.Solid,
                            Color.FromArgb(60, 63, 70), 1, ButtonBorderStyle.Solid,
                            Color.FromArgb(60, 63, 70), 1, ButtonBorderStyle.Solid);
                    };
                }

               //设定工具栏的外观
                if(ctrl is ToolStrip toolStrip)
                {
                    toolStrip.Renderer = new NoBorderToolStripRenderer();
                    toolStrip.BackColor = panelBackColor;
                    toolStrip.ForeColor = labelTextColor;
                }




                // 递归处理嵌套控件（Panel/GroupBox里的控件）
                if (ctrl.HasChildren)
                {
                    SetAllControlsStyle(ctrl);
                }
            }
        }

        #region 按钮鼠标事件处理（交互色效）
        // 鼠标悬浮：切换为悬浮色
        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = buttonHoverBackColor;
            }
        }

        // 鼠标离开：恢复默认色
        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = buttonNormalBackColor;
            }
        }

        // 鼠标按下（点击）：切换为点击色
        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Button btn)
            {
                btn.BackColor = buttonClickBackColor;
            }
        }



        // 鼠标松开：恢复悬浮色（如果鼠标还在按钮上）/默认色（如果鼠标移开）
        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Button btn)
            {
                // 判断鼠标是否还在按钮区域内
                if (btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position)))
                {
                    btn.BackColor = buttonHoverBackColor;
                }
                else
                {
                    btn.BackColor = buttonNormalBackColor;
                }
            }
        }


        #endregion
    }
    // 自定义渲染器：不绘制 ToolStrip 边框
    internal class NoBorderToolStripRenderer : ToolStripSystemRenderer
    {
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // 注释掉基类方法，不绘制边框（核心逻辑）
            // base.OnRenderToolStripBorder(e);
        }
    }

}
