using ImGuiNET;
using System.Drawing;

namespace OverlaySharp
{
    public static class ImGuiGDIRenderer
    {
        public static void Render(Graphics g)
        {
            ImDrawDataPtr drawData = ImGui.GetDrawData();

            if (drawData.CmdListsCount == 0 || drawData.TotalVtxCount == 0)
                return;

            for (int n = 0; n < drawData.CmdListsCount; n++)
            {
                ImDrawListPtr cmdList = drawData.CmdLists[n];

                for (int vtx_i = 0; vtx_i < cmdList.VtxBuffer.Size; vtx_i++)
                {
                    var vtx = cmdList.VtxBuffer[vtx_i];

                    var col = Color.FromArgb(
                        (int)((vtx.col >> 24) & 0xFF),
                        (int)((vtx.col >> 0) & 0xFF),
                        (int)((vtx.col >> 8) & 0xFF),
                        (int)((vtx.col >> 16) & 0xFF)
                    );

                    var pos = new PointF(vtx.pos.X, vtx.pos.Y);
                    using var brush = new SolidBrush(col);
                    g.FillRectangle(brush, pos.X, pos.Y, 1, 1);
                }
            }
        }
    }
}
