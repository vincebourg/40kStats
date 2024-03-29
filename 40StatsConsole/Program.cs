﻿using _40Stats.Core.Dices;
using _40Stats.Core.Statistics;
using _40Stats.Core.Targets;
using System;
using System.Linq;


if (args.Length != 7 || args.Take(6).Any(a => !int.TryParse(a, out int result) || result < 1) || !bool.TryParse(args[6], out var resultBool))
{
    Console.WriteLine("Usage: NumberOfAttacks BalisticSkill WeaponStrenght WeaponArmorPenetration TargetToughtness TargetSave IsInvulnerableSave");
    Console.WriteLine("Values must be integer and more than 1, except IsInvulnerableSave which must be true or false");
    return;
}

var NumberOfShots           = int.Parse(args[0]);
var balisticSkill           = int.Parse(args[1]);
var WeaponStrenght          = int.Parse(args[2]);
var WeaponArmorPenetration  = int.Parse(args[3]);
var TargetToughtness        = int.Parse(args[4]);
var TargetSave              = int.Parse(args[5]);
var InvulnerableSave        = resultBool;

Console.WriteLine($"# of shots: {NumberOfShots}");
Console.WriteLine($"Balistic skill: {balisticSkill}");
Console.WriteLine($"Weapon strenght: {WeaponStrenght}");
Console.WriteLine($"Weapon strenght: {WeaponArmorPenetration}");
Console.WriteLine($"Target toughtness: {TargetToughtness}");
Console.WriteLine($"Target save: {TargetSave}");
Console.WriteLine($"Target save: {InvulnerableSave}");

Dice dice = new();

Shooter shooter = new(balisticSkill);
Weapon weapon = new(NumberOfShots, WeaponStrenght, WeaponArmorPenetration);
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

