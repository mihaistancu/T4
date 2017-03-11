namespace T4.Business.Application
{
    public static class SpeechRecognitionService
    {
        public static string Listen()
        {
            return GoogleCloudSamples.Recognize.StreamingMicRecognizeAsync().Result;
        }
    }
}
