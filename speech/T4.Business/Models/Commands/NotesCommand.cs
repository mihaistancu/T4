using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T4.Business.Models.Interfaces;

namespace T4.Business.Models.Commands
{
    public class NotesCommand : ICoreCommand
    {
        private string _label;
        private string _text;
        public void SetParameters(IList<string> parameters)
        {
            _label = parameters.ElementAtOrDefault(1);
            _text = parameters.ElementAtOrDefault(0);
        }

        public void Validate(IList<string> parameters)
        {
           
        }

        public IList<string> Execute(IList<string> parameters)
        {
            Validate(parameters);
            SetParameters(parameters);
            throw new System.NotImplementedException();
        }
    }
}