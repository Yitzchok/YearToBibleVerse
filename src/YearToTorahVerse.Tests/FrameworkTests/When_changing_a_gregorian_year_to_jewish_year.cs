using System;
using System.Globalization;
using Machine.Specifications;

namespace YearToTorahVerse.Tests.FrameworkTests
{
    public class When_changing_a_gregorian_year_to_jewish_year
    {
        protected static HebrewCalendar calendar;
        protected static int resultYear;

        Establish context = () =>
            {
                calendar = new HebrewCalendar();
            };

        Because of = () =>
            {
                resultYear = calendar.GetYear(new DateTime(2009, 12, 14));
            };

        It should_be_the_correct_jewish_year = () => resultYear.ShouldEqual(5770);
    }
}