using _40Stats.Core.Attacks;
using System.Collections.Generic;
using System.Linq;

namespace _40Stats.Core.Targets
{
    public class Shooter(int balisticSkill)
    {
        public int BalisticSkill => balisticSkill;
        public Weapon Weapon { get; private set; }
        public IEnumerable<RangedAttack> Shoot(Target target, Weapon weapon)
        {
            Weapon = weapon;
            return Enumerable.Range(1, weapon.Attacks)
                         .Select(_ => new RangedAttack(target, this, weapon.Strength, weapon.ArmorPenetration)).ToList();
        }
    };
}