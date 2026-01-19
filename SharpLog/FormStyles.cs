using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;

namespace SharpLog
{
    internal class FormStyles
    {
        // 通过反射启用控件的 DoubleBuffered 属性（该属性通常为受保护），用于在运行时
        // 强制把普通控件也切换到双缓冲模式，从而减少重绘时的闪烁或白色残影。
        private void EnableDoubleBuffer(Control ctrl)
        {
            if (ctrl == null) return;
            try
            {
                // 优先在具体控件类型上查找 DoubleBuffered 属性（某些控件在子类中声明）
                var prop = ctrl.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (prop != null && prop.CanWrite)
                {
                    prop.SetValue(ctrl, true, null);
                    return;
                }

                // 若未找到，则回退到 Control 基类的非公共属性并设置之
                var baseProp = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                if (baseProp != null)
                {
                    baseProp.SetValue(ctrl, true, null);
                }
            }
            catch
            {
                // 忽略反射相关异常，确保应用保持稳定性（即使双缓冲未设置）
            }
        }

        // 说明：我们不再单独通过反射去调用 SetStyle，因为自定义的双缓冲控件类
        // (DoubleBufferedPanel / DoubleBufferedFlowLayoutPanel) 已经在构造时设置了合适的 ControlStyles。
        // 本类主要负责统一应用配色、边框绘制以及递归启用双缓冲等样式调整。

        // 递归为父控件及其子控件启用双缓冲
        internal void EnableDoubleBufferForChildren(Control parentControl)
        {
            if (parentControl == null) return;
            EnableDoubleBuffer(parentControl);
            foreach (Control c in parentControl.Controls)
            {
                EnableDoubleBuffer(c);
                if (c.HasChildren)
                {
                    EnableDoubleBufferForChildren(c);
                }
            }
        }
        /// <summary>
        /// 递归遍历所有控件，批量设置样式（Label/TextBox+按钮）
        /// </summary>
        /// <param name="parentControl">父控件（窗体/Panel等）</param>
        internal void SetAllControlsStyle(Control parentControl)
        {
            foreach (Control ctrl in parentControl.Controls)
            {
                // 尝试启用控件的双缓冲（DoubleBuffered 为受保护属性，需要通过反射设置）
                EnableDoubleBuffer(ctrl);

                // 处理 Label
                if (ctrl is Label label)
                {
                    label.ForeColor = labelTextColor;
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
                if (ctrl is Panel panel)
                {
                    panel.BackColor = panelBackColor;
                    // 防止重复绑定 Paint 事件（SetAllControlsStyle 可能被多次调用）
                    const string marker = "LogMainFormStyles_BorderAttached";
                    if (!(panel.Tag is string s && s == marker))
                    {
                        panel.Paint += (sender, e) =>
                        {
                            // 先填充背景色，避免在重绘不及时时出现白色网格
                            using (var b = new SolidBrush(panel.BackColor))
                            {
                                e.Graphics.FillRectangle(b, panel.ClientRectangle);
                            }
                            ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle,
                                Color.FromArgb(60, 63, 70), 1, ButtonBorderStyle.Solid,
                                Color.FromArgb(60, 63, 70), 1, ButtonBorderStyle.Solid,
                                Color.FromArgb(60, 63, 70), 1, ButtonBorderStyle.Solid,
                                Color.FromArgb(60, 63, 70), 1, ButtonBorderStyle.Solid);
                        };
                        panel.Tag = marker;
                    }
                }


                //设定工具栏的外观
                if (ctrl is ToolStrip toolStrip)
                {
                    toolStrip.Renderer = new NoBorderToolStripRenderer();
                    toolStrip.BackColor = panelBackColor;
                    toolStrip.ForeColor = labelTextColor;

                }

                    //设置GroupBo.MouseUp += Btn_MouseUp;         x的样式
                    if (ctrl is GroupBox groupBox)
                    {
                        groupBox.ForeColor = labelTextColor;
                    }

                    //设置下拉列表的样式
                    if (ctrl is ComboBox comboBox)
                    {
                        comboBox.BackColor = normalTextBoxTextColor;
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
