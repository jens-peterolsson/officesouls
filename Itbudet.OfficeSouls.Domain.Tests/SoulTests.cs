using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Itbudet.OfficeSouls.Domain.Tests
{
    [TestClass]
    public class SoulTests
    {
        [TestMethod]
        public void AgeBasic()
        {
            var age = new Soul {Born = new DateTime(DateTime.Now.Year - 2, 1, 1)}.Age;
            Assert.AreEqual(2, age);
        }

        [TestMethod]
        public void AgeBeforeBirthday()
        {
            // don't run this test on new year's eve...
            var age = new Soul { Born = new DateTime(DateTime.Now.Year - 2, 12, 31) }.Age;
            Assert.AreEqual(1, age);
        }
    }
}
