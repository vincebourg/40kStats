using _40Stats.Core.Dices;
using _40Stats.Core.Rolls;
using _40Stats.Core.Targets;

namespace _40Stats.Core.Attacks
{
    public record RangedAttack(Target Target, Shooter Shooter, int WeaponStrenght, int ArmorPenetration = 0)
    {
        public HitRoll RollHit(IRoll roller) => new HitRoll(Shooter.BalisticSkill, roller.Roll());

        public WoundRoll RollWound(IRoll roller) => new WoundRoll(
            new WoundThresholdCalculator().GetThreshold(
                WeaponStrenght,
                Target.Endurance),
            roller.Roll()
        );

        public SaveRoll RollSave(IRoll roller) =>
            Target.Save != null
                ? Target.Save.Roll(roller, ArmorPenetration)
                : new SaveRoll(int.MaxValue, int.MinValue);
    }
}