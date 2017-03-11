using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using T4.Business.Models.Interfaces;

namespace T4.Business.Application
{
    public class CommandRepository
    {
        private IList<ICustomCommand> _savedCommands { get; set; }

        public bool HasCommand(string text)
        {
       
            return _savedCommands.Any(i=>i.GetIntent() == text);
        }
        public ICustomCommand GetCommand(string text)
        {
            return _savedCommands.FirstOrDefault(i => i.GetText() == text);
        }
    }
}
