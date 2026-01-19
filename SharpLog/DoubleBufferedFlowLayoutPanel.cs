using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SharpLog
{
    /// <summary>
    /// 一个精简的 FlowLayoutPanel 子类，用于启用双缓冲并减少闪烁。
    /// 通过在背景绘制中填充背景色并在滚动/滚轮事件中强制重绘，避免出现白色条纹或残影。
    ///
    /// 说明：
    /// - 许多 WinForms 控件的 DoubleBuffered 属性为受保护，使用反射设置以确保启用双缓冲。
    /// - 重写 OnPaintBackground 并填充 BackColor 可以防止部分区域未及时重绘时出现白色像素。
    /// - 在滚动或鼠轮事件调用 Invalidate() 来强制刷新可见区域，避免局部重绘造成的条纹。
    /// - 抑制 WM_ERASEBKGND 可以避免框架重复擦除背景而产生的闪烁（我们已在 OnPaintBackground 中填充背景）。
    /// </summary>
    internal class DoubleBufferedFlowLayoutPanel : FlowLayoutPanel
    {
        public DoubleBufferedFlowLayoutPanel()
        {
            try
            {
                // 启用推荐的绘制样式以获得更平滑的更新
                SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.ResizeRedraw, true);
                UpdateStyles();

                // 通过反射确保受保护的 DoubleBuffered 属性被设置为 true
                var prop = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                prop?.SetValue(this, true, null);
            }
            catch
            {
                // Fail silently: lack of double-buffering is not fatal
            }
        }

        // 始终填充背景，避免在快速更新或局部重绘期间看到默认的白色背景
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (var b = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRectangle(b, this.ClientRectangle);
            }
        }

        // 在滚动事件（滚动条或程序触发）发生时强制完整重绘
        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            Invalidate();
        }

        // 在鼠轮滚动时也强制重绘（用户触发的滚动）
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            Invalidate();
        }

        // 抑制默认的背景擦除消息以减少闪烁，因为我们已在 OnPaintBackground 中填充背景
        protected override void WndProc(ref Message m)
        {
            const int WM_ERASEBKGND = 0x0014;
            if (m.Msg == WM_ERASEBKGND)
                return;
            base.WndProc(ref m);

            //bd2bl 59+107 735 斜拉天线 80w 7:40

            
        }
    }
}
