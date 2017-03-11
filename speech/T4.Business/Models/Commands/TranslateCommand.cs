using System.Collections.Generic;
using T4.Business.Models.Interfaces;

namespace T4.Business.Models.Commands
{
    public class TranslateCommand : ICoreCommand
    {
        public void Validate(IList<string> parameters)
        {
            throw new System.NotImplementedException();
        }

        public IList<string> Execute(IList<string> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}