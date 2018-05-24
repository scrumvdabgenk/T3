using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraTeam3;

namespace TerraTeam3Test
{
    [TestClass]
    public class UnitTestPlant
    {
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void PlantNaamMoetIngevuldZijn()
        {
            new Plant(string.Empty);
        }
    }
}
