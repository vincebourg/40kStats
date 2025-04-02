namespace profileLoaderTests;

public record Profiles(WeaponProfile[] WeaponProfiles, TargetProfile[] TargetProfiles);

public record TargetProfile(string Name, int Toughness, int Save, int Wounds);

public record WeaponProfile(string Name, string Attacks, int WeaponSkill, int Strenght, int ArmorPenetration, int Damage);