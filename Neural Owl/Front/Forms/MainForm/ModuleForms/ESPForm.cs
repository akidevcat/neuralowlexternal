using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NeuralOwl.Configuration;

namespace NeuralOwl.Front.Forms.Main
{
    public partial class ESPForm : Form
    {
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        private void MoveWindow(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public ESPForm(Form f)
        {
            Owner = f;
            InitializeComponent();
            CheatEnabled.Checked = Config.ESP.Enabled;
            FullBloom.Checked = Config.ESP.FullBloom;
            ShowEnemies.Checked = Config.ESP.ShowEnemies;
            ShowTeammates.Checked = Config.ESP.ShowTeammates;
            EnemiesColor.BackColor = Config.ESP.EnemyColor;
            TeammatesColor.BackColor = Config.ESP.TeammateColor;
            VelocityMode.Checked = Config.ESP.VelocityMode;
            PulseStyle.Checked = Config.ESP.PulseStyle;
            OverrideClrRender.Checked = Config.ESP.ClrRender;
        }

        public void ShowFade()
        {
            Opacity = 0;
            Show();
            Update();
            for (double a = 0; a <= 1.0; a += 0.005)
            {
                Opacity = a;
                System.Threading.Thread.Sleep(1);
            }
        }

        private void ESPForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            for (double a = 1.0; a >= 0; a -= 0.005)
            {
                Opacity = a;
                System.Threading.Thread.Sleep(1);
            }
            Opacity = 0;
            Hide();
        }

        private void Enabled_CheckedChanged(object sender, EventArgs e)
        {
            Config.ESP.Enabled = CheatEnabled.Checked;
            Config.Save();
        }

        private void FullBloom_CheckedChanged(object sender, EventArgs e)
        {
            Config.ESP.FullBloom = FullBloom.Checked;
            Config.Save();
        }

        private void ShowEnemies_CheckedChanged(object sender, EventArgs e)
        {
            Config.ESP.ShowEnemies = ShowEnemies.Checked;
            Config.Save();
        }

        private void ShowTeammates_CheckedChanged(object sender, EventArgs e)
        {
            Config.ESP.ShowTeammates = ShowTeammates.Checked;
            Config.Save();
        }

        private void EnemiesColor_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                EnemiesColor.BackColor = color;
                Config.ESP.EnemyColor = color;
                Config.Save();
            }
        }

        private void TeammatesColor_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                TeammatesColor.BackColor = color;
                Config.ESP.TeammateColor = color;
                Config.Save();
            }
        }

        private void VelocityMode_CheckedChanged(object sender, EventArgs e)
        {
            Config.ESP.VelocityMode = VelocityMode.Checked;
            Config.Save();
        }

        private void PulseStyle_CheckedChanged(object sender, EventArgs e)
        {
            Config.ESP.PulseStyle = PulseStyle.Checked;
            Config.Save();
        }

        private void ClrRenderColor_Click(object sender, EventArgs e)
        {

        }

        private void OverrideClrRender_CheckedChanged(object sender, EventArgs e)
        {
            Config.ESP.ClrRender = OverrideClrRender.Checked;
            Config.Save();
        }
    }
}
