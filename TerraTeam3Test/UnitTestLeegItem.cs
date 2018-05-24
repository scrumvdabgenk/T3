using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraTeam3;

namespace TerraTeam3Test
{
    [TestClass]
    public class UnitTestLeegItem
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void LeegItemMoetEenNaamHebben()
        {
            new LeegItem(string.Empty);
        }
    }
}
