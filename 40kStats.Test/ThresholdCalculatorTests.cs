using _40Stats.Core.Rolls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _40kStats.Test
{
    [TestClass]
    public class ThresholdCalculatorTests
    {
        [TestMethod]
        public void when_strenght_twice_or_more_than_endurance_2_needed()
        {
            WoundThresholdCalculator calculator = new();
            var result = calculator.GetThreshold(8, 4);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void when_strenght_more_than_endurance_3_needed()
        {
            WoundThresholdCalculator calculator = new();
            var result = calculator.GetThreshold(4, 3);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void when_strenght_equals_endurance_four_needed()
        {
            WoundThresholdCalculator calculator = new();
            var result = calculator.GetThreshold(4, 4);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void when_strenght_less_than_endurance_5_needed()
        {
            WoundThresholdCalculator calculator = new();
            var result = calculator.GetThreshold(4, 5);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void when_endurance_twice_or_more_than_strenght_6_needed()
        {
            WoundThresholdCalculator calculator = new();
            var result = calculator.GetThreshold(4, 8);
            Assert.AreEqual(6, result);
        }

        
    }

}
