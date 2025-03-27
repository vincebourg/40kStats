using _40Stats.Core.Attacks;
using System.Collections.Generic;
using System.Linq;

namespace _40Stats.Core.Targets
{
    public record Weapon(int Skill, int Attacks, int Strength, int ArmorPenetration = 0, bool DevastatingWounds = false, bool LethalHit = false)
    {
        public IEnumerable<RangedAttack> Shoot(Target target)
        {
            return Enumerable.Range(1, Attacks)
                         .Select(_ => new RangedAttack(target, this, ArmorPenetration)).ToList();
        }
    }
}