using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _40kStats.Test
{
    [TestClass]
    public class DiceTests
    {
        [TestMethod]
        public void dice_can_be_rolled()
        {
            Dice dice = new();

            int diceRoll = dice.Roll();

            Assert.IsTrue(diceRoll >= 1 && diceRoll <= 6 );
        }

        [TestMethod]
        public void dice_value_is_always_between_1_and_6()
        {
            Dice dice = new();
            var diceBucket = Enumerable.Range(0, 100).Select(_ => dice.Roll());
            
            Assert.IsTrue(diceBucket.All(d => d > 0 && d < 7));
        }
    }
}
