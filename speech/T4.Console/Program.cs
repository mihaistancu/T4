using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4.Business.Application;

namespace T4.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var result = GoogleTranslateService.Translate("vegetable", "de");
            System.Console.WriteLine(result);
            System.Console.ReadLine();
        }
    }
}
