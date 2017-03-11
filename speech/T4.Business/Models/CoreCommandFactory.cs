using System;
using T4.Business.Models.Commands;
using T4.Business.Models.Interfaces;

namespace T4.Business.Models
{
    public class CoreCommandFactory : ICoreCommandFactory
    {
        public ICoreCommand Create(string intent)
        {
            switch (intent)
            {
                case "translation":
                {
                    return new TranslateCommand();
                }
                case "note":
                {
                    return new NotesCommand();
                }
                default: throw new NotImplementedException();
            }
            
        }
    }
}