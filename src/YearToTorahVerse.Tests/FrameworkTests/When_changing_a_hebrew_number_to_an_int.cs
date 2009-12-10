using System;
using Machine.Specifications;
using YearToTorahVerse.Framework.Hebrew;

namespace YearToTorahVerse.Tests.FrameworkTests
{
    [Subject("converting hebrew number to int")]
    public class When_changing_a_hebrew_number_to_an_int
    {
        protected static HebrewNumberConverter converter;
        protected static int result;

        Establish context = () =>
            {
                converter = new HebrewNumberConverter();
            };

        Because of = () =>
            {
                result = converter.HebrewNumberToInt("תשע");
            };

        It should_be_the_correct_resutl = () =>
            {
                result.ShouldEqual(770);
            };
    }

}