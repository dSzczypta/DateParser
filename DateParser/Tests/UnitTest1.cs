using DateParser.Interface;
using DateParser.Services;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private IDateParserService dateParserService;

        [SetUp]
        public void Setup()
        {
            dateParserService = new DateParserService();
        }

        [Test]
        public void CheckCountOfArgumentsToManyArgs()
        {
            Assert.IsFalse(dateParserService.CheckCountOfArguments(3, out _));
        }

        [Test]
        public void CheckCountOfArgumentsToFewArgs()
        {
            Assert.IsFalse(dateParserService.CheckCountOfArguments(1, out _));
        }

        [Test]
        public void CheckCountOfArgumentsOk()
        {
            Assert.IsTrue(dateParserService.CheckCountOfArguments(2, out _));
        }

        [Test]
        public void GetRangeInvalidFormatDate()
        {
            var result = dateParserService.GetDateRange("20.20.2019", "25.02.2020");
            Assert.AreEqual(result, "Invalid date format");
        }

        [Test]
        public void GetRangeMissingDate()
        {
            var result = dateParserService.GetDateRange("", "");
            Assert.AreEqual(result, "Invalid date format");
        }

        [Test]
        public void GetRangeEndDateLessThanStartDate()
        {
            var result = dateParserService.GetDateRange("12.02.2015", "12.02.2014");
            Assert.AreEqual(result, "End date cannot be less than start date");
        }

        [Test]
        public void GetRangeSameDate()
        {
            var result = dateParserService.GetDateRange("12.02.2015", "12.02.2015");
            Assert.AreEqual(result, "12 - 12.02.2015");
        }

        [Test]
        public void GetRangeSameMonth()
        {
            var result = dateParserService.GetDateRange("12.02.2015", "13.02.2015");
            Assert.AreEqual(result, "12 - 13.02.2015");
        }

        [Test]
        public void GetRangeSameYear()
        {
            var result = dateParserService.GetDateRange("12.02.2015", "13.03.2015");
            Assert.AreEqual(result, "12.02 - 13.03.2015");
        }

        [Test]
        public void GetRangeDifferentDate()
        {
            var result = dateParserService.GetDateRange("12.02.2015", "13.03.2016");
            Assert.AreEqual(result, "12.02.2015 - 13.03.2016");
        }

        [Test]
        public void GetRangeOfDifferentDateFormat()
        {
            var result = dateParserService.GetDateRange("12.02.15", "13.03.16");
            Assert.AreEqual(result, "12.02.2015 - 13.03.2016");
        }

        [Test]
        public void GetRangeOfDifferentDateSeparation()
        {
            var result = dateParserService.GetDateRange("12.02.15", "13.03.16");
            Assert.AreEqual(result, "12.02.2015 - 13.03.2016");
        }

    }
}