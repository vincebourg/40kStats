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
    public class WoundCalculatorTests
    {
        [TestMethod]
        public void woundCalculator_can_calculate_wound_probability()
        {
            Target target = new(3);
            Shooter shooter = new(4);
            Weapon weapon = new(2, 5);

            WoundCalculator calculator = new(target, shooter, weapon);

            WoundCalculatorResult result = calculator.Process();

            Assert.AreEqual(weapon.Attacks, result.NumberOfShots);
            Assert.IsTrue(result.NumberOfShots >= result.NumberOfHits);
            Assert.IsTrue(result.NumberOfHits >= result.NumberOfWounds);

        }
    }
}
