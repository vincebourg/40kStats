using _40Stats.Core.Rolls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _40kStats.Test
{
    [TestClass]
    public class WoundRollTests
    {
        [TestMethod]
        public void four_when_five_needed_to_wound_is_miss()
        {
            WoundRoll roll = new WoundRoll(5, 4);
            Assert.IsTrue(roll.Missed);
            Assert.IsFalse(roll.Wounded);
        }

        [TestMethod]
        public void four_when_four_needed_to_wound_is_wounded()
        {
            WoundRoll roll = new WoundRoll(4, 4);
            Assert.IsTrue(roll.Wounded);
            Assert.IsFalse(roll.Missed);
        }

        [TestMethod]
        public void wound_roll_of_6_is_critical()
        {
            WoundRoll roll = new WoundRoll(6, 6);
            Assert.IsTrue(roll.IsCritical);
        }

        [TestMethod]
        public void wound_roll_of_5_is_not_critical()
        {
            WoundRoll roll = new WoundRoll(5, 5);
            Assert.IsFalse(roll.IsCritical);
        }
    }
}
