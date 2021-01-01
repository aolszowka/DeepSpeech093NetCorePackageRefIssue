using NAudio.Wave;

using System;

namespace PackageRefIssue
{
    class Program
    {
        private const string DEEPSPEECH_MODEL = "deepspeech-0.9.3-models.pbmm";
        private const string DEEPSPEECH_SCORER = "deepspeech-0.9.3-models.scorer";

        static void Main(string[] args)
        {
            using (IDeepSpeech sttClient = new DeepSpeech(DEEPSPEECH_MODEL))
            {
                sttClient.EnableExternalScorer(DEEPSPEECH_SCORER);

                string AudioFilePath = @"audio\2830-3980-0043.wav";

                WaveBuffer waveBuffer = new WaveBuffer(File.ReadAllBytes(AudioFilePath));
                string speechResult = sttClient.SpeechToText(
                    waveBuffer.ShortBuffer,
                    Convert.ToUInt32(waveBuffer.MaxSize / 2));

                Console.WriteLine(speechResult);

                waveBuffer.Clear();
            }
        }
    }
}
