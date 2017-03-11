using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T4.Business.Application;
using T4.Business.Models.Interfaces;

namespace T4.Business.Models.Commands
{
    public class TranslateCommand : ICoreCommand
    {
        private string _targetLanguage = "";
        private string _text = "";
        public void SetParameters(IList<string> parameters)
        {
            _targetLanguage = parameters.ElementAt(0);
            _text = parameters.ElementAt(1);
        }

        public void Validate(IList<string> parameters)
        {

        }

        public async Task<IList<string>> Execute(IList<string> parameters)
        {
            var result = new List<string>();
            Validate(parameters);
            SetParameters(parameters);
            var translatedWord = GoogleTranslateService.Translate(_text, _targetLanguage);
            result.Add(translatedWord);
            return result;
        }
    }
}