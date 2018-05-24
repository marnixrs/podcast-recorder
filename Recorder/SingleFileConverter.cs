using System.IO;
using NAudio.Wave;
using NAudio.MediaFoundation;

namespace Recorder
{
    class SingleFileConverter
    {
        private string infile, outfile;

        public SingleFileConverter(string infile, string outfile) {
            this.infile = infile;
            this.outfile = outfile;
        }

        /// <summary>
        /// Converts a single wav file to a single mp3 file.
        /// </summary>
        public void startConvert()
        {
            if (File.Exists(infile))
            {
                WaveFileReader reader = new WaveFileReader(infile);
                MediaType mediaType = MediaFoundationEncoder.SelectMediaType(AudioSubtypes.MFAudioFormat_MP3, reader.WaveFormat, 256000);
                using (MediaFoundationEncoder encoder = new MediaFoundationEncoder(mediaType))
                {
                    encoder.Encode(outfile, reader);
                }
                reader.Close();
                reader.Dispose();
            }
        }
    }
}
