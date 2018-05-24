using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.MediaFoundation;


namespace Recorder
{
    class Converter
    {

        public Converter() {
            MediaFoundationApi.Startup();
        }

        /// <summary>
        /// Converts given files to mp3s.
        /// </summary>
        /// <param name="files"></param>
        /// <param name="outputNames"></param>
        /// <param name="window"></param>
        public void startConversion(string[] files, string[] outputNames, MainWindow window) {
            for (int i = 0; i < files.Length; i++) {
                if (File.Exists(files[i]))
                {
                    SingleFileConverter con = new SingleFileConverter(files[i], outputNames[i]);
                    con.startConvert();
                }
                else {
                    MessageBox.Show("No file with name\n   " + files[i] + "\nexists.\n\nThis file cannot be converted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            for (int i = 0; i < outputNames.Length; i++)
            {
                if (!File.Exists(outputNames[i]))
                {
                    MessageBox.Show("No file with name\n   " + outputNames[i] + "\nexists.\n\nConverting failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
