using Machine.Specifications;
using YearToTorahVerse.Framework.Hebrew;

namespace YearToTorahVerse.Tests.FrameworkTests
{
    public class When_providing_valid_hebrew_number
    {
        protected static IHebrewNumberConverter converter;
        protected static bool result;

        Establish context = () =>
            {
                converter = new HebrewNumberConverter();
            };

        Because of = () =>
            {
                result = converter.IsValidHebrewNumber("à");
            };

        It should_be_true = () => result.ShouldBeTrue();
    }

    public class When_providing_invalid_hebrew_number
    {
        protected static IHebrewNumberConverter converter;
        protected static bool result;

        Establish context = () =>
        {
            converter = new HebrewNumberConverter();
        };

        Because of = () =>
        {
            result = converter.IsValidHebrewNumber("fdasfà");
        };

        It should_be_false = () => result.ShouldBeFalse();
    }
}