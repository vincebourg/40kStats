using _40Stats.Core.Targets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _40kStats.Test
{
    [TestClass]
    public class TargetTests
    {
        [TestMethod]
        public void target_endurance_has_to_be_set()
        {
            int enduranceValue = 1;
            Target target = new Target(enduranceValue);
            Assert.AreEqual(enduranceValue, target.Endurance);
        }

        [TestMethod]
        public void target_save_can_be_set()
        {
            int enduranceValue = 1;
            int saveValue = 5;
            Target target = new Target(enduranceValue, new Save(saveValue));
            Assert.AreEqual(saveValue, target.Save.Expected);
        }

    }
}
