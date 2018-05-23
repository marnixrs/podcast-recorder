using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using CSCore;
using CSCore.CoreAudioAPI;
using System.Diagnostics;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Recorder
{
    public partial class MainWindow : Form
    {
        private MMDevice selectedMicDevice;
        private MMDevice selectedSpeakDevice;
        private MMDevice[] micDevices;
        private MMDevice[] speakDevices;
        private CSCoreRecorder recorder;
        private int seconds = 0, minutes = 0, hours = 0;
        private Timer timer;
        private string levelatorPath = "";
        private LoadingForm lf = null;
        private BackgroundWorker worker;
        private bool isRecording, isMixing;

        public MainWindow()
        {
            InitializeComponent();
            refreshDevices();
            recorder = new CSCoreRecorder(this);
            checkLevelatorStatus();
            CheckBoxConvert.Checked = Properties.Settings.Default.Convert;
            isRecording = false;
            isMixing = false;
        }

        private void checkLevelatorStatus() {
            string path = Properties.Settings.Default.LevelatorPath;
            if (path != "" && path != null)
            {
                if (File.Exists(path))
                {
                    CheckBoxLevelator.Enabled = true;
                    CheckBoxLevelator.Checked = Properties.Settings.Default.Levelate;
                    levelatorPath = path;
                    lblLevelator.Text = path;
                }
                else
                {
                    CheckBoxLevelator.Enabled = false;
                    CheckBoxLevelator.Checked = false;
                }
            }
            else {
                CheckBoxLevelator.Enabled = false;
                CheckBoxLevelator.Checked = false;
                lblLevelator.Text = "";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            resetTimer();
            resetLabels();
            if (micDevices.Length > 0 && speakDevices.Length > 0)
            {
                selectedMicDevice = micDevices[micBox.SelectedIndex];
                selectedSpeakDevice = speakDevices[speakBox.SelectedIndex];

                recorder.startRecording(selectedMicDevice, selectedSpeakDevice);
                timer.Start();
                isRecording = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            recorder.stopRecording();
            timer.Stop();
            isRecording = false;
        }

        private void resetTimer() {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            hours = 0;
            minutes = 0;
            seconds = 0;
        }

        private void refreshDevices()
        {
            btnStart.Enabled = false;
            micBox.Items.Clear();
            speakBox.Items.Clear();

            micDevices = new MMDevice[0];
            speakDevices = new MMDevice[0];

            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDeviceCollection micCollection = enumerator.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active);
            if (micCollection.Count > 0)
            {
                micDevices = new MMDevice[micCollection.Count];
                int i = 0;
                foreach (MMDevice device in micCollection)
                {
                    micDevices[i] = device;
                    micBox.Items.Insert(i, device.FriendlyName);
                    i++;
                }
                selectedMicDevice = micDevices[0];
                micBox.SelectedIndex = 0;
            }


            enumerator = new MMDeviceEnumerator();
            MMDeviceCollection speakCollection = enumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active);
            if (speakCollection.Count > 0)
            {
                speakDevices = new MMDevice[speakCollection.Count];
                int i = 0;
                foreach (MMDevice device in speakCollection)
                {
                    speakDevices[i] = device;
                    speakBox.Items.Insert(i, device.FriendlyName);
                    i++;
                }
                selectedSpeakDevice = speakDevices[0];
                speakBox.SelectedIndex = 0;
            }

            if (micDevices.Length > 0 && speakDevices.Length > 0)
            {
                if (selectedMicDevice != null && selectedSpeakDevice != null)
                    btnStart.Enabled = true;
            }

        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            refreshDevices();
        }

        private void btnMix_Click(object sender, EventArgs e)
        {
            isMixing = true;
            lockForMixing();
            worker = new BackgroundWorker();
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundMixingDone);
            worker.DoWork += new DoWorkEventHandler(backgroundMixing);
            lf = new LoadingForm();
            lf.Show();
            worker.RunWorkerAsync();
        }

        private void backgroundMixingDone(object sender, RunWorkerCompletedEventArgs e)
        {
            lf.Close();
            lf.Dispose();
            worker.Dispose();
            lf = null;
            unlock();
            isMixing = false;
        }

        private void backgroundMixing(object sender, DoWorkEventArgs e)
        {
            bool success = recorder.mixAndConvert(CheckBoxLevelator.Checked, CheckBoxConvert.Checked);
        }

        public void lockForRecording() {
            micBox.Enabled = false;
            speakBox.Enabled = false;
            btnRefresh.Enabled = false;
            btnStart.Enabled = false;
            btnMix.Enabled = false;
            btnStop.Enabled = true;
            progressRecording.Style = ProgressBarStyle.Marquee;
        }

        public void lockForMixing() {
            Cursor.Current = Cursors.WaitCursor;
            micBox.Enabled = false;
            speakBox.Enabled = false;
            btnRefresh.Enabled = false;
            btnStart.Enabled = false;
            btnMix.Enabled = false;
            btnStop.Enabled = false;

        }

        public void unlock()
        {
            Cursor = Cursors.Default;
            micBox.Enabled = true;
            speakBox.Enabled = true;
            btnRefresh.Enabled = true;
            btnStart.Enabled = true;
            btnMix.Enabled = true;
            btnStop.Enabled = false;
            progressRecording.Style = ProgressBarStyle.Blocks;
            progressRecording.Value = 0;
        
        }

        public void setLabelMicText(string m) {
            lblRecording1.Text = "Microphone: " + m;
        }

        public void resetLabels() {
            lblRecording1.Text = "Microphone: ";
            lblRecording2.Text = "Speakers: ";
        }

        public void setLabelSpeakText(string s) {
            lblRecording2.Text = "Speakers: " + s;
        }

        private void open(string file) {
            if (File.Exists(file)) {
                Process.Start("explorer.exe", file);
            }
        }

        private void btnShowFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Directory.GetCurrentDirectory());
        }

        private void btnTestMicFile_Click(object sender, EventArgs e)
        {
            string f = recorder.getMicFile();
            open(f);
        }

        private void btnTestSpeakFile_Click(object sender, EventArgs e)
        {
            string f = recorder.getSpeakFile();
            open(f);
        }

        private void btnLocateLevelator_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            string path = "";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                var fn = fd.FileName;
                path = Path.GetFullPath(fn);
                if (path.Contains("levelator"))
                {
                    levelatorPath = path;
                    Properties.Settings.Default.LevelatorPath = path;
                    Properties.Settings.Default.Save();
                }
                else {
                    MessageBox.Show("Applications other than Levelator are not supported.", "Invalid application", MessageBoxButtons.OK);
                }
            }
            else {
                levelatorPath = "";
                Properties.Settings.Default.LevelatorPath = "";
                CheckBoxLevelator.Checked = false;
                CheckBoxLevelator.Enabled = false;
                Properties.Settings.Default.Save();
            }
            
            checkLevelatorStatus();
        }

        private void CheckBoxLevelator_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Levelate = CheckBoxLevelator.Checked;
            Properties.Settings.Default.Save();
        }

        private void CheckBoxConvert_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Convert = CheckBoxConvert.Checked;
            Properties.Settings.Default.Save();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isRecording && !isMixing)
            {
                Environment.Exit(Environment.ExitCode);
            }
            else {
                e.Cancel = true;
                if (isRecording) {
                    MessageBox.Show("Stop recording before closing the application.");
                }
                if (isMixing) {
                    MessageBox.Show("Wait for the application to finish mixing/leveling/converting.");
                }
            }
        }

        private void btnTestMixFile_Click(object sender, EventArgs e)
        {
            string f = recorder.getMixFileName();
            open(f);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds += 1;
            if (seconds == 60)
            {
                seconds = 0;
                minutes += 1;
                if (minutes >= 60)
                {
                    minutes = 0;
                    hours += 1;
                }
            }
            string time = hours.ToString() + ":";
            if (minutes >= 10)
            {
                time += minutes.ToString() + ":";
            }
            else
            {
                time += "0" + minutes.ToString() + ":";
            }
            if (seconds >= 10)
            {
                time += seconds.ToString();
            }
            else
            {
                time += "0" + seconds.ToString();
            }

            lblTime.Text = time;
        }
    }
}