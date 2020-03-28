using MediaController.Managers;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MediaController
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SystemTrayIconManager.Create(Keys.Oemcomma, "Previous (Ctrl + Alt + ,)", Properties.Resources.Backward, GoToPreviousMusic, 300);
            SystemTrayIconManager.Create(Keys.Oem2, "Play / Pause (Ctrl + Alt + ;)", Properties.Resources.PlayPause, PlayPause, 300);
            SystemTrayIconManager.Create(Keys.OemPeriod, "Next (Ctrl + Alt + .)", Properties.Resources.Forward, GoToNextMusic, 300);

            HotkeyManager.Instance.ConfigureHotkey(Keys.M, Mute, 0);
            HotkeyManager.Instance.ConfigureHotkey(Keys.Oem5, SetVolumeUp, 0);
            HotkeyManager.Instance.ConfigureHotkey(Keys.Oem6, SetVolumeDown, 0);

            Application.Run();
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        static void GoToPreviousMusic()
        {
            keybd_event((byte)Keys.MediaPreviousTrack, 0, 0, IntPtr.Zero);
        }

        static void GoToNextMusic()
        {
            keybd_event((byte)Keys.MediaNextTrack, 0, 0, IntPtr.Zero);
        }

        static void PlayPause()
        {
            keybd_event((byte)Keys.MediaPlayPause, 0, 0, IntPtr.Zero);
        }

        static void Mute()
        {
            keybd_event((byte)Keys.VolumeMute, 0, 0, IntPtr.Zero);
        }

        static void SetVolumeDown()
        {
            keybd_event((byte)Keys.VolumeUp, 0, 0, IntPtr.Zero);
        }

        static void SetVolumeUp()
        {
            keybd_event((byte)Keys.VolumeDown, 0, 0, IntPtr.Zero);
        }
    }
}
