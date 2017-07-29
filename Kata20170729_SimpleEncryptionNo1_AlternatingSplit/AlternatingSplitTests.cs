    using System;
    using System.Linq;
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

        [TestMethod]
        public void This_and_1_should_return_hsTi()
        {
            AssertEncryptShouldBe("This", 1, "hsTi");
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
            if (n <= 0)
            {
                return text;
            }

            var charArray = text.ToCharArray();

            return charArray[1].ToString() + charArray[3].ToString() + charArray[0].ToString() + charArray[2].ToString();
        }
    }
}
