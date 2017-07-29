using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            AssertDecryptShouldBe("hsTi", 0, "hsTi");
        }

        [TestMethod]
        public void hsTi_and_1_time_Decrypt_should_return_This()
        {
            AssertDecryptShouldBe("hsTi", 1, "This");
        }

        [TestMethod]
        public void Ti_shs_and_1_time_Decrypt_should_return_This_is()
        {
            AssertDecryptShouldBe("hsiTi s", 1, "This is");
        }

        [TestMethod]
        public void Ti_shs_and_2_time_Decrypt_should_return_This()
        {
            AssertDecryptShouldBe("sihT", 2, "This");
        }

        [TestMethod]
        public void hskt_svr_neetnTi_aai_eyitrsig_Decrypt_should_return_This_kata_is_very_interesting()
        {
            AssertDecryptShouldBe("hskt svr neetn!Ti aai eyitrsig", 1, "This kata is very interesting!");
        }

        [TestMethod]
        public void null_Encrypt_should_return_null()
        {
            AssertEncryptShouldBe(null, 0, null);
        }

        [TestMethod]
        public void null_Decrypt_should_return_null()
        {
            AssertDecryptShouldBe(null, 0, null);
        }

        private static void AssertDecryptShouldBe(string encryptedText, int n, string expected)
        {
            var kata = new Kata();
            var actual = kata.Decrypt(encryptedText, n);
            Assert.AreEqual(expected, actual);
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
            if (n <= 0 || string.IsNullOrEmpty(text))
            {
                return text;
            }

            for (int i = 0; i < n; i++)
            {
                text = AlternatingEncryptString(text);
            }

            return text;
        }

        public string Decrypt(string encryptedText, int n)
        {
            if (n <= 0 || string.IsNullOrEmpty(encryptedText))
            {
                return encryptedText;
            }

            for (int i = 0; i < n; i++)
            {
                encryptedText = AlternatingDecryptString(encryptedText);
            }

            return encryptedText;
        }

        private static string AlternatingEncryptString(string text)
        {
            var charArray = text.ToCharArray();
            return string.Concat(charArray.Where((c, i) => i % 2 != 0))
                   + string.Concat(charArray.Where((c, i) => i % 2 == 0));
        }

        private static string AlternatingDecryptString(string encryptedText)
        {
            var len = encryptedText.Length / 2;

            var text1 = encryptedText.Substring(0, len);
            var text2 = encryptedText.Substring(len, encryptedText.Length - len);

            var sb = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                sb.Append(text2[i]).Append(text1[i]);
            }

            if (encryptedText.Length % 2 != 0)
            {
                sb.Append(text2.Last());
            }

            return sb.ToString();
        }
    }
}
