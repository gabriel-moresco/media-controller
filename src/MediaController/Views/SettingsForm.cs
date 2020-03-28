using System;
using System.Windows.Forms;

namespace MediaController.Views
{
    public partial class SettingsForm : Form
    {
        Microsoft.Win32.RegistryKey autorun;
        public SettingsForm()
        {
            InitializeComponent();
            autorun = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            labelVersion.Text = String.Format("Version {0}", Application.ProductVersion);
            checkBoxAutorun.Checked = (autorun.GetValue("MediaController") != null);
        }

        private void SaveSettings()
        {
            if (checkBoxAutorun.Checked)
                autorun.SetValue("MediaController", Application.ExecutablePath);
            else
                autorun.DeleteValue("MediaController", false);
        }

        private void linkLabelGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/gabriel-moresco/media-controller");
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }
    }
}
