using System.Collections.Generic;
using FizzBuzz.Models;
using FizzBuzz.Services.FizzBuzz;
using FizzBuzz.Services.Rules;
using Moq;
using NUnit.Framework;

namespace FizzBuzz.Test.Unit.Services.FizzBuzzServiceTests
{
    [TestFixture]
    public class When_calculating_FizzBuzz
    {
        private const int Min = 1;
        private const int Max = 5;
        private Mock<IRule> _ruleMock;
        private Mock<IRule> _rule2Mock;
        private const string NoMatchingRuleString = "noMatchingRuleString";
        private FizzBuzzService _fizzBuzzService;

        [SetUp]
        public void SetUp()
        {
            _ruleMock = new Mock<IRule>();
            _rule2Mock = new Mock<IRule>();
            _fizzBuzzService = new FizzBuzzService(new[]{_ruleMock.Object, _rule2Mock.Object}, NoMatchingRuleString);
        }

        [Test]
        public void with_no_matching_rules()
        {
            FizzBuzzResponse result = _fizzBuzzService.CalculateFizzBuzz(Min, Max);

            var expected = new FizzBuzzResponse
            {
                Result = "1 2 3 4 5",
                Summary = new Dictionary<string, string>{{NoMatchingRuleString , "5"}}
            };

            AssertFizzBuzzResponse(result, expected);
        }

        [Test]
        public void with_rule_for_1()
        {
            const string output = "rule1";
            _ruleMock.Setup(m => m.ApplyRule(1)).Returns(output);

            FizzBuzzResponse result = _fizzBuzzService.CalculateFizzBuzz(Min, Max);

            var expected = new FizzBuzzResponse
            {
                Result = $"{output} 2 3 4 5",
                Summary = new Dictionary<string, string> { {output, "1"},{ NoMatchingRuleString, "4" } }
            };

            AssertFizzBuzzResponse(result, expected);
        }

        [Test]
        public void with_rule_for_2_3_4()
        {
            const string output2 = "rule2";
            const string output3 = "rule3";
            const string output4 = "rule4";
            _ruleMock.Setup(m => m.ApplyRule(2)).Returns(output2);
            _ruleMock.Setup(m => m.ApplyRule(3)).Returns(output3);
            _ruleMock.Setup(m => m.ApplyRule(4)).Returns(output4);

            FizzBuzzResponse result = _fizzBuzzService.CalculateFizzBuzz(Min, Max);

            var expected = new FizzBuzzResponse
            {
                Result = $"1 {output2} {output3} {output4} 5",
                Summary = new Dictionary<string, string> { { NoMatchingRuleString, "2" }, { output2, "1" }, { output3, "1" }, { output4, "1" } }
            };

            AssertFizzBuzzResponse(result, expected);
        }

        [Test]
        public void with_2_rules_matching_1_run_in_correct_order()
        {
            const string output1 = "rule1";
            const string output1a = "rule1a";

            _ruleMock.Setup(m => m.Order).Returns(2);
            _ruleMock.Setup(m => m.ApplyRule(1)).Returns(output1);

            _rule2Mock.Setup(m => m.Order).Returns(1);
            _rule2Mock.Setup(m => m.ApplyRule(1)).Returns(output1a);

            FizzBuzzResponse result = _fizzBuzzService.CalculateFizzBuzz(Min, Max);

            var expected = new FizzBuzzResponse
            {
                Result = $"{output1a}{output1} 2 3 4 5",
                Summary = new Dictionary<string, string> {{ $"{output1a}{output1}", "1" }, { NoMatchingRuleString, "4" } }
            };

            AssertFizzBuzzResponse(result, expected);
        }

        private void AssertFizzBuzzResponse(FizzBuzzResponse result, FizzBuzzResponse expected)
        {
            Assert.That(result.Result, Is.EqualTo(expected.Result));
            Assert.That(result.Summary, Is.EqualTo(expected.Summary));
        }
    }
}
