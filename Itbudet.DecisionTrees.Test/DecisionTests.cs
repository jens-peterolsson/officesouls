using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Itbudet.DecisionTrees.Test
{
    [TestClass]
    public class DecisionTests
    {
        private Decision _tested;

        [TestInitialize]
        public void Init()
        {
            _tested = new Decision();
        }

        [TestMethod]
        public void TestBasicValues()
        {
            Assert.AreEqual(2, _tested.Decide(10, 2));
            Assert.AreEqual(0, _tested.Decide(5, 1));
            Assert.AreEqual(1, _tested.Decide(5, 2));
        }
    }
}
