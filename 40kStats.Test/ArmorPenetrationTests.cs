using _40Stats.Core.Targets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _40kStats.Test
{
    [TestClass]
    public class ArmorPenetrationTests
    {
        [TestMethod]
        public void weapon_has_no_ap_by_default()
        {
            Weapon weapon = new Weapon(1,1);
            var realAP = weapon.ArmorPenetration;
            Assert.AreEqual(0, realAP);
        }

        [TestMethod]
        public void save_is_modified_by_ap()
        {
            Save save = new Save(5);
            save.Roll();
        }
    }
}
