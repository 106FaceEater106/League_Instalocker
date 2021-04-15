using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLInstalocker
{
    public partial class Form1 : Form
    {
        #region imports

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        const int MYACTION_HOTKEY_ID = 1;

        private string champion;
        private string role;

        #endregion
        public Form1()
        {
            InitializeComponent();
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 0, (int)Keys.F11);//Press F11 to get current mouse coordinates
        }

        private void Start()
        {
            champion = CHAMPION.Text;
            role = ROLE.Text;
            this.Cursor = new Cursor(Cursor.Current.Handle);

            //Search Champ
            MoveCursor(new Point(1127, 264));
            DoMouseClick();
            CopyPaste(champion);
            Thread.Sleep(500);
            //Choose Champ
            MoveCursor(new Point(705, 324));
            DoMouseClick();
            Thread.Sleep(500);
            //Lock In
            MoveCursor(new Point(960, 768));
            DoMouseClick();
            Thread.Sleep(500);
            //Chat
            MoveCursor(new Point(414, 842));
            DoMouseClick();
            CopyPaste(role);
            SendKeys.Send("{ENTER}");
        }

        private void CopyPaste(string text)
        {
            Clipboard.SetText(text);
            SendKeys.Send("^{v}");
        }

        private void DoMouseClick()
        {
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
            Thread.Sleep(20);
            mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        private void MoveCursor(Point point)
        {
            Cursor.Position = new Point(point.X, point.Y);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID)
            {
                Start();
            }
            base.WndProc(ref m);
        }
    }
}
