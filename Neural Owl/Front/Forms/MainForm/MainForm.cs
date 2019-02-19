using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using NeuralOwl.Back.CheatModules;
using NeuralOwl.Configuration;
using System.Diagnostics;

namespace NeuralOwl.Front.Forms.Main
{
    public partial class MainForm : Form
    {

        #region Subforms
        public DimForm dimForm;
        public ESPForm espForm;
        public TriggerbotForm triggerbotForm;
        public AimbotBasicForm aimbotBasicForm;
        public MiscForm miscForm;
        public AboutForm aboutForm;
        public PreferencesForm preferencesForm;
        #endregion

        private void MoveWindow(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, Win32.WM_NCLBUTTONDOWN, Win32.HT_CAPTION, 0);
            }
        }

        #region GlassEffect

        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        [StructLayout(LayoutKind.Sequential)]
        internal struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        internal enum WindowCompositionAttribute
        {
            // ...
            WCA_ACCENT_POLICY = 19
            // ...
        }

        internal enum AccentState
        {
            ACCENT_DISABLED = 0,
            ACCENT_ENABLE_GRADIENT = 1,
            ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
            ACCENT_ENABLE_BLURBEHIND = 3,
            ACCENT_INVALID_STATE = 4
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct AccentPolicy
        {
            public AccentState AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }

        public static void EnableBlur(IntPtr HWnd, bool hasFrame = true)
        {

            AccentPolicy accent = new AccentPolicy();
            accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;
            if (hasFrame)
                accent.AccentFlags = 0x20 | 0x40 | 0x80 | 0x100;

            int accentStructSize = Marshal.SizeOf(accent);

            IntPtr accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            WindowCompositionAttributeData data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            SetWindowCompositionAttribute(HWnd, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }



        #endregion

        public MainForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            WindowState = FormWindowState.Maximized;
            //EnableBlur(this.Handle);

            dimForm = new DimForm();
            this.Owner = dimForm;

            espForm = new ESPForm(this);
            triggerbotForm = new TriggerbotForm(this);
            aimbotBasicForm = new AimbotBasicForm(this);
            miscForm = new MiscForm(this);
            aboutForm = new AboutForm(this);
            preferencesForm = new PreferencesForm(this);

            Win32.SetClassLong(this.Handle, Win32.GCL_STYLE, Win32.GetClassLong(this.Handle, Win32.GCL_STYLE) | Win32.CS_DropSHADOW);
            DoubleBuffered = true;
            var toggleButtonWatcher = new System.Windows.Forms.Timer() { Interval = 1 };
            toggleButtonWatcher.Tick += ToggleButtonWatcher;
            toggleButtonWatcher.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            new Thread(() => ClockUpdate()).Start();
            //new Thread(() => CurveUpdate()).Start();
            var PlayersListTimer = new System.Windows.Forms.Timer() { Interval = 1000 };
            PlayersListTimer.Tick += PlayersListUpdate;
            PlayersListTimer.Start();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e) => Application.Exit();

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ClockIcon_Click(object sender, EventArgs e)
        {

        }


        private void ClockLabel_Click(object sender, EventArgs e)
        {
            
        }

        #region Clock
        delegate void SetClockCallback();

        private int lastIngameTick = 0;
        private void UpdateClockText()
        {
            if (this.ClockLabel.InvokeRequired)
            {
                SetClockCallback cb = new SetClockCallback(UpdateClockText);
                this.Invoke(cb);
            }
            else
            {
                var tick = Back.Main.CheatMain.ingameTick;
                ClockLabel.Text = DateTime.Now.ToString("h:mm:ss tt");
                if (lastIngameTick != 0)
                    TickLabel.Text = (tick - lastIngameTick).ToString();
                lastIngameTick = tick;
            }
        }

        private void ClockUpdate()
        {
            Thread.CurrentThread.IsBackground = true;

            while (true)
            {
                UpdateClockText();
                Thread.Sleep(1000);
            }
        }
        #endregion
        #region PlayersListUpdate
        private void PlayersListUpdate (object sender, EventArgs e)
        {
            if (PlayersPanel.Size.Height == 0)
                return;
            
            if (PlayersPanel.Controls.Count < 20)
                for (int i = 0; i < 20; i++)
                {
                    var playerButton = new Button();
                    playerButton.ForeColor = Color.White;
                    playerButton.FlatStyle = FlatStyle.Flat;
                    playerButton.FlatAppearance.BorderSize = 0;
                    playerButton.FlatAppearance.BorderColor = playerButton.BackColor;
                    playerButton.Size = new Size(PlayersPanel.Width, playerButton.Size.Height);
                    playerButton.Font = new Font("Courier New", 9);
                    playerButton.Click += OpenPlayerDataWindow;
                    playerButton.Visible = false;
                    PlayersPanel.Controls.Add(playerButton);
                }

            for (int i = 0; i < Math.Min(20, PlayersList.Players.Length); i++)
            {
                var playerButton = (Button)PlayersPanel.Controls[i];
                playerButton.Text = PlayersList.Players[i].Name;
                playerButton.Tag = PlayersList.Players[i].Id;
                playerButton.Visible = true;
            }

            for (int i = Math.Min(20, PlayersList.Players.Length); i < PlayersPanel.Controls.Count; i++)
                PlayersPanel.Controls[i].Visible = false;
        }
        private void OpenPlayerDataWindow (object sender, EventArgs e)
        {
            var btn = (Button)sender;
            int id = (int)btn.Tag;
            if (id >= PlayersList.Players.Length)
                return;
            var data = PlayersList.Players[id];

            var form = new PlayerForm(data, this);
        }
        #endregion
        #region CpuCurve
        delegate void SetCpuCurveCallback();
        private static PointF[] curvePoints;
        PerformanceCounter cpuCounter;
        private float cpuUsage = 0;

        private void CalcCurvePoints()
        {
            if (curvePoints == null)
            {
                curvePoints = new PointF[20];
                for (int i = 0; i < curvePoints.Length; i++)
                    curvePoints[i] = new Point();
            }

            const double freq = 10;
            const float speed = 10f;
            const float ySize = 100f;
            const float offsetEdge = .1f;

            float time = (DateTime.Now.Ticks % (int)(10000000 * speed)) / (10000000f * speed);
            
            for (int i = 0; i < curvePoints.Length; i++)
            {
                float v = (float)i / (curvePoints.Length - 1);
                float y = (float)Math.Sin((v + time) * 2.0 * Math.PI * freq);
                float ymod = Math.Min(1f, Math.Min(v, 1f - v) / offsetEdge);
                ymod *= ymod * ymod;
                curvePoints[i].X = v * Size.Width;
                curvePoints[i].Y = Size.Height - 100f - (y * ySize) * ymod * cpuUsage;
            }
        }

        private void UpdateCPUCurve(Color color, Graphics g)
        {
            var pen = new Pen(color);
            g.DrawLines(pen, curvePoints);
        }
        private void CurveUpdate()
        {
            Thread.CurrentThread.IsBackground = true;

            while (true)
            {
                if (cpuCounter == null)
                    cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                cpuUsage = 0.99f * cpuUsage + 0.01f * (cpuCounter.NextValue() / 100f);
                Thread.Sleep(16);
                Invalidate();

            }
        }
        #endregion

        private void CheatMenuPanel_Draw(object sender, PaintEventArgs e)
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //CalcCurvePoints();
            //UpdateCPUCurve(Color.White, e.Graphics);
        }

        private void LogoButton_Click(object sender, EventArgs e)
        {
            
        }

        private void ToggleButtonWatcher(object sender, EventArgs e)
        {
            if ((Win32.GetAsyncKeyState((Keys)Config.Preferences.ToggleKey) & 0x8000) != 0)
            {
                bool nextState = !Visible;
                var forms = Application.OpenForms;
                foreach (var o in forms)
                {
                    var f = (Form)o;
                    if (f.Equals(this) || f.Equals(dimForm))
                        continue;
                    var fop = f.Opacity;
                    bool visible = fop != 0 && nextState;
                    
                    if (!nextState && f.Visible)
                    {
                        for (double a = 1.0; a > 0; a -= 0.03)
                        {
                            f.Opacity = a;
                            Thread.Sleep(1);
                        }
                    }
                    if (nextState && visible)
                    {
                        f.Opacity = 0;
                        f.Show();
                        f.Update();
                        for (double a = 0; a <= 1.0; a += 0.03)
                        {
                            f.Opacity = a;
                            Thread.Sleep(1);
                        }
                    }
                    
                    f.Visible = visible;
                    f.Opacity = fop;
                }
                double bgopacity = Owner.Opacity;
                if (nextState)
                {
                    Owner.Opacity = 0;
                    Opacity = 0;
                    Owner.Visible = nextState;
                    Visible = nextState;
                    for (double a = 0; a <= 1; a += 0.03)
                    {
                        Opacity = a;
                        if (a > bgopacity)
                            Owner.Opacity = bgopacity;
                        else
                            Owner.Opacity = a;
                        Thread.Sleep(1);
                    }
                } else
                {
                    for (double a = 1.0; a >= 0; a -= 0.03)
                    {
                        Opacity = a;
                        if (a > bgopacity)
                            Owner.Opacity = bgopacity;
                        else
                            Owner.Opacity = a;
                        Thread.Sleep(1);
                    }
                }
                Owner.Visible = nextState;
                Owner.Opacity = bgopacity;
                Visible = nextState;
                Thread.Sleep(250);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            espForm.ShowFade();
        }

        private void MiscButton_Click(object sender, EventArgs e)
        {
            miscForm.ShowFade();
        }

        private void FileMenuButton_Click(object sender, EventArgs e)
        {
            AnimatedPanel.Toggle(FilePanel, 120);
        }

        private void ModulesMenuButton_Click(object sender, EventArgs e)
        {
            AnimatedPanel.Toggle(ModulesPanel, 150);
        }

        private void PlayersMenuButton_Click(object sender, EventArgs e)
        {
            AnimatedPanel.Toggle(PlayersPanel, 600);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            aboutForm.ShowFade();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.CurrentDirectory;
            dialog.Title = "Import Config";
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.DefaultExt = "cfg";
            dialog.Filter = "Config files (*.cfg)|*.cfg|All files (*.*)|*.*";
            dialog.FilterIndex = 2;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Config.ImportFromFile(dialog.FileName);
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.InitialDirectory = Environment.CurrentDirectory;
            dialog.Title = "Export Config";
            dialog.DefaultExt = "cfg";
            dialog.Filter = "Config files (*.cfg)|*.cfg|All files (*.*)|*.*";
            dialog.FilterIndex = 2;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Config.ExportToFile(dialog.FileName);
            }
        }

        private void PreferencesButton_Click(object sender, EventArgs e)
        {
            preferencesForm.ShowFade();
        }

        private void TriggerbotButton_Click(object sender, EventArgs e)
        {
            triggerbotForm.ShowFade();
        }

        private void AimbotMenuButton_Click(object sender, EventArgs e)
        {
            AnimatedPanel.Toggle(AimbotPanel, 300);
        }

        private void AimbotBasicButton_Click(object sender, EventArgs e)
        {
            aimbotBasicForm.ShowFade();
        }
    }







    
}
