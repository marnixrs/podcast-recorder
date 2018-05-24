using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Mixer;
using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System.IO;
using NAudio.MediaFoundation;

namespace Recorder
{
    class Mixer
    {
        private string file1;
        private string file2;
        private string mixfile;
        private MainWindow window;

        public Mixer(string file1, string file2, string mixfile, MainWindow window) {
            this.file1 = file1;
            this.file2 = file2;
            this.mixfile = mixfile;
            this.window = window;
            MediaFoundationApi.Startup();
        }

        /// <summary>
        /// Mixes two mp3 files to a single wav file.
        /// </summary>
        public void mixMp3() {
            Mp3FileReader reader1 = new Mp3FileReader(file1);
            Mp3FileReader reader2 = new Mp3FileReader(file2);
            int maxSampleRate = Math.Max(reader1.WaveFormat.SampleRate, reader2.WaveFormat.SampleRate);
            WaveFormat format = new WaveFormat(maxSampleRate, 1);
            MediaFoundationResampler resampler1 = new MediaFoundationResampler(reader1, format);
            var input1 = resampler1.ToSampleProvider();
            MediaFoundationResampler resampler2 = new MediaFoundationResampler(reader2, format);
            var input2 = resampler2.ToSampleProvider();

            ISampleProvider[] provider = { input1, input2 };
            MixingSampleProvider mixer = new MixingSampleProvider(provider);
            WaveFileWriter.CreateWaveFile16(mixfile, mixer);

            resampler1.Dispose();
            resampler2.Dispose();
            reader1.Close();
            reader1.Dispose();
            reader2.Close();
            reader2.Dispose();

        }

        /// <summary>
        /// Mixes two wav files to a single wav file. (Unused).
        /// </summary>
        public void mix() {
            window.lockForMixing();

            WaveFileReader reader1 = new WaveFileReader(file1);
            WaveFileReader reader2 = new WaveFileReader(file2);

            int maxSampleRate = Math.Max(reader1.WaveFormat.SampleRate, reader2.WaveFormat.SampleRate);
            WaveFormat format = new WaveFormat(maxSampleRate, 1);

            MediaFoundationResampler resampler1 = new MediaFoundationResampler(reader1, format);
            var input1 = resampler1.ToSampleProvider();
            MediaFoundationResampler resampler2 = new MediaFoundationResampler(reader2, format);
            var input2 = resampler2.ToSampleProvider();

            ISampleProvider[] provider = { input1, input2 };

            MixingSampleProvider mixer = new MixingSampleProvider(provider);

            WaveFileWriter.CreateWaveFile16(mixfile, mixer);

            resampler1.Dispose();
            resampler2.Dispose();
            reader1.Close();
            reader2.Close();
            reader1.Dispose();
            reader2.Dispose();
            
            window.unlock();
            
        }
    }
}
