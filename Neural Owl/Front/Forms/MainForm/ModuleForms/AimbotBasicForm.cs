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
    public partial class AimbotBasicForm : Form
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

        public AimbotBasicForm(Form f)
        {
            Owner = f;
            InitializeComponent();

            CheatEnabled.Checked = Config.AimbotBasic.Enabled;
            FFA.Checked = Config.AimbotBasic.FFA;
            Key.Text = ((Keys)Config.AimbotBasic.Key).ToString();
            DelayBefore.Value = Config.AimbotBasic.DelayBefore;
            switch (Config.AimbotBasic.Type)
            {
                case Config.AimbotBasicConfig.AimbotBasicType.LerpCross:
                    TypeLerpCross.Checked = true;
                    break;

                case Config.AimbotBasicConfig.AimbotBasicType.LerpFov:
                    TypeLerpFov.Checked = true;
                    break;

                case Config.AimbotBasicConfig.AimbotBasicType.RCS:
                    TypeRcs.Checked = true;
                    break;
            }

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
                if (MessageBox.Show("Are you sure you want to reset AimbotBasic settings?", "Reset", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Config.AimbotBasic.Reset();
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
            Config.AimbotBasic.Enabled = CheatEnabled.Enabled;
            Config.Save();
        }

        private void FFA_CheckedChanged(object sender, EventArgs e)
        {
            Config.AimbotBasic.FFA = FFA.Checked;
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
                    Config.AimbotBasic.Key = 0;
                    Key.Text = "Always On";
                    Config.Save();
                    return true;
                }
                Config.AimbotBasic.Key = (int)keyData;
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

            var cfg = Config.AimbotBasic.WeaponsCfg[i];
            CurrentEnabled.Checked = cfg.Enabled;
            CurrentBone.SelectedIndex = cfg.Bone;
            CurrentDynamicFov.Checked = cfg.DynamicFov;
            CurrentFov.Value = cfg.Fov;
            CurrentRcs.Value = (int)(cfg.Rcs * CurrentRcs.Maximum);
            CurrentSmooth.Value = (int)(cfg.Smooth * CurrentSmooth.Maximum);
            //Config.Save();
        }

        private void CurrentEnabled_CheckedChanged(object sender, EventArgs e)
        {
            var i = CurrentWeapon.SelectedIndex;
            
            if (i == -1)
                return;

            var cfg = Config.AimbotBasic.WeaponsCfg[i];
            cfg.Enabled = CurrentEnabled.Checked;
            Config.Save();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Config.AimbotBasic.Type = Config.AimbotBasicConfig.AimbotBasicType.LerpCross;
            Config.Save();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Config.AimbotBasic.Type = Config.AimbotBasicConfig.AimbotBasicType.LerpFov;
            Config.Save();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Config.AimbotBasic.Type = Config.AimbotBasicConfig.AimbotBasicType.RCS;
            Config.Save();
        }

        private void CurrentBone_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = CurrentWeapon.SelectedIndex;

            if (i == -1)
                return;

            var cfg = Config.AimbotBasic.WeaponsCfg[i];
            cfg.Bone = (short)CurrentBone.SelectedIndex;
            Config.Save();
        }

        private void CurrentFov_Scroll(object sender, EventArgs e)
        {
            var i = CurrentWeapon.SelectedIndex;

            if (i == -1)
                return;

            var cfg = Config.AimbotBasic.WeaponsCfg[i];
            cfg.Fov = (short)CurrentFov.Value;
            Config.Save();
        }

        private void CurrentSmooth_Scroll(object sender, EventArgs e)
        {
            var i = CurrentWeapon.SelectedIndex;

            if (i == -1)
                return;

            var cfg = Config.AimbotBasic.WeaponsCfg[i];
            cfg.Smooth = (float)CurrentSmooth.Value / CurrentSmooth.Maximum;
            Config.Save();
        }

        private void CurrentRcs_Scroll(object sender, EventArgs e)
        {
            var i = CurrentWeapon.SelectedIndex;

            if (i == -1)
                return;

            var cfg = Config.AimbotBasic.WeaponsCfg[i];
            cfg.Rcs = (float)CurrentRcs.Value / CurrentRcs.Maximum;
            Config.Save();
        }

        private void CurrentDynamicFov_CheckedChanged(object sender, EventArgs e)
        {
            var i = CurrentWeapon.SelectedIndex;

            if (i == -1)
                return;

            var cfg = Config.AimbotBasic.WeaponsCfg[i];
            cfg.DynamicFov = CurrentDynamicFov.Checked;
            Config.Save();
        }

        private void DelayBefore_Scroll(object sender, EventArgs e)
        {
            Config.AimbotBasic.DelayBefore = (short)DelayBefore.Value;
            Config.Save();
        }
    }
}
