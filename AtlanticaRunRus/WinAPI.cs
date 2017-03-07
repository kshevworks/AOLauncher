using System;
using System.Runtime.InteropServices;

namespace AtlanticaRunRus
{
    public static class WinAPI
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    }
}
