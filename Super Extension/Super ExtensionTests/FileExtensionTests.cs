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
    public class FileExtensionTests
    {
        [TestMethod()]
        public void DeleteTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                FileExtension.Delete("");
            });
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                FileExtension.Delete(" ");
            });
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                FileExtension.Delete(null);
            });
        }
    }
}