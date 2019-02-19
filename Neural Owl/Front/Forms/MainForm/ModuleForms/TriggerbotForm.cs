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
    public partial class TriggerbotForm : Form
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

        public TriggerbotForm(Form f)
        {
            Owner = f;
            InitializeComponent();

            CheatEnabled.Checked = Config.Triggerbot.Enabled;
            FFA.Checked = Config.Triggerbot.FFA;
            Key.Text = ((Keys)Config.Triggerbot.Key).ToString();
            TypeCross.Checked = Config.Triggerbot.Type == Config.TriggerbotConfig.TriggerbotType.Cross;
            TypeFov.Checked = Config.Triggerbot.Type == Config.TriggerbotConfig.TriggerbotType.Fov;
            RandomizeDelay.Checked = Config.Triggerbot.RandomizeDelay;

            Hide();
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

        private void TriggerbotForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
            
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (Win32.GetKeyState(Keys.LShiftKey))
                if (MessageBox.Show("Are you sure to reset Triggerbot settings?", "Reset", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Config.Triggerbot.Reset();
                    Config.Save();
                    return;
                }
            for (double a = 1.0; a >= 0; a -= 0.005)
            {
                Opacity = a;
                System.Threading.Thread.Sleep(1);
            }
            Opacity = 0;
            Hide();
            
        }

        private void CheatEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Config.Triggerbot.Enabled = CheatEnabled.Enabled;
            Config.Save();
        }

        private void FFA_CheckedChanged(object sender, EventArgs e)
        {
            Config.Triggerbot.FFA = FFA.Checked;
            Config.Save();
        }

        private bool AwaitingKeyPress = false;
        private void Key_Click(object sender, EventArgs e)
        {
            AwaitingKeyPress = !AwaitingKeyPress;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (AwaitingKeyPress)
            {
                AwaitingKeyPress = false;
                if (keyData == Keys.Escape)
                {
                    Config.Triggerbot.Key = 0;
                    Key.Text = "Always On";
                    Config.Save();
                    return true;
                }
                Config.Triggerbot.Key = (int)keyData;
                Key.Text = keyData.ToString();
                Config.Save();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CurrentWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = CurrentWeapon.SelectedIndex;
            if (i == -1)
                return;

            var cfg = Config.Triggerbot.WeaponsCfg[i];
            CurrentEnabled.Checked = cfg.Enabled;
            CurrentDelayBefore.Value = cfg.DelayBefore;
            CurrentDelayAfter.Value = cfg.DelayAfter;
            CurrentDynamicFov.Checked = cfg.DynamicFov;
            CurrentFov.Value = cfg.Fov;
            CurrentBone.SelectedIndex = cfg.Bone;
        }

        private void CurrentEnabled_CheckedChanged(object sender, EventArgs e)
        {
            var i = CurrentWeapon.SelectedIndex;
            
            if (i == -1)
                return;

            var cfg = Config.Triggerbot.WeaponsCfg[i];
            cfg.Enabled = CurrentEnabled.Checked;
            Config.Save();
        }

        private void CurrentDelayBefore_TextChanged(object sender, EventArgs e)
        {
            var i = CurrentWeapon.SelectedIndex;
            if (i == -1)
                return;

            var cfg = Config.Triggerbot.WeaponsCfg[i];
            short.TryParse(CurrentDelayBefore.Text, out cfg.DelayBefore);
            Config.Save();
        }

        private void CurrentDelayAfter_TextChanged(object sender, EventArgs e)
        {
            var i = CurrentWeapon.SelectedIndex;
            if (i == -1)
                return;

            var cfg = Config.Triggerbot.WeaponsCfg[i];
            short.TryParse(CurrentDelayAfter.Text, out cfg.DelayAfter);
            Config.Save();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void TypeCross_CheckedChanged(object sender, EventArgs e)
        {
            if (TypeCross.Checked)
                Config.Triggerbot.Type = Config.TriggerbotConfig.TriggerbotType.Cross;
            Config.Save();
        }

        private void TypeFov_CheckedChanged(object sender, EventArgs e)
        {
            if (TypeFov.Checked)
                Config.Triggerbot.Type = Config.TriggerbotConfig.TriggerbotType.Fov;
            Config.Save();
        }

        private void CurrentBone_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = CurrentWeapon.SelectedIndex;
            if (i == -1 || CurrentBone.SelectedIndex == -1)
                return;

            var cfg = Config.Triggerbot.WeaponsCfg[i];
            cfg.Bone = (short)CurrentBone.SelectedIndex;
            Config.Save();
        }

        private void CurrentFov_Scroll(object sender, EventArgs e)
        {
            var i = CurrentWeapon.SelectedIndex;
            if (i == -1)
                return;

            var cfg = Config.Triggerbot.WeaponsCfg[i];
            cfg.Fov = (short)CurrentFov.Value;
            Config.Save();
        }

        private void CurrentDelayBefore_Scroll(object sender, EventArgs e)
        {
            var i = CurrentWeapon.SelectedIndex;
            if (i == -1)
                return;

            var cfg = Config.Triggerbot.WeaponsCfg[i];
            cfg.DelayBefore = (short)CurrentDelayBefore.Value;
            Config.Save();
        }

        private void CurrentDelayAfter_Scroll(object sender, EventArgs e)
        {
            var i = CurrentWeapon.SelectedIndex;
            if (i == -1)
                return;

            var cfg = Config.Triggerbot.WeaponsCfg[i];
            cfg.DelayAfter = (short)CurrentDelayAfter.Value;
            Config.Save();
        }

        private void RandomizeDelay_CheckedChanged(object sender, EventArgs e)
        {
            Config.Triggerbot.RandomizeDelay = RandomizeDelay.Checked;
            Config.Save();
        }
    }
}
