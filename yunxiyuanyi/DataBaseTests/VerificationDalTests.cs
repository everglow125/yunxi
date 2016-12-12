using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.LogicModel;

namespace DataBase.Tests
{
    [TestClass()]
    public class VerificationDalTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            VerificationDal vd = new VerificationDal();
            Verification model = new Verification();
            model.CreateBy = 1;
            model.CreateTime = DateTime.Now;
            model.FailureTime = DateTime.Now.AddDays(7);
            model.VerificationCode = "sss1111";
            model.VerificationStatus = 1;
            model.VerificationType = 1;
            var result = vd.Insert(model);
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            VerificationDal vd = new VerificationDal();
            var result = vd.GetAll();
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            VerificationDal vd = new VerificationDal();
            Verification model = new Verification();
            model.FailureTime = DateTime.Now.AddDays(30);
            model.VerificationCode = "code123";
            model.VerificationStatus = 2;
            model.VerificationType = 2;
            model.VerificationId = 1;
            var result = vd.Update(model);
            Assert.AreEqual(1, result);
        }
    }
}