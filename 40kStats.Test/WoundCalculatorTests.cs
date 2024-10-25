using _40Stats.Core.Dices;
using _40Stats.Core.Statistics;
using _40Stats.Core.Targets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _40kStats.Test
{
    [TestClass]
    public class WoundCalculatorTests
    {
        [TestMethod]
        public void woundCalculator_can_calculate_wound_probability()
        {
            Target target = new(3);
            Weapon weapon = new(4, 2, 5);

            WoundCalculator calculator = new(target, weapon);

            WoundCalculatorResult result = calculator.Process(new Dice());

            Assert.AreEqual(weapon.Attacks, result.NumberOfShots);
            Assert.IsTrue(result.NumberOfShots >= result.NumberOfHits);
            Assert.IsTrue(result.NumberOfHits >= result.NumberOfWounds);
            Assert.IsTrue(result.NumberOfWounds >= result.numberOfNonSavedWounds);
        }

        [TestMethod]
        public void woundCalculator_counts_are_correct_if_no_hit()
        {
            int _ = 3;
            Target target = new(_);
            Weapon weapon = new(2, 1, _);

            WoundCalculator calculator = new(target, weapon);

            WoundCalculatorResult result = calculator.Process(new OnlyRollOne());

            Assert.AreEqual(1, result.NumberOfShots);
            Assert.AreEqual(0, result.NumberOfHits);
            Assert.AreEqual(0, result.NumberOfWounds);
            Assert.AreEqual(0, result.numberOfNonSavedWounds);
        }

        [TestMethod]
        public void woundCalculator_counts_are_correct_if_hit_but_no_wound()
        {
            int _ = 3;
            Target target = new(_);
            Weapon weapon = new(2, 1, _);

            WoundCalculator calculator = new(target, weapon);

            WoundCalculatorResult result = calculator.Process(new OnlyRollTwo());

            Assert.AreEqual(1, result.NumberOfShots);
            Assert.AreEqual(1, result.NumberOfHits);
            Assert.AreEqual(0, result.NumberOfWounds);
            Assert.AreEqual(0, result.numberOfNonSavedWounds);
        }

        [TestMethod]
        public void woundCalculator_counts_are_correct_if_wound_but_saved()
        {
            Save save = new(1);
            Target target = new(3, save);
            Weapon weapon = new(2, 1, 6);

            WoundCalculator calculator = new(target, weapon);

            WoundCalculatorResult result = calculator.Process(new OnlyRollTwo());

            Assert.AreEqual(1, result.NumberOfShots);
            Assert.AreEqual(1, result.NumberOfHits);
            Assert.AreEqual(1, result.NumberOfWounds);
            Assert.AreEqual(0, result.numberOfNonSavedWounds);
        }

        [TestMethod]
        public void woundCalculator_counts_are_correct_if_not_saved()
        {
            Save save = new(3);
            Target target = new(3, save);
            Weapon weapon = new(2, 1, 6);

            WoundCalculator calculator = new(target, weapon);

            WoundCalculatorResult result = calculator.Process(new OnlyRollTwo());

            Assert.AreEqual(1, result.NumberOfShots);
            Assert.AreEqual(1, result.NumberOfHits);
            Assert.AreEqual(1, result.NumberOfWounds);
            Assert.AreEqual(1, result.numberOfNonSavedWounds);
        }



        [TestMethod]
        public void woundCalculator_can_handle_devastating_wounds()
        {
            Target target = new(3, new Save(6, true));
            Weapon weapon = new(2, 1, 3, DevastatingWounds: true);

            WoundCalculator calculator = new(target, weapon);

            WoundCalculatorResult result = calculator.Process(new OnlyRollSix());

            Assert.AreEqual(1, result.NumberOfShots);
            Assert.AreEqual(1, result.NumberOfHits);
            Assert.AreEqual(1, result.NumberOfWounds);
            Assert.AreEqual(1, result.numberOfNonSavedWounds);
        }
    }
}
