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
            _text = string.IsNullOrEmpty(_text) ? parameters.ElementAtOrDefault(0) : _text;
            _sourceLanguage = string.IsNullOrEmpty(_sourceLanguage) ? parameters.ElementAtOrDefault(1) : _sourceLanguage;
        }

        public void Validate(IList<string> parameters, bool isLearning)
        {
            if (string.IsNullOrEmpty(_sourceLanguage))
            {
                SpeechSynthesisService.Speak("From what language do you want me to translate");
                var lang = SpeechRecognitionService.Listen();
                _sourceLanguage = Languages.GetLanguage(lang);
            }
            if (string.IsNullOrEmpty(_text) && !isLearning)
            {
                SpeechSynthesisService.Speak("What do you want me to translate");
                _text = SpeechRecognitionService.Listen(Languages.GetListenerLanguage(_sourceLanguage));
            }
        }

        public IList<string> Execute(IList<string> parameters)
        {
            var result = new List<string>();
            SetParameters(parameters);
            Validate(parameters,false);
            var translatedWord = GoogleTranslateService.Translate(_text, _sourceLanguage);
            result.Add(_text + " = " + translatedWord);
            _text = string.Empty;
            return result;
        }
    }
}