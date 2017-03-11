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
            _label = parameters.ElementAt(0);
            _text = parameters.ElementAt(1);
        }

        public void Validate(IList<string> parameters)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<string>> Execute(IList<string> parameters)
        {
            Validate(parameters);
            SetParameters(parameters);
            throw new System.NotImplementedException();
        }
    }
}