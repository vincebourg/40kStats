using _40Stats.Core.Rolls;
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
    public class RangedAttacksTests
    {
        [TestMethod]
        public void ranged_attack_must_have_shooter_strenght_and_target()
        {
            Target target = new(1);
            Shooter shooter = new(1);
            int weaponStrenght = 1;

            RangedAttack rangedAttack = new(target, shooter, weaponStrenght);

            Assert.AreEqual(weaponStrenght, rangedAttack.WeaponStrenght);
            Assert.AreEqual(shooter, rangedAttack.Shooter);
            Assert.AreEqual(target, rangedAttack.Target);
        }

        [TestMethod]
        public void ranged_attack_can_be_rolled_for_hit()
        {
            Target target = new(1);
            Shooter shooter = new(1);
            int weaponStrenght = 1;

            RangedAttack rangedAttack = new(target, shooter, weaponStrenght);

            HitRoll hitRoll = rangedAttack.RollHit();

            Assert.AreEqual(shooter.BalisticSkill, hitRoll.Expected);
        }

        [TestMethod]
        public void ranged_attack_can_be_rolled_for_wound()
        {
            Target target = new(1);
            Shooter shooter = new(1);
            int weaponStrenght = 1;
            int expectedWoundRoll = 4;


            RangedAttack rangedAttack = new(target, shooter, weaponStrenght);

            WoundRoll woundRoll = rangedAttack.RollWound();

            Assert.AreEqual(expectedWoundRoll, woundRoll.Expected);
        }
    }
}
