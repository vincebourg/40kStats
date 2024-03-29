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

            HitRoll hitRoll = rangedAttack.RollHit(new Dice());

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

            WoundRoll woundRoll = rangedAttack.RollWound(new Dice());

            Assert.AreEqual(expectedWoundRoll, woundRoll.Expected);
        }

        [TestMethod]
        public void ranged_attack_can_be_rolled_for_save()
        {
            int expectedSaveRoll = 5;
            Save save = new(expectedSaveRoll);
            Target target = new(1,save);
            Shooter shooter = new(1);
            int weaponStrenght = 1;

            RangedAttack rangedAttack = new(target, shooter, weaponStrenght);

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
            Shooter shooter = new(1);
            Weapon weapon = new(1, 1, 2);

            // when
            var result = shooter.Shoot(target, weapon);

            // then
            Assert.AreEqual(result.Count(), 1, "Weapon shot should have generated one shot.");
            Assert.AreEqual(result.First().RollSave(new Dice()).Expected, 5, "Save should have been lowered by 2.");
            
        }
    }
}
