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
                case "french":
                    return "fr";
                case "japanese":
                    return "ja";
                default:
                    return "en";
            }
        }

        public static string GetListenerLanguage(string input)
        {
            switch (input.ToLower())
            {
                case "de":
                    return "de-DE";
                case "es":
                    return "es-ES";
                case "ro":
                    return "ro-RO";
                case "fr":
                    return "fr-FR";
                case "ja":
                    return "ja-JP";
                default:
                    return "en-US";
            }
        }
    }
}
