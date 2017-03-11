using System.Collections.Generic;
using System.IO;

namespace T4.Console
{
    public class TakeNotesCommand : ICoreCommand
    {
        private readonly ISpeech speech;
        private string input;
        public string Output { get; private set; }

        public TakeNotesCommand(ISpeech speech)
        {
            this.speech = speech;
        }

        public TakeNotesCommand(ISpeech speech, string input)
        {
            this.speech = speech;
            this.input = input;
        }

        public IEnumerable<string> Execute()
        {
            Save();

            return new List<string> { input };
        }

        private void Save()
        {
            while (string.IsNullOrEmpty(input))
            {
                input = GetInput();
            }

            SaveTo(GetLabel());

        }

        private string GetInput()
        {
            speech.FromText("Please tell me what should I write down.");
            return speech.ToText();
        }

        private string GetLabel()
        {
            speech.FromText("Please tell me where you want me to save these notes.");
            return speech.ToText();
        }

        private void SaveTo(string label)
        {
            string path = string.Format(@"D:\{0}.txt", label);

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(input);
            }

            Output = path;
        }
    }
}
