using DateParser.Interface;
using DateParser.Services;
using System;

namespace DateParser
{
    class Program
    {
        static void Main(string[] args)
        {
            IDateParserService dateParserService = new DateParserService();
            if (dateParserService.CheckCountOfArguments(args.Length, out string result))
                result = dateParserService.GetDateRange(args[0], args[1]);
            Console.WriteLine(result);
        }
    }
}
