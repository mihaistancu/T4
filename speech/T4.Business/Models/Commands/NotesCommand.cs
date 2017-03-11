using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using T4.Business.Application;
using T4.Business.Constants;
using T4.Business.Models.Interfaces;

namespace T4.Business.Models.Commands
{
    public class NotesCommand : ICoreCommand
    {
        private string _label;
        private string _text;
        public void SetParameters(IList<string> parameters)
        {
            _text = string.IsNullOrEmpty(_text) ? parameters.ElementAtOrDefault(0) : _text;
            _label = string.IsNullOrEmpty(_label) ? parameters.ElementAtOrDefault(1) : _label;
        }

        public void Validate(IList<string> parameters, bool isLearning)
        {
            if (string.IsNullOrEmpty(_text) && !isLearning)
            {
                SpeechSynthesisService.Speak("Please tell me what should I write down.");
                _text = SpeechRecognitionService.Listen();
            }
            if (string.IsNullOrEmpty(_label))
            {
                SpeechSynthesisService.Speak("Please tell me where you want me to save these notes.");
                _label = SpeechRecognitionService.Listen();
            }
        }

        public IList<string> Execute(IList<string> parameters)
        {
            SetParameters(parameters);
            Validate(parameters,false);
            SaveTo(_label, _text);
            _text = string.Empty;
            return new List<string>();
        }
        private void SaveTo(string label,string input)
        {
            var path = string.Format(@"D:\{0}.txt", label);

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(input);
            }
        }
    }
}