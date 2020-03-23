using System;
using System.Collections.Generic;
using System.Text;

namespace DateParser.Interface
{
    public interface IDateParserService
    {
        bool CheckCountOfArguments(int argsCount, out string result);
        string GetDateRange(string startDate, string endDate);
    }
}
