using FizzBuzz.Test.Unit.Services.RuleTests.Rules;
using NUnit.Framework;

namespace FizzBuzz.Test.Unit.Services.RuleTests
{
    [TestFixture]
    public class When_applying_a_Rule
    {
        private TestRule1 _testRule1;
        private TestRuleNeg1 _testRuleNeg1;
        private TestRule0 _testRule0;
        static int[] TestValues = {int.MinValue, int.MaxValue, 0};

        [SetUp]
        public void SetUp()
        {
            _testRule1 = new TestRule1();
            _testRuleNeg1 = new TestRuleNeg1();
            _testRule0 = new TestRule0();
        }

        [Test]
        public void foo()
        {
            //_testRule1.ApplyRule()
        }
    }
}
