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
    public class FtpHelperTests
    {
        [TestMethod()]
        public void UploadFileTest()
        {
            var result = FtpHelper.UploadFile(@"E:\新建文本文档.txt", "测试.txt");
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void DownloadTest()
        {
            var result = FtpHelper.Download(@"E:\", "测试.txt");
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var result = FtpHelper.Delete("测试.txt");
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void GetAllFilesTest()
        {
            List<FTPFile> list = new List<FTPFile>();
            FtpHelper.GetListDirectory(list);
            Assert.AreEqual(true, list.Count > 0);
        }

        [TestMethod()]
        public void CreateFolderTest()
        {
            var result = FtpHelper.CreateFolder("测试文件夹2/测试");
            Assert.AreEqual(true, result);
        }
    }
}
