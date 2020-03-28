using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace MediaController.Managers
{
    public partial class HotkeyManager : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        static HotkeyManager _instance;
        public static HotkeyManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HotkeyManager();
                }

                return _instance;
            }
        }

        Dictionary<int, Action> hotkeyAction = new Dictionary<int, Action>();
        Dictionary<int, int> hotkeyDelay = new Dictionary<int, int>();

        public void ConfigureHotkey(Keys key, Action action, int delayAfterPressed)
        {
            int hotkeyId = hotkeyAction.Count + 1;

            hotkeyAction.Add(hotkeyId, action);
            hotkeyDelay.Add(hotkeyId, delayAfterPressed);

            RegisterHotKey(this.Handle, hotkeyId, 3, (int)key);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();

                Thread.Sleep(hotkeyDelay[id]);

                hotkeyAction[id]();
            }

            base.WndProc(ref m);
        }
    }
}
