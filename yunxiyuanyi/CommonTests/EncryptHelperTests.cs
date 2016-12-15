using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests
{
    [TestClass()]
    public class EncryptHelperTests
    {
        [TestMethod()]
        public void ToMD5_16Test()
        {
            var result = "123456".ToMD5_16(Encoding.UTF8);
            Assert.AreEqual("49ba59abbe56e057", result.ToLower());
        }

        [TestMethod()]
        public void ToMD5_32Test()
        {
            var result = "123456".ToMD5_32(Encoding.UTF8);
            Assert.AreEqual("e10adc3949ba59abbe56e057f20f883e", result.ToLower());
        }

        [TestMethod()]
        public void To3DESTest()
        {
            var result = "123456".To3DES(Encoding.UTF8, "123456789012123456789012");
            Assert.AreEqual("+ornxGsoh9o=", result);
        }

        [TestMethod()]
        public void Dencrypt3DESTest()
        {
            var result = "+ornxGsoh9o=".Dencrypt3DES(Encoding.UTF8, "123456789012123456789012");
            Assert.AreEqual("123456", result);
        }
    }
}