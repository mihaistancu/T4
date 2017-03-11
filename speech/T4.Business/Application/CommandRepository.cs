using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using T4.Business.Models.Commands;
using T4.Business.Models.Interfaces;

namespace T4.Business.Application
{
    public class CommandRepository
    {
        private readonly IList<ICustomCommand> _savedCommands;

        public CommandRepository()
        {
            _savedCommands = new List<ICustomCommand>();
        }
        public bool HasCustomCommand(string text)
        {
            return _savedCommands.Any(i=>i.GetText() == text);
        }
        public ICustomCommand GetCustomCommand(string text)
        {
            return _savedCommands.FirstOrDefault(i => i.GetText() == text);
        }

        public void SaveCustomCommand(string text, IList<ICoreCommand> coreCommands, string intent)
        {
            _savedCommands.Add(new CustomCommand(text, coreCommands,intent));
        }
    }
}
