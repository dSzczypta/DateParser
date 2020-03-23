using DateParser.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateParser.Services
{
    public class DateParserService : IDateParserService
    {
        public bool CheckCountOfArguments(int argsCount, out string result)
        {
            if (argsCount > 2)
            {
                result = "Too many arguments for this function";
                return false;
            }
            else if (argsCount < 2)
            {
                result = "Too few arguments for this function";
                return false;
            }
            result = "";
            return true;
        }

        public string GetDateRange(string startDate, string endDate)
        {
            if (!DateTime.TryParse(startDate, out DateTime parsedStartDate) || !DateTime.TryParse(endDate, out DateTime parsedEndDate))
                return "Invalid date format";
            else if (parsedEndDate < parsedStartDate)
                return "End date cannot be less than start date";

            return CalculateDate(parsedStartDate, parsedEndDate);
        }

        private string CalculateDate(DateTime parsedStartDate, DateTime parsedEndDate)
        {
            throw new NotImplementedException();
        }
    }
}
