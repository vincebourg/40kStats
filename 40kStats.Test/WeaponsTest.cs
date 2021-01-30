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
    public class WeaponsTest
    {
        [TestMethod]
        public void weapon_attacks_has_to_be_set()
        {
            int numberOfAttacks = 2;
            Weapon weapon = new Weapon(numberOfAttacks, 0);
            Assert.AreEqual(numberOfAttacks, weapon.Attacks);
        }

        [TestMethod]
        public void weapon_strenght_has_to_be_set()
        {
            int weaponStrenght = 2;
            Weapon weapon = new Weapon(0, weaponStrenght);
            Assert.AreEqual(weaponStrenght, weapon.Strenght);
        }
    }
}
