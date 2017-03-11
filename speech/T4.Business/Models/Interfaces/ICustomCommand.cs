using System.Collections.Generic;

namespace T4.Business.Models.Interfaces
{
    public interface ICustomCommand
    {
        string GetText();
        IList<ICoreCommand> GetSubCommands();

        string GetIntent();
    }
}