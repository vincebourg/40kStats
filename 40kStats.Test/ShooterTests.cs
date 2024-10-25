using _40Stats.Core.Attacks;
using _40Stats.Core.Targets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _40kStats.Test
{
    [TestClass]
    public class ShooterTests
    {
        [TestMethod]
        public void shooter_shooting_weapon_with_several_attacks_generates_as_much_ranged_attacks()
        {
            int randomNumberOfAttacks = new Random().Next(1, 10);
            int randomStrenght = new Random().Next(1, 10);
            Target target = new(1);
            Weapon weapon = new(1, randomNumberOfAttacks, randomStrenght);

            IEnumerable<RangedAttack> rangedAttacks = weapon.Shoot(target);

            Assert.AreEqual(randomNumberOfAttacks, rangedAttacks.Count());
            Assert.IsTrue(rangedAttacks.All(r => r.WeaponStrength == weapon.Strength));
            Assert.IsTrue(rangedAttacks.All(r => r.Target == target));
        }
    }
}
