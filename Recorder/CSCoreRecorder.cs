using System;
using System.Threading;
using CSCore.CoreAudioAPI;
using CSCore.SoundIn;
using CSCore.MediaFoundation;
using CSCore.SoundOut;
using CSCore.Streams;
using CSCore.Codecs;
using CSCore;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Recorder
{
    class CSCoreRecorder
    {
        private WasapiCapture micCapture;
        private WasapiLoopbackCapture speakCapture;
        private WasapiOut soundout;
        private SoundInSource micSource;
        private SoundInSource speakSource;
        private MediaFoundationEncoder micWriter;
        private MediaFoundationEncoder speakWriter;
        
        private string micFileName, speakFileName, mixFileName, levelFileName, convertedMixFileName, convertedLevelFileName;

        private MainWindow window;

        public CSCoreRecorder(MainWindow window) {
            this.window = window;
        }

        private void playSilence()
        {
            soundout = new WasapiOut();
            var source = CodecFactory.Instance.GetCodec("silence.wav");
            soundout.Initialize(source.Loop());
            soundout.Play();
        }

        public void startRecording(MMDevice micDevice, MMDevice speakDevice) {
            window.lockForRecording();
            playSilence();
            makeFileNames();

            micCapture = new WasapiCapture();
            micCapture.Device = micDevice;
            micCapture.Initialize();

            speakCapture = new WasapiLoopbackCapture();
            speakCapture.Device = speakDevice;
            speakCapture.Initialize();

            micSource = new SoundInSource(micCapture);

            micWriter = MediaFoundationEncoder.CreateMP3Encoder(micSource.WaveFormat, micFileName);
            byte[] micBuffer = new byte[micSource.WaveFormat.BytesPerSecond];
            micSource.DataAvailable += (s, e) =>
            {
                int read = micSource.Read(micBuffer, 0, micBuffer.Length);
                micWriter.Write(micBuffer, 0, read);
            };

            micCapture.Start();

            speakSource = new SoundInSource(speakCapture);
            speakWriter = MediaFoundationEncoder.CreateMP3Encoder(speakSource.WaveFormat, speakFileName);
            byte[] speakBuffer = new byte[speakSource.WaveFormat.BytesPerSecond];
            speakSource.DataAvailable += (s, e) =>
            {
                int read = speakSource.Read(speakBuffer, 0, speakBuffer.Length);
                speakWriter.Write(speakBuffer, 0, read);
            };

            speakCapture.Start();
        }

        public bool mixAndConvert(bool level, bool convert) {
            if (!micFileName.Equals(null) && !speakFileName.Equals(null))
            {
                Mixer mixer = new Mixer(micFileName, speakFileName, mixFileName, window);
                mixer.mixMp3();
                if (level) {
                    levelate(convert);
                }

                string s = "-1";
                if (File.Exists(mixFileName))
                {
                    FileInfo f = new FileInfo(mixFileName);
                    int size = (int)(f.Length / 1024 / 1024);
                    s = size.ToString();
                    return true;
                }
                else
                {
                    MessageBox.Show("No file with name\n   " + mixFileName + "\nexists.\n\nMixing was not succesful.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            return false;
        }

        public void levelate(bool convert) {
            // cmd>levelator.exe [path to wav file]
            ProcessStartInfo start = new ProcessStartInfo();
            string fullpath = Path.GetFullPath(mixFileName);
            if (fullpath.Contains(" ")) {
                fullpath = "\"" + fullpath + "\"";
            }
            start.Arguments = fullpath;
            start.FileName = Properties.Settings.Default.LevelatorPath;
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;
            int exitCode;

            using (Process proc = Process.Start(start))
            {
                proc.WaitForExit();
                exitCode = proc.ExitCode;
                proc.Close();
            }

            if (convert) {
                Converter con = new Converter();
                string[] wavfilenames = { mixFileName, levelFileName };
                string[] convertedfilenames = { convertedMixFileName, convertedLevelFileName };
                con.startConversion(wavfilenames, convertedfilenames, window);
            }
            
        }


        public void stopRecording() {
            micCapture.Stop();
            speakCapture.Stop();
            micWriter.Dispose();
            speakWriter.Dispose();
            micCapture.Dispose();
            speakCapture.Dispose();
            window.unlock();
            string size1 = "-1";
            string size2 = "-1";
            if (File.Exists(micFileName))
            {
                FileInfo f = new FileInfo(micFileName);
                int mbytes = (int)(f.Length / 1024 / 1024);
                size1 = mbytes.ToString();
            }
            else {
                MessageBox.Show("No file with name\n   " + micFileName+"\nexists.\n\nMicrophone may not have been recorded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (File.Exists(speakFileName)) {
                FileInfo f = new FileInfo(speakFileName);
                int mbytes = (int)(f.Length / 1024 / 1024);
                size2 = mbytes.ToString();
            }
            else {
                MessageBox.Show("No file with name\n   " + speakFileName + "\nexists.\n\nSpeakers may not have been recorded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            window.setLabelMicText(micFileName + "   -   " + size1 + "MB");
            window.setLabelSpeakText(speakFileName + "   -   " + size2 + "MB");
        }

        private void makeFileNames()
        {
            string parse = "yyyy-MM-dd_hhmmss";
            micFileName = "" + DateTime.Now.ToString(parse) + "_mic.mp3";
            speakFileName = "" + DateTime.Now.ToString(parse) + "_speak.mp3";
            mixFileName = "" + DateTime.Now.ToString(parse) + "_mix_wav.wav";
            levelFileName = "" + DateTime.Now.ToString(parse) + "_mix_wav.output.wav";

            convertedMixFileName = "" + DateTime.Now.ToString(parse) + "_mix_mp3.mp3";
            convertedLevelFileName = "" + DateTime.Now.ToString(parse) + "_mix_level_mp3.mp3";
        }

        public string getMixFileName() {
            return mixFileName;
        }

        public string getMicFile() {
            return micFileName;
        }

        public string getSpeakFile() {
            return speakFileName;
        }

        public string[] getFileNames()
        {
            string[] names = { micFileName, speakFileName, mixFileName, levelFileName };
            return names;
        }

        public string[] getConvertNames()
        {
            string[] names = {micFileName, speakFileName, convertedMixFileName, convertedLevelFileName };
            return names;
        }

    }
}
