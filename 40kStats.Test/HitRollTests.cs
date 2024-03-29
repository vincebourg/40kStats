using _40Stats.Core.Rolls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _40kStats.Test
{
    [TestClass]
    public class HitRollTests
    {
        [TestMethod]
        public void four_when_five_needed_to_hit_is_miss()
        {
            HitRoll roll = new HitRoll(5, 4);
            Assert.IsTrue(roll.Missed);
            Assert.IsFalse(roll.Hit);
        }

        [TestMethod]
        public void four_when_four_needed_to_hit_is_hit()
        {
            HitRoll roll = new HitRoll(4, 4);
            Assert.IsTrue(roll.Hit);
            Assert.IsFalse(roll.Missed);
        }
    }
}
