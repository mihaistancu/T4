using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace T4.Business.Models.Interfaces
{
    public interface ICoreCommand
    {
        void SetParameters(IList<string> parameters);
        void Validate(IList<string> parameters);
        IList<string> Execute(IList<string> parameters);
    }
}