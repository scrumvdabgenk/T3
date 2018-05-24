using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraTeam3;

namespace TerraTeam3Test
{
    [TestClass]
    public class UnitTestCarnivoor
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void CarnivoorNaamMagNietLeegZijn()
        {
            new Carnivoor(string.Empty);
        }
    }
}
