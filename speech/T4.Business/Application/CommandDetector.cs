using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4.Business.Models;
using T4.Business.Models.Commands;
using T4.Business.Models.Interfaces;

namespace T4.Business.Application
{
    public class CommandDetector
    {
        private readonly CommandRepository _commandRepository;
        public CommandDetector()
        {
            _commandRepository = new CommandRepository();
        }
        public void Detect()
        {
            var command = SpeechRecognitionService.Listen();
            var intent = IntentService.GetIntent(command);
            if (intent.TopScoringIntent.Name != "None" && intent.TopScoringIntent.Score > 0.7)
            {
                var factory = new CoreCommandFactory();
                var coreCommand = factory.Create(intent.TopScoringIntent.Name);
                var response = coreCommand.Execute(new List<string>());
                SpeechSynthesisService.Speak(response.ElementAtOrDefault(0));
                return;
            }
            ICustomCommand customCommand = SearchCommand(_commandRepository, command);
            if (customCommand == null)
            {
                CreateCustomCommand(command, _commandRepository);
            }
            else
            {
                customCommand.Execute();
            }

        }

        private static ICustomCommand SearchCommand(CommandRepository commandRepository, string command)
        {
            if (commandRepository.HasCustomCommand(command))
            {
                return commandRepository.GetCustomCommand(command);
            }
            return null;
        }

        private void CreateCustomCommand(string command, CommandRepository commandRepository)
        {
            SpeechSynthesisService.Speak("Teach me how to do it");
            IList<ICoreCommand> subCommands = new List<ICoreCommand>();
            var newCommand = SpeechRecognitionService.Listen();
            while (true)
            {
                var intent = IntentService.GetIntent(newCommand);
                if (intent.TopScoringIntent.Name != "None" && intent.TopScoringIntent.Score > 0.4)
                {
                    var factory = new CoreCommandFactory();
                    var coreCommand = factory.Create(intent.TopScoringIntent.Name);
                    coreCommand.Validate(new List<string>(), true);
                    subCommands.Add(coreCommand);
                }
                SpeechSynthesisService.Speak("Anything else");
                newCommand = SpeechRecognitionService.Listen();
                intent = IntentService.GetIntent(newCommand);
                if (intent.TopScoringIntent.Name == "no")
                {
                    break;
                }
                
            }
            commandRepository.SaveCustomCommand(command,subCommands,Guid.NewGuid().ToString());

        }
    }
}
