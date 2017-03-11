using System;

namespace T4.Business.Application
{
    public static class SpeechRecognitionService
    {
        public static string Listen(string languageCode = "en-US")
        {

            var result = GoogleCloudSamples.Recognize.StreamingMicRecognizeAsync(languageCode).Result;
            Console.WriteLine("Input: " + result);
            return result;
        }
    }
}
