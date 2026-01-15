using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SharpLog
{
    /// <summary>
    /// 最小化的 Panel 子类，用于启用双缓冲并绘制背景，防止在内容滚动、
    /// 窗口移动或调整大小时出现可视伪影（例如白线、残影）。
    /// 实现保持精简并附带中文注释，便于理解与维护。
    /// </summary>
    internal class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            try
            {
                // 启用推荐的绘制样式，减少闪烁并改善绘制行为
                SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.ResizeRedraw, true);
                UpdateStyles();

                // 通过反射设置受保护的 DoubleBuffered 属性，确保控件使用后备缓冲区
                var prop = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                prop?.SetValue(this, true, null);
            }
            catch
            {
                // 忽略失败：如果反射或样式设置失败，程序仍然应正常运行，只是可能出现闪烁
            }
        }

        // 完整绘制背景，避免在快速更新或部分重绘期间出现白色或杂乱像素
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (var b = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRectangle(b, this.ClientRectangle);
            }
        }

        // 在面板滚动时强制重绘，确保可见区域被及时更新，避免残影
        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            Invalidate();
        }

        // 抑制窗口消息中的背景擦除（WM_ERASEBKGND），减少闪烁。
        // 我们在 OnPaintBackground 中已经完整填充背景，因此可以跳过系统默认的擦除。
        protected override void WndProc(ref Message m)
        {
            const int WM_ERASEBKGND = 0x0014;
            if (m.Msg == WM_ERASEBKGND)
                return;
            base.WndProc(ref m);
        }
    }
}
