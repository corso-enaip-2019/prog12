using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class CupTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cup = new Cup();

            Assert.IsFalse(cup.IsFull);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var cup = new Cup();

            cup.Fill();
            Assert.IsTrue(cup.IsFull);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var cup = new Cup();

            cup.Fill();
            cup.Drink();

            Assert.IsFalse(cup.IsFull);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMethod4()
        {
            var cup = new Cup();

            cup.Fill();
            cup.Fill();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMethod5()
        {
            var cup = new Cup();

            cup.Drink();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMethod6()
        {
            var cup = new Cup();

            cup.Fill();
            cup.Drink();
            cup.Drink();
        }

        [TestMethod]
        public void TestMethod7()
        {
            var cup = new Cup();

            for (int i =0; i< 1000; i++)
            {
                cup.Fill();
                cup.Drink();
            }

            Assert.IsFalse(cup.IsFull);
        }

    }
}
