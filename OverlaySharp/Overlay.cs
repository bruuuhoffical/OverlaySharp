using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ImGuiNET;

namespace OverlaySharp
{
    public abstract class Overlay : Form
    {
        private System.Windows.Forms.Timer _timer;
        private IntPtr _targetHandle;
        private OverlayConfig _config;

        protected ImDrawListPtr ForegroundDrawList => ImGui.GetForegroundDrawList();
        protected ImDrawListPtr BackgroundDrawList => ImGui.GetBackgroundDrawList();

        public Overlay(OverlayConfig config)
        {
            _config = config;
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            TopMost = true;
            DoubleBuffered = true;
            BackColor = Color.Lime;
            TransparencyKey = Color.Lime;

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            Load += (_, _) => Init();
        }

        public void AttachTo(IntPtr handle)
        {
            _targetHandle = handle;
        }

        private void Init()
        {
            Native.MakeTransparent(this.Handle);
            _timer = new System.Windows.Forms.Timer { Interval = 16 };
            _timer.Tick += (s, e) => UpdateOverlay();
            _timer.Start();
        }

        private void UpdateOverlay()
        {
            if (_targetHandle == IntPtr.Zero || !Native.IsWindow(_targetHandle)) return;

            Native.RECT rect;
            if (Native.GetWindowRect(_targetHandle, out rect))
            {
                Location = new Point(rect.Left, rect.Top);
                Size = new Size(rect.Right - rect.Left, rect.Bottom - rect.Top);
                OverlayContext.OverlaySize = this.ClientSize;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ImGuiHelper.NewFrame();
            Render();
            DrawWatermark();
            ImGuiHelper.Render(e.Graphics);
        }

        private void DrawWatermark()
        {
            if (_config.ShowWatermark)
            {
                var draw = ImGui.GetForegroundDrawList();
                var text = _config.WatermarkText;
                var pos = new System.Numerics.Vector2(10, ClientSize.Height - 20);
                draw.AddText(pos, ImGui.ColorConvertFloat4ToU32(_config.WatermarkColor), text);
            }
        }
        private bool clickThrough = true;
        private bool overlayVisible = true;

        private void HandleHotkeys()
        {
            if (OverlayInput.IsKeyPressed(Keys.F1))
            {
                clickThrough = !clickThrough;
                Native.SetClickThrough(Handle, clickThrough);
            }

            if (OverlayInput.IsKeyPressed(Keys.F2))
            {
                overlayVisible = !overlayVisible;
                this.Opacity = overlayVisible ? 1 : 0;
            }
        }

        protected abstract void Render();
    }
}
