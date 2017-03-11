using System.Collections.Generic;
using T4.Business.Models.Interfaces;

namespace T4.Business.Models.Commands
{
    public class NotesCommand : ICoreCommand
    {
        public void Validate(IList<string> parameters)
        {
            throw new System.NotImplementedException();
        }

        public IList<string> Execute(IList<string> parameters)
        {
            Validate(parameters);
            throw new System.NotImplementedException();
        }
    }
}