using Newtonsoft.Json;

namespace profileLoaderTests;

[TestClass]
public sealed class loadJson
{
    const string profileJson = """
            {
                "weaponProfiles":[
                {
                        "name": "pulse blaster",
                        "attacks": "2",
                        "weaponSkill": 3,
                        "strength": 6,
                        "armorPenetration": 1,
                        "damage": 1
                }],
                "targetProfiles": [
                    {
                        "name": "space marine",
                        "toughness": 4,
                        "save": 3,
                        "wounds": 2
                    }]
            }
            """;

    [TestMethod]
    public void Can_extract_profile_from_json()
    {
        var result = JsonConvert.DeserializeObject<Profiles>(profileJson);
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.WeaponProfiles.Length);
        Assert.AreEqual(1, result.TargetProfiles.Length);
    }

    [TestMethod]
    public void Can_extract_Target_dictionary()
    {

    }
}
