using System.Collections.Generic;
using System.Linq;
using log4net;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ReportPortal.Addins.SpecFlowPlugin.Sample
{
    [Binding]
    public sealed class StepDefinitions
    {
        private readonly ILog Log = LogManager.GetLogger("steps");
        private List<int> numbers = new List<int>();

        [Given("I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            Log.InfoFormat("Entering {0}.", number);

            numbers.Add(number);
        }

        [When("I press add")]
        public void WhenIPressAdd()
        {
            Log.Warn("Pressing Add.");

            var sum = numbers.Sum(n => n);

            numbers.Clear();
            numbers.Add(sum);
        }

        [Then("the result should be (.*) on the screen")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.AreEqual(result, numbers.Last());
        }
    }
}

