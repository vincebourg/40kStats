using _40Stats.Core.Dices;
using _40Stats.Core.Rolls;
using _40Stats.Core.Targets;

namespace _40Stats.Core.Attacks
{
    public class RangedAttack(Target target, Weapon weapon, int armorPenetration = 0)
    {
        public Target Target => target;
        public Weapon Weapon => weapon;
        public int WeaponStrength => Weapon.Strength;
        public int ArmorPenetration => armorPenetration;
        public bool HasHit { get; private set; } = false;
        public bool HasWounded { get; private set; } = false;
        public bool HasDamaged { get; private set; } = false;
        public HitRoll HitRoll { get; private set; }
        public WoundRoll WoundRoll { get; private set; }
        public SaveRoll SaveRoll { get; private set; }
        public void Process(IRoll roller)
        {
            HitRoll = RollHit(roller);
            if (HitRoll.Hit)
            {
                HasHit = true;
                WoundRoll = RollWound(roller);
                if (WoundRoll.Wounded)
                {
                    HasWounded = true;
                    if (WoundRoll.IsCritical && weapon.DevastatingWounds)
                    {
                        HasDamaged = true;
                    }
                    else
                    {
                        SaveRoll = RollSave(roller);
                        if (SaveRoll.Missed)
                        {
                            HasDamaged = true;
                        }
                    }
                }
            }
        }

        public HitRoll RollHit(IRoll roller) => new(Weapon.Skill, roller.Roll());

        public WoundRoll RollWound(IRoll roller) => new(
            new WoundThresholdCalculator().GetThreshold(
                WeaponStrength,
                Target.Endurance),
            roller.Roll()
        );

        public SaveRoll RollSave(IRoll roller) =>
            Target.Save != null
                ? Target.Save.Roll(roller, ArmorPenetration)
                : new SaveRoll(int.MaxValue, int.MinValue);
    }
}