using System.Collections.Generic;

namespace T4.Console
{
    public interface ICoreCommand
    {
        IEnumerable<string> Execute();
    }
}
