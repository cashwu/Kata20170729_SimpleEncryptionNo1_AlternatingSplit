    using System;
    using System.Collections.Generic;
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

        [TestMethod]
        public void This_is_and_1_should_return_hsTi()
        {
            AssertEncryptShouldBe("This is", 1, "hsiTi s");
        }

        [TestMethod]
        public void This_and_2_should_return_sihT()
        {
            AssertEncryptShouldBe("This", 2, "sihT");
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

            for (int i = 0; i < n; i++)
            {
                text = AlternatingString(text);
            }

            return text;
        }

        private static string AlternatingString(string text)
        {
            var charArray = text.ToCharArray();
            return string.Concat(charArray.Where((c, i) => i % 2 != 0))
                   + string.Concat(charArray.Where((c, i) => i % 2 == 0));
        }
    }
}
