using _40Stats.Core.Targets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _40kStats.Test
{
    [TestClass]
    public class ShotTests
    {
        [TestMethod]
        public void shot_target_weapon_and_shooter_must_be_set()
        {
            Target target = new (1);
            Shooter shooter = new (1);
            Weapon weapon = new (1,1);
            Shot shot = new(target, shooter, weapon);
            Assert.AreEqual(target, shot.Target);
            Assert.AreEqual(shooter, shot.Shooter);
            Assert.AreEqual(weapon, shot.Weapon);
        }

        
    }
}
