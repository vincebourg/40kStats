using _40Stats.Core.Attacks;
using _40Stats.Core.Dices;
using _40Stats.Core.Rolls;
using _40Stats.Core.Targets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace _40kStats.Test
{
    [TestClass]
    public partial class RangedAttacksTests
    {
        [TestMethod]
        public void ranged_attack_must_have_shooter_strenght_and_target()
        {
            Target target = new(1);
            var weapon = new Weapon(1, 1, 1);

            RangedAttack rangedAttack = new(target, weapon);

            Assert.AreEqual(weapon.Strength, rangedAttack.WeaponStrength);
            Assert.AreEqual(target, rangedAttack.Target);
        }

        [TestMethod]
        public void ranged_attack_can_be_rolled_for_hit()
        {
            Target target = new(1);
            var weapon = new Weapon(1, 1, 1);
            RangedAttack rangedAttack = new(target, weapon);

            HitRoll hitRoll = rangedAttack.RollHit(new Dice());

            Assert.AreEqual(weapon.Skill, hitRoll.Expected);
        }

        [TestMethod]
        public void ranged_attack_can_be_rolled_for_wound()
        {
            Target target = new(1);
            Weapon weapon = new(1, 1, 1);
            int expectedWoundRoll = 4;


            RangedAttack rangedAttack = new(target, weapon);

            WoundRoll woundRoll = rangedAttack.RollWound(new Dice());

            Assert.AreEqual(expectedWoundRoll, woundRoll.Expected);
        }

        [TestMethod]
        public void ranged_attack_can_be_rolled_for_save()
        {
            int expectedSaveRoll = 5;
            Save save = new(expectedSaveRoll);
            Target target = new(1, save);
            var weapon = new Weapon(1, 1, 1);

            RangedAttack rangedAttack = new(target, weapon);

            SaveRoll saveRoll = rangedAttack.RollSave(new Dice());

            Assert.AreEqual(expectedSaveRoll, saveRoll.Expected);
        }

        [TestMethod]
        public void ranged_attack_with_AP_makes_save_harder()
        {
            // given
            int expectedSaveRoll = 3;
            Save save = new(expectedSaveRoll);
            Target target = new(1, save);
            Weapon weapon = new(1, 1, 1, 2);

            // when
            var result = weapon.Shoot(target);

            // then
            Assert.AreEqual(result.Count(), 1, "Weapon shot should have generated one shot.");
            Assert.AreEqual(result.First().RollSave(new Dice()).Expected, 5, "Save should have been lowered by 2.");

        }

        [TestMethod]
        public void ranged_attack_damages()
        {
            // given
            Save save = new(6);
            Target target = new(1, save);
            Weapon weapon = new(1, 1, 2);
            RangedAttack attack = new RangedAttack(target, weapon);

            // when
            attack.Process(new OnlyRollFive());

            // then
            Assert.IsTrue(attack.HasHit);
            Assert.IsTrue(attack.HasWounded);
            Assert.IsTrue(attack.HasDamaged);
        }

        [TestMethod]
        public void ranged_attack_fails_by_default()
        {
            // given
            Save save = new(6);
            Target target = new(1, save);
            Weapon weapon = new(1, 1, 2);
            RangedAttack attack = new RangedAttack(target, weapon);

            // when
            attack.Process(new OnlyRollOne());

            // then
            Assert.IsFalse(attack.HasHit);
            Assert.IsFalse(attack.HasWounded);
            Assert.IsFalse(attack.HasDamaged);
        }

        [TestMethod]
        public void ranged_attack_just_hits()
        {
            // given
            Save save = new(6);
            Target target = new(2, save);
            Weapon weapon = new(1, 1, 1);
            RangedAttack attack = new RangedAttack(target, weapon);

            // when
            attack.Process(new OnlyRollFive());

            // then
            Assert.IsTrue(attack.HasHit);
            Assert.IsFalse(attack.HasWounded);
            Assert.IsFalse(attack.HasDamaged);
        }

        [TestMethod]
        public void ranged_attack_does_not_damage_if_save_successfull()
        {
            // given
            Save save = new(5);
            Target target = new(1, save);
            Weapon weapon = new(1, 1, 1);
            RangedAttack attack = new RangedAttack(target, weapon);

            // when
            attack.Process(new OnlyRollFive());

            // then
            Assert.IsTrue(attack.HasHit);
            Assert.IsTrue(attack.HasWounded);
            Assert.IsFalse(attack.HasDamaged);
        }

        [TestMethod]
        public void ranged_attack_with_devastating_always_damage_on_crit_wound()
        {
            // given
            Save save = new(2, true);
            Target target = new(1, save);
            Weapon weapon = new(1, 1, 1, DevastatingWounds: true);
            RangedAttack attack = weapon.Shoot(target).Single();

            // when
            attack.Process(new OnlyRollSix());

            // then
            Assert.IsTrue(attack.HasHit);
            Assert.IsTrue(attack.HasWounded);
            Assert.IsTrue(attack.HasDamaged);
        }
    }
}
