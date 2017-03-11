using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4.Business.Constants
{
    public static class Languages
    {
        public static string GetLanguage(string input)
        {
            switch (input.ToLower())
            {
                case "german":
                    return "de";
                case "spanish":
                    return "es";
                case "romanian":
                    return "ro";
                default:
                    return "en";
            }
        }
    }
}
