using _40Stats.Core.Rolls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
