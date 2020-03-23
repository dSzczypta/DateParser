using DateParser.Interface;
using System;

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

            return CalculateDateRange(parsedStartDate, parsedEndDate);
        }

        private string CalculateDateRange(DateTime parsedStartDate, DateTime parsedEndDate)
        {
            if(parsedStartDate.Year != parsedEndDate.Year)
                return GenerateString(parsedStartDate.ToShortDateString(), parsedEndDate.ToShortDateString());
            else if(parsedStartDate.Month != parsedEndDate.Month)
                return GenerateString(parsedStartDate.ToString("dd.MM"), parsedEndDate.ToShortDateString());

            return GenerateString(parsedStartDate.ToString("dd"), parsedEndDate.ToShortDateString());
        }

        private string GenerateString(string startDate, string endDate) =>
            $"{startDate} - {endDate}";
    }
}
