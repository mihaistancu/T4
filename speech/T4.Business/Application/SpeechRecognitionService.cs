using System;

namespace T4.Business.Application
{
    public static class SpeechRecognitionService
    {
        public static string Listen()
        {

            var result = GoogleCloudSamples.Recognize.StreamingMicRecognizeAsync().Result;
            Console.WriteLine("Input: " + result);
            return result;
        }
    }
}
