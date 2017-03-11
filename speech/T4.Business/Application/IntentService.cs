using Microsoft.Cognitive.LUIS;

namespace T4.Business.Application
{
    public static class IntentService
    {
        public static LuisResult GetIntent(string text)
        {
            var client = new LuisClient("7c263174-cc8c-4107-a4de-55b1e9aa8bce", "0888ecfdb8404a7ab998888aeeb6f8ec");
            return client.Predict(text).Result;
        }
    }
}
