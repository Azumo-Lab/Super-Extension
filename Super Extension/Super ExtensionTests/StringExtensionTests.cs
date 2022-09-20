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
            DirectoryInfo directory = new DirectoryInfo("TestDir");
            if (directory.Exists)
                directory.Delete(true);

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                string? str = null;
                str.SaveToFile(null);
            });
            "Hello".SaveToFile("Test.txt");
            Assert.IsTrue(File.Exists("Test.txt"));
            Assert.IsTrue("Hello" == File.ReadAllText("Test.txt"));
            File.Delete("Test.txt");

            "HELLO".SaveToFile("TestDir/Test.txt");
            Assert.IsTrue("HELLO" == File.ReadAllText("TestDir/Test.txt"));

            ((string?)null).SaveToFile("TestDir/NULL.txt");
            Assert.IsTrue("" == File.ReadAllText("TestDir/NULL.txt"));
        }

        [TestMethod()]
        public void SaveToFileTest1()
        {
            string changeStr = "こんにちは".EncodingChange(Encoding.UTF8, Encoding.Unicode);

            FileExtension.Delete("Test00.txt");

            changeStr.SaveToFile("Test00.txt", Encoding.Unicode);

            Assert.IsTrue(changeStr == File.ReadAllText("Test00.txt", Encoding.Unicode));
        }

        [TestMethod()]
        public void ReverseTest()
        {
            string testVal = "123456";
            Assert.IsTrue(testVal.Reverse() == "654321");
            Assert.IsTrue("".Reverse() == "");
            Assert.IsTrue("ABCDEFG".Reverse() == "GFEDCBA");
            Assert.IsTrue("12Ad".Reverse() == "dA21");
            Assert.IsTrue("0.!#!#14".Reverse() == "41#!#!.0");
        }

        [TestMethod()]
        public void DefaultStringTest()
        {
            string? testVal = "123456";
            Assert.IsTrue(testVal.DefaultString() == "123456");
            Assert.IsTrue("".DefaultString(x => x.IsNullOrEmptyOrWhiteSpace(), "Hello") == "Hello");
            testVal = null;
            Assert.IsTrue(testVal.DefaultString("123") == "123");
            Assert.IsTrue(testVal.DefaultString() == string.Empty);
            Assert.IsTrue(testVal.DefaultString(x => x == null, "new") == "new");
            Assert.IsTrue("AA".DefaultString(x => x == null, "G") == "AA");
        }

        [TestMethod()]
        public void UpperFirstLetterTest()
        {
            Assert.IsTrue("abcd".UpperFirstLetter() == "Abcd");
            Assert.IsTrue("ABCD".UpperFirstLetter() == "ABCD");
            Assert.IsTrue("".UpperFirstLetter() == "");
            Assert.IsTrue(((string?)null).UpperFirstLetter() == "");
            Assert.IsTrue(" ".UpperFirstLetter() == " ");
        }

        [TestMethod()]
        public void LowerFirstLetterTest()
        {
            Assert.IsTrue("abcd".LowerFirstLetter() == "abcd");
            Assert.IsTrue("ABCD".LowerFirstLetter() == "aBCD");
            Assert.IsTrue("".LowerFirstLetter() == "");
            Assert.IsTrue(((string?)null).LowerFirstLetter() == "");
            Assert.IsTrue(" ".LowerFirstLetter() == " ");
        }

        [TestMethod()]
        public void DifferenceTest()
        {
            Assert.IsTrue("c" == "AABB".Difference("AABc"));
            Assert.IsTrue("" == "AABB".Difference("AABB"));
            Assert.IsTrue("" == "AABB".Difference(null));
            Assert.IsTrue("" == ((string?)null).Difference("AABc"));
            Assert.IsTrue("" == ((string?)null).Difference(null));
        }
    }
}