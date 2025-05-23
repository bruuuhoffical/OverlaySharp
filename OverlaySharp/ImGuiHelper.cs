using ImGuiNET;
using System.Drawing;
using System.Windows.Forms;

namespace OverlaySharp
{
    public static class ImGuiHelper
    {
        private static bool _initialized = false;

        public static void NewFrame()
        {
            if (!_initialized)
            {
                ImGui.CreateContext();
                _initialized = true;
            }

            ImGui.NewFrame();
        }

        public static void Render(Graphics g)
        {
            ImGui.Render();
            ImGuiGDIRenderer.Render(g);
        }
    }
}
