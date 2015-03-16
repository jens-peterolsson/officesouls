using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Itbudet.Nlg.Tests
{
    [TestClass]
    public class Basic
    {
        [TestMethod]
        public void BasicGrammar()
        {
            var result = NlgCreator.Instance.TransformBasicSentence("my dog is the best");
            Assert.AreEqual("My dog is the best.", result);
        }
        [TestMethod]
        public void BasicConstruction()
        {
            var param = new SentenceContent
            {
                SentenceSubject = "salomon",
                IndirectObject = "after",
                Complement = "wildly",
                SentenceObject = "Muffin",
                Verb = "run"
            };

            var result = NlgCreator.Instance.BasicObjectSubject(param);
            Assert.AreEqual("Salomon runs after Muffin wildly.", result);
        }
    }
}
