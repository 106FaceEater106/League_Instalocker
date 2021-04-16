using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLInstalocker
{
    public partial class InstaLocker : System.Windows.Forms.Form
    {
        /// <summary>
        /// Imports
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        #region imports

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);


        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);


        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        const int MYACTION_HOTKEY_ID = 1;

        #endregion

        private string champion;
        private string role;
        private bool running = false;

        /// <summary>
        /// Initialize Form
        /// </summary>
        public InstaLocker()
        {
            InitializeComponent();
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 0, (int)Keys.F11);//Press F11 to get current mouse coordinates
        }

        /// <summary>
        /// Run the program
        /// </summary>
        private void Run()
        {
            champion = CHAMPION.Text;
            role = ROLE.Text;

            //Search Champ
            MoveCursor(new Point(1127, 264));
            DoMouseClick();
            CopyPaste(champion);
            Thread.Sleep(10);

            //Choose Champ
            MoveCursor(new Point(705, 324));
            for (var i = 0; i < 10; i++) { DoMouseClick(); }
            Thread.Sleep(100);

            //Lock In
            MoveCursor(new Point(960, 768));
            DoMouseClick();
            Thread.Sleep(10);

            //Chat
            if (role != null)
            {
                MoveCursor(new Point(414, 842));
                Thread.Sleep(10);
                DoMouseClick();
                Thread.Sleep(10);
                CopyPaste(role);
                SendKeys.Send("{ENTER}");
            }
            Clipboard.Clear();
        }

        /// <summary>
        /// Copy and paste a text
        /// </summary>
        /// <param name="text"></param>
        private void CopyPaste(string text)
        {
            Clipboard.SetText(text);
            SendKeys.Send("^{v}");
        }

        /// <summary>
        /// Perform a mouseclick
        /// </summary>
        private void DoMouseClick()
        {
            Thread.Sleep(20);
            var X = (uint)Cursor.Position.X;
            var Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
            Thread.Sleep(20);
            mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        /// <summary>
        /// Move Cursor to Point
        /// </summary>
        /// <param name="point"></param>
        private void MoveCursor(Point point)
        {
            Cursor.Position = new Point(point.X, point.Y);
        }

        /// <summary>
        /// MouseEvent
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID)
            {
                if(running == false)
                {
                    running = true;
                    this.BackColor = Color.Green;
                    TIMER.Start();
                    //Go to AcceptQ
                    MoveCursor(new Point(960, 718));
                } else
                {
                    running = false;
                    this.BackColor = Color.Maroon;
                    TIMER.Stop();
                }
                
            }
            base.WndProc(ref m);
        }

        Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
        public Color GetColorAt(Point location)
        {
            using (var gdest = Graphics.FromImage(screenPixel))
            {
                using (var gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    var hSrcDC = gsrc.GetHdc();
                    var hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            return screenPixel.GetPixel(0, 0);
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            var pixel = GetColorAt(new Point(765,190));

            DoMouseClick();

            if (pixel.R == 0 && pixel.G == 0 && pixel.B == 0) {

                TIMER.Stop();
                running = false;
                this.BackColor = Color.Maroon;
                Thread.Sleep(300);
                Run();
            }
        }
    }
}
