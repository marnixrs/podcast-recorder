namespace Recorder
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRefresh = new System.Windows.Forms.Button();
            this.speakBox = new System.Windows.Forms.ComboBox();
            this.micBox = new System.Windows.Forms.ComboBox();
            this.lbl_speak = new System.Windows.Forms.Label();
            this.lbl_mic = new System.Windows.Forms.Label();
            this.progressRecording = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnMix = new System.Windows.Forms.Button();
            this.lblRecording1 = new System.Windows.Forms.Label();
            this.lblRecording2 = new System.Windows.Forms.Label();
            this.btnShowFolder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLevelator = new System.Windows.Forms.Label();
            this.btnLocateLevelator = new System.Windows.Forms.Button();
            this.CheckBoxConvert = new System.Windows.Forms.CheckBox();
            this.CheckBoxLevelator = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.Location = new System.Drawing.Point(466, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(109, 62);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh Devices";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // speakBox
            // 
            this.speakBox.FormattingEnabled = true;
            this.speakBox.Location = new System.Drawing.Point(78, 56);
            this.speakBox.Name = "speakBox";
            this.speakBox.Size = new System.Drawing.Size(382, 21);
            this.speakBox.TabIndex = 3;
            // 
            // micBox
            // 
            this.micBox.FormattingEnabled = true;
            this.micBox.Location = new System.Drawing.Point(78, 19);
            this.micBox.Name = "micBox";
            this.micBox.Size = new System.Drawing.Size(382, 21);
            this.micBox.TabIndex = 2;
            // 
            // lbl_speak
            // 
            this.lbl_speak.AutoSize = true;
            this.lbl_speak.Location = new System.Drawing.Point(20, 59);
            this.lbl_speak.Name = "lbl_speak";
            this.lbl_speak.Size = new System.Drawing.Size(52, 13);
            this.lbl_speak.TabIndex = 1;
            this.lbl_speak.Text = "Speakers";
            // 
            // lbl_mic
            // 
            this.lbl_mic.AutoSize = true;
            this.lbl_mic.Location = new System.Drawing.Point(9, 22);
            this.lbl_mic.Name = "lbl_mic";
            this.lbl_mic.Size = new System.Drawing.Size(63, 13);
            this.lbl_mic.TabIndex = 0;
            this.lbl_mic.Text = "Microphone";
            // 
            // progressRecording
            // 
            this.progressRecording.Location = new System.Drawing.Point(6, 90);
            this.progressRecording.MarqueeAnimationSpeed = 10;
            this.progressRecording.Name = "progressRecording";
            this.progressRecording.Size = new System.Drawing.Size(753, 24);
            this.progressRecording.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(581, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(233, 28);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start recording";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackColor = System.Drawing.SystemColors.Control;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(581, 53);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(233, 28);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop recording";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnMix
            // 
            this.btnMix.Enabled = false;
            this.btnMix.Location = new System.Drawing.Point(466, 93);
            this.btnMix.Name = "btnMix";
            this.btnMix.Size = new System.Drawing.Size(348, 45);
            this.btnMix.TabIndex = 3;
            this.btnMix.Text = "Mix / Level / Convert";
            this.btnMix.UseVisualStyleBackColor = true;
            this.btnMix.Click += new System.EventHandler(this.btnMix_Click);
            // 
            // lblRecording1
            // 
            this.lblRecording1.AutoSize = true;
            this.lblRecording1.Location = new System.Drawing.Point(9, 28);
            this.lblRecording1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblRecording1.Name = "lblRecording1";
            this.lblRecording1.Size = new System.Drawing.Size(66, 13);
            this.lblRecording1.TabIndex = 11;
            this.lblRecording1.Text = "Microphone:";
            // 
            // lblRecording2
            // 
            this.lblRecording2.AutoSize = true;
            this.lblRecording2.Location = new System.Drawing.Point(9, 49);
            this.lblRecording2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblRecording2.Name = "lblRecording2";
            this.lblRecording2.Size = new System.Drawing.Size(55, 13);
            this.lblRecording2.TabIndex = 12;
            this.lblRecording2.Text = "Speakers:";
            // 
            // btnShowFolder
            // 
            this.btnShowFolder.Location = new System.Drawing.Point(345, 93);
            this.btnShowFolder.Name = "btnShowFolder";
            this.btnShowFolder.Size = new System.Drawing.Size(115, 45);
            this.btnShowFolder.TabIndex = 18;
            this.btnShowFolder.Text = "Show files in Explorer";
            this.btnShowFolder.UseVisualStyleBackColor = true;
            this.btnShowFolder.Click += new System.EventHandler(this.btnShowFolder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTime);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.lbl_mic);
            this.groupBox1.Controls.Add(this.progressRecording);
            this.groupBox1.Controls.Add(this.speakBox);
            this.groupBox1.Controls.Add(this.lbl_speak);
            this.groupBox1.Controls.Add(this.micBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(820, 120);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recorder";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(765, 90);
            this.lblTime.Name = "lblTime";
            this.lblTime.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblTime.Size = new System.Drawing.Size(49, 18);
            this.lblTime.TabIndex = 25;
            this.lblTime.Text = "00:00:00";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.lblLevelator);
            this.groupBox2.Controls.Add(this.btnLocateLevelator);
            this.groupBox2.Controls.Add(this.btnShowFolder);
            this.groupBox2.Controls.Add(this.CheckBoxConvert);
            this.groupBox2.Controls.Add(this.CheckBoxLevelator);
            this.groupBox2.Controls.Add(this.lblRecording1);
            this.groupBox2.Controls.Add(this.lblRecording2);
            this.groupBox2.Controls.Add(this.btnMix);
            this.groupBox2.Location = new System.Drawing.Point(12, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(820, 151);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mixer";
            // 
            // lblLevelator
            // 
            this.lblLevelator.AutoSize = true;
            this.lblLevelator.Location = new System.Drawing.Point(9, 70);
            this.lblLevelator.Name = "lblLevelator";
            this.lblLevelator.Size = new System.Drawing.Size(0, 13);
            this.lblLevelator.TabIndex = 21;
            this.lblLevelator.Text = global::Recorder.Properties.Settings.Default.LevelatorPath;
            // 
            // btnLocateLevelator
            // 
            this.btnLocateLevelator.Location = new System.Drawing.Point(224, 93);
            this.btnLocateLevelator.Name = "btnLocateLevelator";
            this.btnLocateLevelator.Size = new System.Drawing.Size(115, 45);
            this.btnLocateLevelator.TabIndex = 20;
            this.btnLocateLevelator.Text = "Locate Levelator";
            this.btnLocateLevelator.UseVisualStyleBackColor = true;
            this.btnLocateLevelator.Click += new System.EventHandler(this.btnLocateLevelator_Click);
            // 
            // CheckBoxConvert
            // 
            this.CheckBoxConvert.AutoSize = true;
            this.CheckBoxConvert.Checked = true;
            this.CheckBoxConvert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxConvert.Location = new System.Drawing.Point(9, 116);
            this.CheckBoxConvert.Name = "CheckBoxConvert";
            this.CheckBoxConvert.Size = new System.Drawing.Size(151, 17);
            this.CheckBoxConvert.TabIndex = 19;
            this.CheckBoxConvert.Text = "Convert mixed wav to mp3";
            this.CheckBoxConvert.UseVisualStyleBackColor = true;
            this.CheckBoxConvert.CheckedChanged += new System.EventHandler(this.CheckBoxConvert_CheckedChanged);
            // 
            // CheckBoxLevelator
            // 
            this.CheckBoxLevelator.AutoSize = true;
            this.CheckBoxLevelator.Enabled = false;
            this.CheckBoxLevelator.Location = new System.Drawing.Point(9, 93);
            this.CheckBoxLevelator.Name = "CheckBoxLevelator";
            this.CheckBoxLevelator.Size = new System.Drawing.Size(161, 17);
            this.CheckBoxLevelator.TabIndex = 18;
            this.CheckBoxLevelator.Text = "Pass mixed wav to Levelator";
            this.CheckBoxLevelator.UseVisualStyleBackColor = true;
            this.CheckBoxLevelator.CheckedChanged += new System.EventHandler(this.CheckBoxLevelator_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(844, 311);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(860, 350);
            this.MinimumSize = new System.Drawing.Size(860, 350);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Recorder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lbl_speak;
        private System.Windows.Forms.Label lbl_mic;
        private System.Windows.Forms.ProgressBar progressRecording;
        private System.Windows.Forms.ComboBox speakBox;
        private System.Windows.Forms.ComboBox micBox;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnMix;
        private System.Windows.Forms.Label lblRecording1;
        private System.Windows.Forms.Label lblRecording2;
        private System.Windows.Forms.Button btnShowFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.CheckBox CheckBoxConvert;
        private System.Windows.Forms.CheckBox CheckBoxLevelator;
        private System.Windows.Forms.Button btnLocateLevelator;
        private System.Windows.Forms.Label lblLevelator;
    }
}

