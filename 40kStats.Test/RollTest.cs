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
    public class RollTest
    {

        [TestMethod]
        public void roll_of_1_is_always_a_miss()
        {
            Roll roll = new Roll(1, 1);
            Assert.IsTrue(roll.Missed);
        }

        [TestMethod]
        public void modified_roll_of_1_becomes_success()
        {
            Roll roll = new Roll(2, 1);
            Assert.IsTrue(roll.Missed);
            var reRoll = new Roll(2,2);
            Assert.IsFalse(reRoll.Missed);
        }

        [TestMethod]
        public void using_record_for_initialized_properties_is_not_good()
        {
            Roll roll = new Roll(2, 1);
            Assert.IsTrue(roll.Missed);
            var reRoll = roll with { RollResult = 2 };
            Assert.IsTrue(reRoll.Missed);
        }
    }
}
