using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraTeam3;

namespace TerraTeam3Test
{
    [TestClass]
    public class UnitTestHerbivoor
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void HerbivoorMagNietLeegZijn()
        {
            new Herbivoor(string.Empty);
        }
    }
}
