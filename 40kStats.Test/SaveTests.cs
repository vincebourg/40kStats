using _40Stats.Core.Rolls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _40kStats.Test
{
    [TestClass]
    public class SaveTests
    {
        [TestMethod]
        public void save_can_generate_save_roll()
        {
            Save save = new(5);
            SaveRoll result = save.Roll();
            Assert.IsNotNull(result);
        }
    }
}
