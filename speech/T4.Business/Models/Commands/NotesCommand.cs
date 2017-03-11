using System.Collections.Generic;
using System.Threading.Tasks;
using T4.Business.Models.Interfaces;

namespace T4.Business.Models.Commands
{
    public class NotesCommand : ICoreCommand
    {
        public void SetParameters(IList<string> parameters)
        {
            throw new System.NotImplementedException();
        }

        public void Validate(IList<string> parameters)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<string>> Execute(IList<string> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}