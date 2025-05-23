using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OverlaySharp
{
    public static class OverlayInput
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        public static bool IsKeyDown(Keys key)
        {
            return (GetAsyncKeyState(key) & 0x8000) != 0;
        }

        public static bool IsKeyPressed(Keys key)
        {
            return GetAsyncKeyState(key) == -32767;
        }
    }
}
