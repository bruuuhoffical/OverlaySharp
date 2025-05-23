using System;
using System.Drawing;
using System.Numerics;

namespace OverlaySharp
{
    public static class PositionHelper
    {
        public static Vector2 Get(string anchorKeyword, Size overlaySize, SizeF elementSize)
        {
            anchorKeyword = anchorKeyword.ToLowerInvariant().Trim();

            float x = 0, y = 0;

            if (anchorKeyword.Contains("top")) y = 0;
            else if (anchorKeyword.Contains("middle") || anchorKeyword.Contains("center")) y = (overlaySize.Height - elementSize.Height) / 2;
            else if (anchorKeyword.Contains("bottom")) y = overlaySize.Height - elementSize.Height;

            if (anchorKeyword.Contains("left")) x = 0;
            else if (anchorKeyword.Contains("center")) x = (overlaySize.Width - elementSize.Width) / 2;
            else if (anchorKeyword.Contains("right")) x = overlaySize.Width - elementSize.Width;

            return new Vector2(x, y);
        }
    }
}
