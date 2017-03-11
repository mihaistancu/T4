using System;
using System.Collections.Concurrent;
using System.Threading;

namespace T4.Console
{
    public class Speech : ISpeech
    {
        private readonly ConcurrentQueue<string> notifications;

        public Speech(ConcurrentQueue<string> notifications)
        {
            this.notifications = notifications;
        }

        public string ToText()
        {
            Thread.Sleep(500);

            string input = "bla" + new Random().Next(1, 10000);
            FromText("User returned: " + input);

            return input;
        }

        public void FromText(string message)
        {
            notifications.Enqueue(message);
            //play message
        }
    }
}
