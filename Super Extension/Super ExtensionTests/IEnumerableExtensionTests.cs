using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperExtension.Tests
{
    [TestClass()]
    public class IEnumerableExtensionTests
    {
        [TestMethod()]
        public void WhereIfTest()
        {
            List<string> Strs = new List<string>();

            Strs.Add("Hello");
            Strs.Add("VVVVV");

            var testStrs = Strs.WhereIf(false, x => x != "VVVVV").ToList();

            Assert.IsTrue(testStrs.Count == 2);

            testStrs = Strs.WhereIf(true, x => x != "VVVVV").ToList();

            Assert.IsTrue(testStrs.Count == 1);
        }

        [TestMethod()]
        public void SaveToFileTest()
        {
            List<string> Strs = new List<string>();

            Strs.Add("Hello");
            Strs.Add("VVVVV");

            File.Delete("TestListSaveToFile.txt");
            File.Delete("Test");

            Strs.SaveToFile("TestListSaveToFile.txt", Encoding.UTF8);
            Strs.SaveToFile("Test");

            var fileContext = File.ReadAllLines("TestListSaveToFile.txt").Where(x => !string.IsNullOrEmpty(x)).ToList();
            var fileContextTest = File.ReadAllLines("TestListSaveToFile.txt").Where(x => !string.IsNullOrEmpty(x)).ToList();

            Assert.IsTrue(fileContext[0] == Strs[0]);
            Assert.IsTrue(fileContext.Count == Strs.Count);

            Assert.IsTrue(fileContextTest[0] == Strs[0]);
            Assert.IsTrue(fileContextTest.Count == Strs.Count);
        }

        [TestMethod()]
        public void ForEachTest()
        {
            List<string> Strs = new List<string>();

            Strs.Add("Hello");
            Strs.Add("VVVVV");

            IEnumerable<string> AAStrs = Strs;

            List<string> result = new List<string>();

            AAStrs.ForEach(x => result.Add(x));

            Assert.IsTrue(AAStrs.ToList()[0] == "Hello");
        }
    }
}