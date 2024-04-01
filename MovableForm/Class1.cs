using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MoveableForm
{
    public class Class1
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public static void AddDrag(Control control)
        {
            control.MouseDown += new MouseEventHandler(DragForm_MouseDown);
        }

        private static void DragForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage((sender as Control).Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                
                if ((sender as Control).FindForm().Location.Y == 0)
                {
                    (sender as Control).FindForm().WindowState = FormWindowState.Maximized;
                }
            }
        }
    }
}
