using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperExtension;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperExtension.Tests
{
    [TestClass()]
    public class StringExtensionTests
    {
        [TestMethod()]
        public void IsNullOrEmptyOrWhiteSpaceTest()
        {
            string? testVal = null;
            Assert.IsTrue(testVal.IsNullOrEmptyOrWhiteSpace());
            Assert.IsTrue("".IsNullOrEmptyOrWhiteSpace());
            Assert.IsTrue("      ".IsNullOrEmptyOrWhiteSpace());
            Assert.IsFalse("          aa".IsNullOrEmptyOrWhiteSpace());
            Assert.IsFalse("    11     ".IsNullOrEmptyOrWhiteSpace());
            Assert.IsFalse("123".IsNullOrEmptyOrWhiteSpace());
        }

        [TestMethod()]
        public void ConverTest()
        {
            string? testVal = null;
            Assert.IsTrue(default == testVal.Conver<int>());
            Assert.IsTrue(default == "".Conver<int>());
            Assert.IsTrue(default == "   ".Conver<int>());
            Assert.IsTrue(default == "   ff".Conver<int>());
            Assert.IsTrue(1 == "1".Conver<int>());
            Assert.IsTrue(default == "".Conver<object>());
        }

        [TestMethod()]
        public void DeleteWhitespaceTest()
        {
            string? testVal = null;
            Assert.IsTrue(string.Empty == testVal.DeleteWhitespace());
            Assert.IsTrue(string.Empty == "".DeleteWhitespace());
            Assert.IsTrue(string.Empty == "     ".DeleteWhitespace());
            Assert.IsTrue("E" == "    E    ".DeleteWhitespace());
            Assert.IsTrue("123" == "1   2    3    ".DeleteWhitespace());
        }

        [TestMethod()]
        public void EqualsIgnoreCaseTest()
        {
            string? testVal = null;
            Assert.IsFalse(testVal.EqualsIgnoreCase("Hello"));
            Assert.IsFalse(testVal.EqualsIgnoreCase(" 55"));
            Assert.IsFalse(testVal.EqualsIgnoreCase(""));
            Assert.IsFalse("Hell".EqualsIgnoreCase(null));
            Assert.IsTrue("HELLO".EqualsIgnoreCase("HELLO"));
            Assert.IsTrue("HellO".EqualsIgnoreCase("hello"));
        }

        [TestMethod()]
        public void TrimStartAndEndTest()
        {
            string? testVal = null;
            Assert.IsTrue(testVal.TrimStartAndEnd() == string.Empty);
            Assert.IsTrue("".TrimStartAndEnd() == string.Empty);
            Assert.IsTrue("    ".TrimStartAndEnd() == string.Empty);
            Assert.IsTrue("     1".TrimStartAndEnd() == "1");
            Assert.IsTrue("2".TrimStartAndEnd() == "2");
            Assert.IsTrue("1 2 3 4".TrimStartAndEnd() == "1 2 3 4");
            Assert.IsTrue("1 2   .".TrimStartAndEnd() == "1 2   .");
            Assert.IsTrue("  1 2   ".TrimStartAndEnd() == "1 2");
        }

        [TestMethod()]
        public void SaveToFileTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                string? str = null;
                str.SaveToFile(null);
            });
            "Hello".SaveToFile("Test.txt");
            Assert.IsTrue(File.Exists("Test.txt"));
            Assert.IsTrue("Hello" == File.ReadAllText("Test.txt"));
            File.Delete("Test.txt");
        }

        [TestMethod()]
        public void SaveToFileTest1()
        {
            string changeStr = "こんにちは".EncodingChange(Encoding.UTF8, Encoding.Unicode);

            changeStr.SaveToFile("Test00.txt", Encoding.Unicode);

            Assert.IsTrue(changeStr == File.ReadAllText("Test00.txt", Encoding.Unicode));
            File.Delete("Test00.txt");
        }
    }
}