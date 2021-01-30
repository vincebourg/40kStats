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
    public class ShooterTests
    {
        [TestMethod]
        public void shooter_balistic_skill_must_be_set()
        {
            int balisticSkill = 1;
            Shooter shooter = new (balisticSkill);
            Assert.AreEqual(balisticSkill, shooter.BalisticSkill);
        }

        [TestMethod]
        public void shooter_shooting_weapon_with_several_attacks_generates_as_much_ranged_attacks()
        {
            int randomNumberOfAttacks = new Random().Next(1, 10);
            int randomStrenght = new Random().Next(1, 10);
            Target target = new(1);
            Weapon weapon = new(randomNumberOfAttacks, randomStrenght);
            Shooter shooter = new Shooter(1);

            IEnumerable<RangedAttack> rangedAttacks = shooter.Shoot(target, weapon);

            Assert.AreEqual(randomNumberOfAttacks, rangedAttacks.Count());
            Assert.IsTrue(rangedAttacks.All(r => r.WeaponStrenght == weapon.Strenght));
            Assert.IsTrue(rangedAttacks.All(r => r.Shooter == shooter));
            Assert.IsTrue(rangedAttacks.All(r => r.Target == target));
        }
    }
}
