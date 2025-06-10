using Microsoft.SqlServer.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace tpmodul12_2211104011.Tests
{
    [TestClass]
    public class TandaBilanganTests
    {
        Form1 form = new Form1();

        [TestMethod]
        public void TestNegatif()
        {
            Assert.AreEqual("Negatif", form.CariTandaBilangan(-5));
        }

        [TestMethod]
        public void TestNol()
        {
            Assert.AreEqual("Nol", form.CariTandaBilangan(0));
        }

        [TestMethod]
        public void TestPositif()
        {
            Assert.AreEqual("Positif", form.CariTandaBilangan(100));
        }
    }

}