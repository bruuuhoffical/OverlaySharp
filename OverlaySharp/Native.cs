using System;
using System.Runtime.InteropServices;

namespace OverlaySharp
{
    internal static class Native
    {
        [DllImport("user32.dll")] public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll")] public static extern bool IsWindow(IntPtr hWnd);
        [DllImport("user32.dll")] private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")] private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")] private static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        public static void MakeTransparent(IntPtr hWnd)
        {
            int style = GetWindowLong(hWnd, -20);
            SetWindowLong(hWnd, -20, style | 0x80000 | 0x20);
            SetLayeredWindowAttributes(hWnd, 0, 255, 0x2);
        }
        public static void SetClickThrough(IntPtr hWnd, bool enable)
        {
            int style = GetWindowLong(hWnd, -20);
            if (enable)
                SetWindowLong(hWnd, -20, style | 0x80000 | 0x20); 
            else
                SetWindowLong(hWnd, -20, style & ~0x20); 
        }

        public struct RECT { public int Left, Top, Right, Bottom; }
    }
}
