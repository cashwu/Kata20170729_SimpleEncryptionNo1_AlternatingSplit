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
        public void This_and_0_time_Encrypt_should_return_This()
        {
            AssertEncryptShouldBe("This", 0, "This");
        }

        [TestMethod]
        public void This_and_1_time_Encrypt_should_return_hsTi()
        {
            AssertEncryptShouldBe("This", 1, "hsTi");
        }

        [TestMethod]
        public void This_is_a_test_and_1_time_Encrypt_should_return_hsi_etTi_sats()
        {
            AssertEncryptShouldBe("This is a test!", 1, "hsi  etTi sats!");
        }

        [TestMethod]
        public void This_is_a_test_and_2_time_Encrypt_should_return_s_eT_ashi_tist()
        {
            AssertEncryptShouldBe("This is a test!", 2, "s eT ashi tist!");
        }

        [TestMethod]
        public void This_is_a_test_and_3_time_Encrypt_should_return_Tah_itse_sits()
        {
            AssertEncryptShouldBe("This is a test!", 3, " Tah itse sits!");
        }

        [TestMethod]
        public void This_is_a_test_and_4_time_Encrypt_should_return_This_is_a_test()
        {
            AssertEncryptShouldBe("This is a test!", 4, "This is a test!");
        }

        [TestMethod]
        public void hsTi_and_0_time_Decrypt_should_return_hsTi()
        {
            var kata = new Kata();
            var actual = kata.Decrypt("hsTi", 1);
            Assert.AreEqual("hsTi", actual);
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

        public string Decrypt(string encryptedText, int n)
        {
            return encryptedText;
        }
    }
}
