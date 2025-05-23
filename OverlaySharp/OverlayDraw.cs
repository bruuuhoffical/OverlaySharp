using ImGuiNET;
using System;
using System.Drawing;
using System.Numerics;

namespace OverlaySharp
{
    public static class OverlayDraw
    {
        public static void DrawText(object pos, string text, Color color)
        {
            var draw = ImGui.GetForegroundDrawList();
            var col = ImGui.ColorConvertFloat4ToU32(ColorToVec4(color));
            var textSize = ImGui.CalcTextSize(text);
            var sizeF = new SizeF(textSize.X, textSize.Y);
            var vec = ResolvePosition(pos, sizeF);

            draw.AddText(vec, col, text);
        }

        public static void DrawBox(object pos, float width, float height, Color color, float thickness = 1f)
        {
            var draw = ImGui.GetForegroundDrawList();
            var col = ImGui.ColorConvertFloat4ToU32(ColorToVec4(color));
            var topLeft = ResolvePosition(pos, new SizeF(width, height));
            var bottomRight = topLeft + new Vector2(width, height);

            draw.AddRect(topLeft, bottomRight, col, 0f, ImDrawFlags.None, thickness);
        }

        public static void DrawLine(object start, object end, Color color, float thickness = 1f)
        {
            var draw = ImGui.GetForegroundDrawList();
            var col = ImGui.ColorConvertFloat4ToU32(ColorToVec4(color));
            var p1 = ResolvePosition(start);
            var p2 = ResolvePosition(end);

            draw.AddLine(p1, p2, col, thickness);
        }

        public static void DrawCircle(object center, float radius, Color color, int segments = 30, float thickness = 1f)
        {
            var draw = ImGui.GetForegroundDrawList();
            var col = ImGui.ColorConvertFloat4ToU32(ColorToVec4(color));
            var c = ResolvePosition(center, new SizeF(radius * 2, radius * 2)); // ✅ good

            draw.AddCircle(c, radius, col, segments, thickness);
        }

        private static Vector2 ResolvePosition(object pos, SizeF elementSize = default)
        {
            if (pos is Vector2 vec)
                return vec;

            if (pos is string keyword)
                return PositionHelper.Get(keyword, OverlayContext.OverlaySize, elementSize);

            throw new ArgumentException("Position must be Vector2 or anchor string like 'top left'");
        }

        private static Vector4 ColorToVec4(Color c)
        {
            return new Vector4(c.R / 255f, c.G / 255f, c.B / 255f, c.A / 255f);
        }
    }
}
