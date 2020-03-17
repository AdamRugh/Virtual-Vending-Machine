using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace CapstoneTests.Test_Classes
{
    [TestClass]
    public class MachineTest
    {

        [TestMethod]
        public void MachineDispenser()
        {
            Machine machine = new Machine();
            decimal expected = "Hlo";
            decimal result = machine.Dispenser(Stackers);
            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void MachineFaults()
        {

        }

    }
}
