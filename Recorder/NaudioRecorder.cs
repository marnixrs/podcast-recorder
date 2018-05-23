using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Codecs;
using NAudio.CoreAudioApi;
using NAudio.MediaFoundation;
using NAudio.Mixer;
using NAudio.Wave;
using NAudio.FileFormats.Mp3;
using System.Windows.Forms;

namespace Recorder
{
    class NaudioRecorder
    {
        private WasapiCapture micCapture;
        private WasapiLoopbackCapture speakCapture;
        private WasapiOut soundOut;

        private WaveFileWriter micWriter, speakWriter;

        private string micFileName, speakFileName, mixFileName, levelFileName;
        private string convertedMicFileName, convertedSpeakFileName, convertedMixFileName, convertedLevelFileName;

        private MainWindow window;

        public NaudioRecorder(MainWindow window) {
            this.window = window;
        }

        private void playSilence() {
            soundOut = new WasapiOut();
            WaveFileReader reader = new WaveFileReader("silence.wav");
            LoopStream stream = new LoopStream(reader);
            soundOut.Init(stream);
            soundOut.Play();
        }


        public void startRecording(MMDevice micDevice, MMDevice speakDevice) {
            window.lockForRecording();

            playSilence();

            makeFileNames();
            micCapture = new WasapiCapture(micDevice);
            speakCapture = new WasapiLoopbackCapture(speakDevice);

            micWriter = new WaveFileWriter(micFileName, micCapture.WaveFormat);
            speakWriter = new WaveFileWriter(speakFileName, speakCapture.WaveFormat);
       
            micCapture.DataAvailable += (s, e) => {
                
                micWriter.Write(e.Buffer, 0, e.BytesRecorded);
            };

            speakCapture.DataAvailable += (s, e) => {
                speakWriter.Write(e.Buffer, 0, e.BytesRecorded);
            };

            micCapture.StartRecording();
            speakCapture.StartRecording();
        }

        public void stopRecording() {
            micCapture.StopRecording();
            speakCapture.StopRecording();
            micWriter.Close();
            micWriter.Dispose();
            speakWriter.Close();
            speakWriter.Dispose();
            soundOut.Stop();
            soundOut.Dispose();
            window.unlock();
        }

        public void startMix() {
            Mixer mixer = new Mixer(micFileName, speakFileName, mixFileName, window);
            mixer.mix();
            mixer = null;
        }

        private void makeFileNames() {
            string parse = "yyyy-MM-dd hhmmss";
            micFileName = "Podcast " + DateTime.Now.ToString(parse) + " mic.wav";
            speakFileName = "Podcast " + DateTime.Now.ToString(parse) + " speak.wav";
            mixFileName = "Podcast " + DateTime.Now.ToString(parse) + " mix.wav";
            levelFileName = "Podcast " + DateTime.Now.ToString(parse) + " mix.output.wav";

            convertedMicFileName = "Podcast " + DateTime.Now.ToString(parse) + " mic.mp3";
            convertedSpeakFileName = "Podcast " + DateTime.Now.ToString(parse) + " speak.mp3";
            convertedMixFileName = "Podcast " + DateTime.Now.ToString(parse) + " mix.mp3";
            convertedLevelFileName = "Podcast " + DateTime.Now.ToString(parse) + " mix.output.mp3";
        }

        public string[] getFileNames() {
            string[] names = {micFileName, speakFileName, mixFileName, levelFileName};
            return names;
        }

        public string[] getConvertNames() {
            string[] names = { convertedMicFileName, convertedSpeakFileName, convertedMixFileName, convertedLevelFileName };
            return names;
        }
    }
}
