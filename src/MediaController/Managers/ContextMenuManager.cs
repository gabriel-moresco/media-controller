using System;
using System.Windows.Forms;

namespace MediaController.Managers
{
    public class ContextMenuManager
    {
        public static ContextMenu Create()
        {
            ContextMenu contextMenu = new ContextMenu();

            MenuItem contextItemSettings = new MenuItem();
            contextItemSettings.Text = "&Settings";
            contextItemSettings.Click += new EventHandler(contextMenuSettings_Click);
            contextMenu.MenuItems.Add(contextItemSettings);

            MenuItem contextItemExit = new MenuItem();
            contextItemExit.Text = "&Exit";
            contextItemExit.Click += new EventHandler(contextMenuExit_Click);
            contextMenu.MenuItems.Add(contextItemExit);

            return contextMenu;
        }

        private static void contextMenuSettings_Click(object sender, EventArgs e)
        {
            new Views.SettingsForm().ShowDialog();
        }

        private static void contextMenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
