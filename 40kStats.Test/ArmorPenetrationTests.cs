using _40Stats.Core.Dices;
using _40Stats.Core.Targets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using static _40kStats.Test.RangedAttacksTests;

namespace _40kStats.Test
{
    [TestClass]
    public class ArmorPenetrationTests
    {
        [TestMethod]
        public void weapon_has_no_ap_by_default()
        {
            Weapon weapon = new Weapon(1,1);
            var realAP = weapon.ArmorPenetration;
            Assert.AreEqual(0, realAP);
        }

        [TestMethod]
        public void save_is_modified_by_ap()
        {
            Save save = new Save(5);
            var result = save.Roll(new OnlyRollOne(), 1);
            Assert.AreEqual(6, result.Expected);
        }

        [TestMethod]
        public void no_possible_success_if_AP_too_strong()
        {
            Save save = new Save(1);
            var allPossibleDices = new IRoll[]
            {
                new OnlyRollOne(),
                new OnlyRollTwo(),
                new OnlyRollThree(),
                new OnlyRollFour(),
                new OnlyRollFive(),
                new OnlyRollSix()
            };

            var rolls = allPossibleDices.Select(d => save.Roll(d, 6));
            Assert.IsTrue(rolls.All(r => r.Missed));
        }
    }
}
