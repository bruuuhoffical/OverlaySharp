using System.Drawing;
using System.Numerics;

namespace OverlaySharp
{
    public class OverlayConfig
    {
        public bool ShowWatermark { get; set; } = true;
        public string WatermarkText { get; set; } = "OverlaySharp by BRUUUH";
        public Vector4 WatermarkColor { get; set; } = new Vector4(0f, 1f, 0f, 1f);
    }
}
