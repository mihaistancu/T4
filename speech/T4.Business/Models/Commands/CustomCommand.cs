using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4.Business.Models.Interfaces;

namespace T4.Business.Models.Commands
{
    public class CustomCommand : ICustomCommand
    {
        private readonly string _text;
        private readonly IList<ICoreCommand> _subCommands;
        private readonly string _intent;

        public CustomCommand(string text, IList<ICoreCommand> subCommands, string intent)
        {
            _text = text;
            _subCommands = subCommands;
            _intent = intent;
        }

        public string GetText()
        {
            return _text;
        }

        public IList<ICoreCommand> GetSubCommands()
        {
            return _subCommands;
        }


       

        public string GetIntent()
        {
            IList<string> response = new List<string>();
            foreach (var item in GetSubCommands())
            {

                response = item.Execute(response);


            }
            return _intent;
        }
    }
}
