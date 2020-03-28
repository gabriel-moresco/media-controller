using System;
using System.Drawing;
using System.Windows.Forms;

namespace MediaController.Managers
{
    public class SystemTrayIconManager
    {
        static ContextMenu contextMenu = ContextMenuManager.Create();

        public static void Create(Keys hotkey, string iconText, Icon buttonIcon, Action action, int delayAfterPressed)
        {
            NotifyIcon notifyIcon = new NotifyIcon();

            notifyIcon.MouseClick += new MouseEventHandler(MouseClick);
            notifyIcon.Tag = action;
            notifyIcon.Icon = buttonIcon;
            notifyIcon.Text = iconText;
            notifyIcon.Visible = true;
            notifyIcon.ContextMenu = contextMenu;

            HotkeyManager.Instance.ConfigureHotkey(hotkey, action, delayAfterPressed);
        }

        static void MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ((sender as NotifyIcon).Tag as Action)();
            }
        }
    }
}
