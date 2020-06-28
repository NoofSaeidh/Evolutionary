using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.UI
{
    public class ConsoleWindowsWrapper
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(int handle);
        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleDisplayMode(IntPtr ConsoleOutput, uint Flags, out COORD NewScreenBufferDimensions);

        public static void FullScreenConsole()
        {
            IntPtr hConsole = GetStdHandle(-11);
            SetConsoleDisplayMode(hConsole, 1, out COORD b1);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct COORD
        {
            public short X;
            public short Y;
            public COORD(short X, short Y)
            {
                this.X = X;
                this.Y = Y;
            }
        }

    }
}
