using NUnit.Framework;

namespace FizzBuzz.Test.Unit.Services.RuleTests
{
    [TestFixture]
    public class When_applying_a_Rule
    {
        private static int[] _matchingRule = {-2, 0, 2};
        private static int[] _notMatchingRule = { -1, 1 };
        private TestRule _testRule;

        [SetUp]
        public void SetUp()
        {
            _testRule = new TestRule();
        }

        [TestCaseSource(nameof(_matchingRule))]
        public void the_interger_matches_the_rule_I_expect_Output(int value)
        {
            Assert.That(_testRule.ApplyRule(value), Is.EqualTo(_testRule.Output));
        }

        [TestCaseSource(nameof(_notMatchingRule))]
        public void the_interger_does_not_match_the_rule_I_expect_null(int value)
        {
            Assert.That(_testRule.ApplyRule(value), Is.Null);
        }
    }
}
