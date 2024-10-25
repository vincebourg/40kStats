using _40Stats.Core.Targets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _40kStats.Test
{
    [TestClass]
    public class WeaponsTest
    {
        [TestMethod]
        public void weapon_attacks_has_to_be_set()
        {
            int numberOfAttacks = 2;
            Weapon weapon = new(0, numberOfAttacks, 0);
            Assert.AreEqual(numberOfAttacks, weapon.Attacks);
        }

        [TestMethod]
        public void weapon_strenght_has_to_be_set()
        {
            int weaponStrenght = 2;
            Weapon weapon = new(0, 0, weaponStrenght);
            Assert.AreEqual(weaponStrenght, weapon.Strength);
        }

        [TestMethod]
        public void weapon_can_have_devastating_wounds()
        {
            int weaponStrenght = 2;
            Weapon weapon = new(0, 0, weaponStrenght, DevastatingWounds: true);
            Assert.IsTrue(weapon.DevastatingWounds);
        }

        [TestMethod]
        public void weapon_is_not_devastating_by_default()
        {
            int weaponStrenght = 2;
            Weapon weapon = new(0, 0, weaponStrenght);
            Assert.IsFalse(weapon.DevastatingWounds);
        }
    }
}
