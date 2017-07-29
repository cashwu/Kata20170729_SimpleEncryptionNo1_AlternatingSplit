    using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata20170729_SimpleEncryptionNo1_AlternatingSplit
{
    [TestClass]
    public class AlternatingSplitTests
    {
        [TestMethod]
        public void This_and_0_should_return_This()
        {
            AssertEncryptShouldBe("This", 0, "This");
        }

        private static void AssertEncryptShouldBe(string text, int time, string expected)
        {
            var kata = new Kata();
            var actual = kata.Encrypt(text, time);
            Assert.AreEqual(expected, actual);
        }
    }

    public class Kata
    {
        public string Encrypt(string text, int n)
        {
            return text;
        }
    }
}
