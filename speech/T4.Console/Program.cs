using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using T4.Business.Application;

namespace T4.Console
{
    public class Program
    {
        private static ConcurrentQueue<string> notifications;

        public static void Main(string[] args)
        {
            //Translate();
            RunCommand();

            System.Console.ReadLine();          
        }

        private static void Translate()
        {
            var translation = GoogleTranslateService.Translate("vegetable", "de");
            System.Console.WriteLine(translation);

            var intent = IntentService.GetIntent("schedule a meeting with Mary on Saturday");
            System.Console.WriteLine(intent.TopScoringIntent.Name);
        }

        private static void RunCommand()
        {
            notifications = new ConcurrentQueue<string>();
            Task.Factory.StartNew(Consumer);

            var speechRecognition = new Speech(notifications);
            var takeNotes = new TakeNotesCommand(speechRecognition);
            takeNotes.Execute();
        }

        private static void Consumer()
        {
            while (true)
            {
                if (notifications.Count > 0)
                {
                    string notification;
                    if (notifications.TryDequeue(out notification))
                    {
                        System.Console.WriteLine(notification);
                    }

                }

                Thread.Sleep(500);
            }
        }

    }
}
