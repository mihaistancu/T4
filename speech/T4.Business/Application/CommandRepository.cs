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
            var intent = IntentService.GetIntent(text).TopScoringIntent.Name;
            return _savedCommands.Any(i=>i.GetIntent() == intent);
        }
        public ICustomCommand GetCustomCommand(string text)
        {
            var intent = IntentService.GetIntent(text).TopScoringIntent.Name;
            return _savedCommands.FirstOrDefault(i => i.GetIntent() == intent);
        }

        public void SaveCustomCommand(string text, IList<ICoreCommand> coreCommands, string intent)
        {
            _savedCommands.Add(new CustomCommand(text, coreCommands,intent));
        }
    }
}
