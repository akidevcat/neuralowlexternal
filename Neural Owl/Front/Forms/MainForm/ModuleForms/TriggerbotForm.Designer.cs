namespace NeuralOwl.Front.Forms.Main
{
    partial class TriggerbotForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.Key = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CheatEnabled = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CurrentWeapon = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FFA = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CurrentEnabled = new System.Windows.Forms.CheckBox();
            this.TypeFov = new System.Windows.Forms.RadioButton();
            this.TypeCross = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.CurrentBone = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CurrentDelayBefore = new System.Windows.Forms.TrackBar();
            this.CurrentDelayAfter = new System.Windows.Forms.TrackBar();
            this.CurrentFov = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.CurrentDynamicFov = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.RandomizeDelay = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentDelayBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentDelayAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentFov)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(597, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Triggerbot";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveWindow);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.CloseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Marlett", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(557, 0);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(40, 37);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Key
            // 
            this.Key.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Key.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Key.FlatAppearance.BorderSize = 0;
            this.Key.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.Key.ForeColor = System.Drawing.Color.White;
            this.Key.Location = new System.Drawing.Point(131, 301);
            this.Key.Margin = new System.Windows.Forms.Padding(4);
            this.Key.Name = "Key";
            this.Key.Size = new System.Drawing.Size(108, 37);
            this.Key.TabIndex = 9;
            this.Key.Text = "Alt";
            this.Key.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Key.UseVisualStyleBackColor = false;
            this.Key.Click += new System.EventHandler(this.Key_Click);
            // 
            // label
            // 
            this.label.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label.Location = new System.Drawing.Point(7, 297);
            this.label.Margin = new System.Windows.Forms.Padding(0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(129, 37);
            this.label.TabIndex = 4;
            this.label.Text = "Key";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(296, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 37);
            this.label3.TabIndex = 4;
            this.label3.Text = "Enabled";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CheatEnabled
            // 
            this.CheatEnabled.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CheatEnabled.Location = new System.Drawing.Point(214, 196);
            this.CheatEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.CheatEnabled.Name = "CheatEnabled";
            this.CheatEnabled.Size = new System.Drawing.Size(27, 37);
            this.CheatEnabled.TabIndex = 4;
            this.CheatEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheatEnabled.UseVisualStyleBackColor = true;
            this.CheatEnabled.CheckedChanged += new System.EventHandler(this.CheatEnabled_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(296, 73);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 37);
            this.label8.TabIndex = 4;
            this.label8.Text = "Weapon";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentWeapon
            // 
            this.CurrentWeapon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CurrentWeapon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CurrentWeapon.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentWeapon.FormattingEnabled = true;
            this.CurrentWeapon.Items.AddRange(new object[] {
            "DEAGLE",
            "ELITE",
            "FIVESEVEN",
            "GLOCK",
            "AK47",
            "AUG",
            "AWP",
            "FAMAS",
            "G3SG1",
            "GALILAR",
            "M249",
            "M4A1",
            "MAC10",
            "P90",
            "UMP45",
            "XM1014",
            "BIZON",
            "MAG7",
            "NEGEV",
            "SAWEDOFF",
            "TEC9",
            "TASER",
            "HKP2000",
            "MP7",
            "MP9",
            "NOVA",
            "P250",
            "SCAR20",
            "SG556",
            "SSG08",
            "M4A1-S",
            "USP-S",
            "CZ75A",
            "REVOLVER",
            "MP5"});
            this.CurrentWeapon.Location = new System.Drawing.Point(454, 84);
            this.CurrentWeapon.Margin = new System.Windows.Forms.Padding(4);
            this.CurrentWeapon.Name = "CurrentWeapon";
            this.CurrentWeapon.Size = new System.Drawing.Size(130, 23);
            this.CurrentWeapon.TabIndex = 6;
            this.CurrentWeapon.TabStop = false;
            this.CurrentWeapon.SelectedIndexChanged += new System.EventHandler(this.CurrentWeapon_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(296, 213);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 37);
            this.label7.TabIndex = 4;
            this.label7.Text = "Delay After";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(9, 229);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 37);
            this.label6.TabIndex = 4;
            this.label6.Text = "FFA Mode";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FFA
            // 
            this.FFA.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.FFA.Location = new System.Drawing.Point(214, 229);
            this.FFA.Margin = new System.Windows.Forms.Padding(4);
            this.FFA.Name = "FFA";
            this.FFA.Size = new System.Drawing.Size(27, 37);
            this.FFA.TabIndex = 4;
            this.FFA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FFA.UseVisualStyleBackColor = true;
            this.FFA.CheckedChanged += new System.EventHandler(this.FFA_CheckedChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(296, 178);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 37);
            this.label4.TabIndex = 4;
            this.label4.Text = "Delay Before";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(9, 192);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 37);
            this.label5.TabIndex = 4;
            this.label5.Text = "Enabled";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentEnabled
            // 
            this.CurrentEnabled.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CurrentEnabled.Location = new System.Drawing.Point(557, 112);
            this.CurrentEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.CurrentEnabled.Name = "CurrentEnabled";
            this.CurrentEnabled.Size = new System.Drawing.Size(27, 37);
            this.CurrentEnabled.TabIndex = 4;
            this.CurrentEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CurrentEnabled.UseVisualStyleBackColor = true;
            this.CurrentEnabled.CheckedChanged += new System.EventHandler(this.CurrentEnabled_CheckedChanged);
            // 
            // TypeFov
            // 
            this.TypeFov.AutoSize = true;
            this.TypeFov.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.TypeFov.ForeColor = System.Drawing.Color.White;
            this.TypeFov.Location = new System.Drawing.Point(12, 112);
            this.TypeFov.Name = "TypeFov";
            this.TypeFov.Size = new System.Drawing.Size(258, 29);
            this.TypeFov.TabIndex = 15;
            this.TypeFov.TabStop = true;
            this.TypeFov.Text = "Triggerbot > CROSS + FOV";
            this.TypeFov.UseVisualStyleBackColor = true;
            this.TypeFov.CheckedChanged += new System.EventHandler(this.TypeFov_CheckedChanged);
            // 
            // TypeCross
            // 
            this.TypeCross.AutoSize = true;
            this.TypeCross.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.TypeCross.ForeColor = System.Drawing.Color.White;
            this.TypeCross.Location = new System.Drawing.Point(12, 77);
            this.TypeCross.Name = "TypeCross";
            this.TypeCross.Size = new System.Drawing.Size(200, 29);
            this.TypeCross.TabIndex = 14;
            this.TypeCross.TabStop = true;
            this.TypeCross.Text = "Triggerbot > CROSS";
            this.TypeCross.UseVisualStyleBackColor = true;
            this.TypeCross.CheckedChanged += new System.EventHandler(this.TypeCross_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(9, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 37);
            this.label2.TabIndex = 13;
            this.label2.Text = ":: Type ::";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(9, 155);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(221, 37);
            this.label9.TabIndex = 16;
            this.label9.Text = ":: Basic Settings ::";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(296, 37);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(208, 37);
            this.label10.TabIndex = 17;
            this.label10.Text = ":: Individual Settings ::";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentBone
            // 
            this.CurrentBone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CurrentBone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CurrentBone.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentBone.FormattingEnabled = true;
            this.CurrentBone.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.CurrentBone.Location = new System.Drawing.Point(454, 154);
            this.CurrentBone.Margin = new System.Windows.Forms.Padding(4);
            this.CurrentBone.Name = "CurrentBone";
            this.CurrentBone.Size = new System.Drawing.Size(130, 23);
            this.CurrentBone.TabIndex = 19;
            this.CurrentBone.TabStop = false;
            this.CurrentBone.SelectedIndexChanged += new System.EventHandler(this.CurrentBone_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Location = new System.Drawing.Point(296, 143);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 37);
            this.label11.TabIndex = 18;
            this.label11.Text = "Bone";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentDelayBefore
            // 
            this.CurrentDelayBefore.AutoSize = false;
            this.CurrentDelayBefore.Location = new System.Drawing.Point(444, 189);
            this.CurrentDelayBefore.Maximum = 180;
            this.CurrentDelayBefore.Name = "CurrentDelayBefore";
            this.CurrentDelayBefore.Size = new System.Drawing.Size(150, 20);
            this.CurrentDelayBefore.TabIndex = 20;
            this.CurrentDelayBefore.TickStyle = System.Windows.Forms.TickStyle.None;
            this.CurrentDelayBefore.Value = 1;
            this.CurrentDelayBefore.Scroll += new System.EventHandler(this.CurrentDelayBefore_Scroll);
            // 
            // CurrentDelayAfter
            // 
            this.CurrentDelayAfter.AutoSize = false;
            this.CurrentDelayAfter.Location = new System.Drawing.Point(444, 223);
            this.CurrentDelayAfter.Maximum = 180;
            this.CurrentDelayAfter.Name = "CurrentDelayAfter";
            this.CurrentDelayAfter.Size = new System.Drawing.Size(150, 20);
            this.CurrentDelayAfter.TabIndex = 21;
            this.CurrentDelayAfter.TickStyle = System.Windows.Forms.TickStyle.None;
            this.CurrentDelayAfter.Value = 1;
            this.CurrentDelayAfter.Scroll += new System.EventHandler(this.CurrentDelayAfter_Scroll);
            // 
            // CurrentFov
            // 
            this.CurrentFov.AutoSize = false;
            this.CurrentFov.Location = new System.Drawing.Point(444, 260);
            this.CurrentFov.Maximum = 90;
            this.CurrentFov.Name = "CurrentFov";
            this.CurrentFov.Size = new System.Drawing.Size(150, 20);
            this.CurrentFov.TabIndex = 23;
            this.CurrentFov.TickStyle = System.Windows.Forms.TickStyle.None;
            this.CurrentFov.Value = 1;
            this.CurrentFov.Scroll += new System.EventHandler(this.CurrentFov_Scroll);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(296, 248);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 37);
            this.label12.TabIndex = 22;
            this.label12.Text = "Fov";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentDynamicFov
            // 
            this.CurrentDynamicFov.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CurrentDynamicFov.Location = new System.Drawing.Point(557, 287);
            this.CurrentDynamicFov.Margin = new System.Windows.Forms.Padding(4);
            this.CurrentDynamicFov.Name = "CurrentDynamicFov";
            this.CurrentDynamicFov.Size = new System.Drawing.Size(27, 37);
            this.CurrentDynamicFov.TabIndex = 26;
            this.CurrentDynamicFov.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CurrentDynamicFov.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(296, 283);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(221, 37);
            this.label13.TabIndex = 27;
            this.label13.Text = "Dynamic Fov";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RandomizeDelay
            // 
            this.RandomizeDelay.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RandomizeDelay.Location = new System.Drawing.Point(214, 264);
            this.RandomizeDelay.Margin = new System.Windows.Forms.Padding(4);
            this.RandomizeDelay.Name = "RandomizeDelay";
            this.RandomizeDelay.Size = new System.Drawing.Size(27, 37);
            this.RandomizeDelay.TabIndex = 28;
            this.RandomizeDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RandomizeDelay.UseVisualStyleBackColor = true;
            this.RandomizeDelay.CheckedChanged += new System.EventHandler(this.RandomizeDelay_CheckedChanged);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Location = new System.Drawing.Point(7, 260);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(166, 37);
            this.label14.TabIndex = 29;
            this.label14.Text = "Randomize Delay";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TriggerbotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(597, 404);
            this.Controls.Add(this.RandomizeDelay);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.CurrentDynamicFov);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.CurrentFov);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.CurrentDelayAfter);
            this.Controls.Add(this.CurrentDelayBefore);
            this.Controls.Add(this.CurrentBone);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TypeFov);
            this.Controls.Add(this.TypeCross);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CurrentWeapon);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.FFA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CurrentEnabled);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Key);
            this.Controls.Add(this.label);
            this.Controls.Add(this.CheatEnabled);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TriggerbotForm";
            this.Text = "ESPForm";
            this.Load += new System.EventHandler(this.TriggerbotForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CurrentDelayBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentDelayAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentFov)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button Key;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox CheatEnabled;
        private System.Windows.Forms.ComboBox CurrentWeapon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox FFA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CurrentEnabled;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton TypeFov;
        private System.Windows.Forms.RadioButton TypeCross;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CurrentBone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar CurrentDelayBefore;
        private System.Windows.Forms.TrackBar CurrentDelayAfter;
        private System.Windows.Forms.TrackBar CurrentFov;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox CurrentDynamicFov;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox RandomizeDelay;
        private System.Windows.Forms.Label label14;
    }
}