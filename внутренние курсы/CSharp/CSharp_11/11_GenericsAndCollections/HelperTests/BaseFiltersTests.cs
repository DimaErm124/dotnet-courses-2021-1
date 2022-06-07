using Helper;
using NUnit.Framework;

namespace HelperTests
{
    public class BaseFiltersTests
    {

        [Test]
        [TestCase("one two tHree 3 three", ExpectedResult = "three")]
        [TestCase("", ExpectedResult = "")]
        public string TestGetgMostFrequentlyWord(string inputString)
        {
            return BaseFilters.GetgMostFrequentlyWord(inputString);
        }

        [Test]
        [TestCase("4351", ExpectedResult = true)]
        [TestCase("fdgfhgfh", ExpectedResult = false)]
        [TestCase("4444", ExpectedResult = false)]
        [TestCase("4441", ExpectedResult = false)]
        [TestCase("4411", ExpectedResult = true)]
        [TestCase("44113", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        public bool TestValidatingPinCode(string inputString)
        {
            return BaseFilters.ValidatingPinCode(inputString);
        }
    }
}