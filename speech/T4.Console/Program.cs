using T4.Business.Application;

namespace T4.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var translation = GoogleTranslateService.Translate("vegetable", "de");
            System.Console.WriteLine(translation);

            var intent = IntentService.GetIntent("schedule a meeting with Mary on Saturday");
            System.Console.WriteLine(intent.TopScoringIntent.Name);

            System.Console.ReadLine();

        }
    }
}
