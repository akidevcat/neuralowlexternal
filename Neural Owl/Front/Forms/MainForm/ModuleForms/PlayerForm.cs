using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NeuralOwl.Back.CheatModules;
using NeuralOwl.Configuration;

namespace NeuralOwl.Front.Forms.Main
{
    public partial class PlayerForm : Form
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

        private PlayerData data;

        public PlayerForm(PlayerData data, Form f)
        {
            Owner = f;
            InitializeComponent();

            this.data = data;
            UpdateVisual();

            var UpdateTimer = new Timer() { Interval = 1000 };
            UpdateTimer.Tick += Update;
            UpdateTimer.Start();

            Opacity = 0;
            Show();
            Update();
            for (double a = 0; a <= 1.0; a += 0.005)
            {
                Opacity = a;
                System.Threading.Thread.Sleep(1);
            }
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {

        }

        private void Update(object sender, EventArgs e) {
            var newData = PlayerData.Find(data.Address, PlayersList.Players);
            if (newData.Address == IntPtr.Zero)
                Dispose();
            else
            {
                this.data = newData;
                UpdateVisual();
            }
        }
        private void UpdateVisual()
        {
            PlayerName.Text = data.Name;
            Team.Text = data.Enemy ? "Enemy" : "Teammate";
            Rank.Text = data.Rank.ToString();
            Wins.Text = data.Wins.ToString();
            Health.Text = data.Health.ToString();
            Weapon.Text = data.HandsWeapon.ToString();
            CustomColor.BackColor = data.GlowColor;
        }

        private void CustomColor_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog.Color;
                CustomColor.BackColor = color;

                if (Config.PlayerList.Players == null)
                    Config.PlayerList.Players = new Config.OverridedPlayerColor[0];

                var list = Config.PlayerList.Players.ToList();

                int arraySize = Config.PlayerList.Players.Length;

                for (int p = 0; p < arraySize; p++)
                    if (list[p].Name.Contains(data.Name))
                    {
                        if (color == Color.Empty)
                            list.RemoveAt(p);
                        else
                        {
                            var temp = list[p];
                            temp.GlowColor = color;
                            list[p] = temp;
                        }
                        Config.PlayerList.Players = list.ToArray();
                        Config.Save();
                        return;
                    }

                var overridedColor = new Config.OverridedPlayerColor() { Name = data.Name, GlowColor = color };
                list.Add(overridedColor);

                Config.PlayerList.Players = list.ToArray();
                Config.Save();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            for (double a = 1.0; a >= 0; a -= 0.005)
            {
                Opacity = a;
                System.Threading.Thread.Sleep(1);
            }
            Dispose();
        }

        private void Team_Click(object sender, EventArgs e)
        {

        }
    }
}
