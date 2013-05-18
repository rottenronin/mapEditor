using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MapEditor.Services
{
    static class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Message
        {
            public IntPtr hWind;
            public uint Msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint Time;
            public System.Drawing.Point Point;
        }

        [DllImport("User32.dll")]
        [return:MarshalAs(UnmanagedType.Bool)]
        public static extern bool PeekMessage(out Message message, IntPtr hWind, uint filterMin, uint filterMax, uint flags);

        
    }
}
