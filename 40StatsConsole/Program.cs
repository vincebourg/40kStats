using _40Stats.Core.Dices;
using _40Stats.Core.Statistics;
using _40Stats.Core.Targets;
using System;
using System.Linq;


if (args.Length != 7 || args.Take(6).Any(a => !int.TryParse(a, out int result) || result < 1) || !bool.TryParse(args[6], out var resultBool))
{
    Console.WriteLine("Usage: NumberOfAttacks BalisticSkill WeaponStrength WeaponArmorPenetration TargetToughness TargetSave IsInvulnerableSave");
    Console.WriteLine("Values must be integer and more than 1, except IsInvulnerableSave which must be true or false");
    return;
}

var NumberOfShots = int.Parse(args[0]);
var balisticSkill = int.Parse(args[1]);
var WeaponStrength = int.Parse(args[2]);
var WeaponArmorPenetration = int.Parse(args[3]);
var TargetToughness = int.Parse(args[4]);
var TargetSave = int.Parse(args[5]);
var InvulnerableSave = resultBool;

Console.WriteLine($"# of shots: {NumberOfShots}");
Console.WriteLine($"Balistic skill: {balisticSkill}");
Console.WriteLine($"Weapon strength: {WeaponStrength}");
Console.WriteLine($"Weapon armor penetration: {WeaponArmorPenetration}");
Console.WriteLine($"Target toughness: {TargetToughness}");
Console.WriteLine($"Target save: {TargetSave}");
Console.WriteLine($"Target invulnerable save: {InvulnerableSave}");

Dice dice = new();

Weapon weapon = new(balisticSkill, NumberOfShots, WeaponStrength, WeaponArmorPenetration);
Save save = new(TargetSave);
Target target = new(TargetToughness, save);

WoundCalculator woundCalculator = new(target, weapon);

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

