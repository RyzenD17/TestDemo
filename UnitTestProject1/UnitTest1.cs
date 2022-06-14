using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int result = 7;

            Class1 act = new Class1();
            int actual = act.GetDiscount(3, 1259);

            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int result = 7;

            Class1 act = new Class1();
            int actual = act.GetDiscount(4, 1259);

            Assert.AreEqual(result, actual);
        }
    }
}
