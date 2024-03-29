using _40Stats.Core.Rolls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _40kStats.Test
{
    [TestClass]
    public class SaveRollTests
    {
        [TestMethod]
        public void when_roll_5_and_save_6_miss()
        {
            SaveRoll roll = new(6, 5);
            Assert.IsTrue(roll.Missed);
            Assert.IsFalse(roll.Saved);
        }

        [TestMethod]
        public void when_roll_5_and_save_5_saved()
        {
            SaveRoll roll = new(5, 5);
            Assert.IsTrue(roll.Saved);
            Assert.IsFalse(roll.Missed);
        }

        [TestMethod]
        public void save_roll_of_1_always_miss()
        {
            SaveRoll roll = new(1, 1);
            Assert.IsTrue(roll.Missed);
            Assert.IsFalse(roll.Saved);
        }
    }
}
