using System.Collections;
using System.Collections.Generic;

namespace T4.Business.Models.Interfaces
{
    public interface ICoreCommand
    {
        void Validate(IList<string> parameters);
        IList<string> Execute(IList<string> parameters);
    }
}