using System.Collections.Generic;
using System.Linq;
using T4.Business.Application;
using T4.Business.Constants;
using T4.Business.Models.Interfaces;

namespace T4.Business.Models.Commands
{
    public class TranslateCommand : ICoreCommand
    {
        private string _sourceLanguage = "";
        private string _text = "";
        public void SetParameters(IList<string> parameters)
        {
            _sourceLanguage = parameters.ElementAtOrDefault(0);
            _text = parameters.ElementAtOrDefault(1);
        }

        public void Validate(IList<string> parameters)
        {
            if (_sourceLanguage == null)
            {
                SpeechSynthesisService.Speak("From what language do you want me to translate");
                var lang = SpeechRecognitionService.Listen();
                _sourceLanguage = Languages.GetLanguage(lang);
            }
            if (_text == null)
            {
                SpeechSynthesisService.Speak("What do you want me to translate");
                _text = SpeechRecognitionService.Listen();
            }
        }

        public IList<string> Execute(IList<string> parameters)
        {
            var result = new List<string>();
            SetParameters(parameters);
            Validate(parameters);
            var translatedWord = GoogleTranslateService.Translate(_text, _sourceLanguage);
            result.Add(translatedWord);
            return result;
        }
    }
}