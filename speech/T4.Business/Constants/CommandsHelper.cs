using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4.Business.Constants
{
    public static class CommandsHelper
    {
        public static IList<string> GetCoreCommandIntents()
        {
            return new List<string>()
                   {
                       "translation",
                       "note"
                   };
        }
    }
}
