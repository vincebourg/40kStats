using _40Stats.Core.Targets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _40kStats.Test
{
    internal record Shooter(int BalisticSkill)
    {
        internal IEnumerable<RangedAttack> Shoot( Target target, Weapon weapon )
            => Enumerable.Range( 1, weapon.Attacks )
                         .Select( _ => new RangedAttack ( target, this, weapon.Strenght ) );
    };
}