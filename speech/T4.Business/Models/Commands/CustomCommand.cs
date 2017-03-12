using System;
using System.Collections.Generic;
using System.Linq;
using T4.Business.Application;
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
            return _intent;
        }

        public void Execute()
        {
            IList<string> response = new List<string>();
            foreach (var item in GetSubCommands())
            {
                response = item.Execute(response);
                Console.WriteLine(response.FirstOrDefault());
            }
            SpeechSynthesisService.Speak("done");
        }
    }
}
