using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperExtension;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperExtension.Tests
{
    [TestClass()]
    public class EnumerableCastTests
    {
        [TestMethod()]
        public void CastToIEnumerableTest()
        {
            var aa = new ArrayList();
            aa.Add("Test");
            aa.Add("Test BB");

            List<string> strs = aa.CastToIEnumerable<string>().ToList();

            Assert.AreEqual(2, strs.Count);
            Assert.AreEqual("Test", strs[0]);
            Assert.AreEqual("Test BB", strs[1]);
        }
    }
}