using Machine.Specifications;
using YearToTorahVerse.Framework.Hebrew;

namespace YearToTorahVerse.Tests.FrameworkTests
{
    public class When_changing_an_int_to_a_hebrew_number
    {
        protected static HebrewNumberConverter converter;
        protected static string result;

        Establish context = () =>
        {
            converter = new HebrewNumberConverter();
        };

        Because of = () =>
        {
            result = converter.IntToHebrewNumber(770);
        };

        It should_be_the_correct_hebrew_number = () => result.ShouldEqual("תשע");
    }
}