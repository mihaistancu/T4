using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.Translate.v2;
using Google.Apis.Translate.v2.Data;

namespace T4.Business.Application
{
    public static class GoogleTranslateService
    {
        public static string Translate(string text, string targetLanguage)
        {
            var key = GetApiKey();
            var service = new TranslateService(new BaseClientService.Initializer
            {
                ApiKey = key
            });
            var srcText = new[] { text };
            var request = service.Translations.List(srcText, targetLanguage);
            var response = request.Execute();
            var translations = response.Translations.Select(translation => translation.TranslatedText).ToList();
            var output = translations.FirstOrDefault();
            return output ?? "";
        }

        private static string GetApiKey()
        {
            return "AIzaSyAVZGwlNg_J-SBqxNgg7v_Pk0RnmNPh3GE";
        }
    }
}
