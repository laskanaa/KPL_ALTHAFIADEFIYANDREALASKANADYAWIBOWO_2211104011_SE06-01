using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace modul12_2211104011.Tests
{
    [TestClass]
    public class Form1Tests
    {
        Form1 form = new Form1();

        [TestMethod]
        public void TestPangkat_Normal()
        {
            Assert.AreEqual(8, form.CariNilaiPangkat(2, 3));
        }

        [TestMethod]
        public void TestPangkat_BZero()
        {
            Assert.AreEqual(1, form.CariNilaiPangkat(5, 0));
        }

        [TestMethod]
        public void TestPangkat_Negatif()
        {
            Assert.AreEqual(-1, form.CariNilaiPangkat(2, -2));
        }

        [TestMethod]
        public void TestPangkat_Limit()
        {
            Assert.AreEqual(-2, form.CariNilaiPangkat(101, 2));
        }

        [TestMethod]
        public void TestPangkat_Overflow()
        {
            Assert.AreEqual(-3, form.CariNilaiPangkat(50, 10));
        }
    }
}