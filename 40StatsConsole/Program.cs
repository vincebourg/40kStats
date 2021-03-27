using _40Stats.Core.Dices;
using _40Stats.Core.Statistics;
using _40Stats.Core.Targets;
using System;
using System.Linq;


if (args.Length != 5 || args.Any(a => !int.TryParse(a, out int result) || result > 10 || result < 1))
{
    Console.WriteLine("Usage: NumberOfAttacks BalisticSkill WeaponStrenght TargetToughtness TargetSave");
    Console.WriteLine("Values must be between 1 and 10");
}

var NumberOfShots       = int.Parse(args[0]);
var balisticSkill       = int.Parse(args[1]);
var WeaponStrenght      = int.Parse(args[2]);
var TargetToughtness    = int.Parse(args[3]);
var TargetSave          = int.Parse(args[4]);

Console.WriteLine($"# of shots: {NumberOfShots}");
Console.WriteLine($"Balistic skill: {balisticSkill}");
Console.WriteLine($"Weapon strenght: {WeaponStrenght}");
Console.WriteLine($"Target toughtness: {TargetToughtness}");
Console.WriteLine($"Target save: {TargetSave}");

Dice dice = new();

Shooter shooter = new(balisticSkill);
Weapon weapon = new(NumberOfShots, WeaponStrenght);
Save save = new Save(TargetSave);
Target target = new(TargetToughtness, save);

WoundCalculator woundCalculator = new WoundCalculator(target, shooter, weapon);

var results = Enumerable.Range(0, 100)
    .Select(i => woundCalculator.Process(dice));

var averageNumberOfShots = results.Average(r => r.NumberOfShots);
var averageNumberOfHits = results.Average(r => r.NumberOfHits);
var averageNumberOfWounds = results.Average(r => r.NumberOfWounds);
var averageNumberOfUnsaved = results.Average(r => r.numberOfNonSavedWounds);

Console.WriteLine($"Average Number of shots: {averageNumberOfShots}");
Console.WriteLine($"Average Number of hits: {averageNumberOfHits}");
Console.WriteLine($"Average Number of wounds: {averageNumberOfWounds}");
Console.WriteLine($"Average Number of unsaved wounds: {averageNumberOfUnsaved}");

