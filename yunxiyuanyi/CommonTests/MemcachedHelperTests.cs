using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Common.Tests
{
    [TestClass()]
    public class MemcachedHelperTests
    {
        [TestMethod()]
        public void AddTest()
        {
            MemcachedHelper cache = new MemcachedHelper();
            cache.Add("temp", "12345", 20);
            var temp = cache.Get("temp");
            Assert.AreEqual("12345", temp.ToString());
        }
    }
}
