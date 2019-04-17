using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestIsPrime
{
    [TestClass]
    public class UnitTestIsPrime
    {
        [TestMethod]
        public void Confirm_minus3_is_not_prime()
        {
            Assert.IsFalse(MyMath.IsPrime(-3));
        }

        [TestMethod]
        public void Confirm_0_is_not_prime()
        {
            Assert.IsFalse(MyMath.IsPrime(1));
        }

        [TestMethod]
        public void Confirm_1_is_not_prime()
        {
            Assert.IsFalse(MyMath.IsPrime(1));
        }

        [TestMethod]
        public void Confirm_2_is_prime()
        {
            Assert.IsTrue(MyMath.IsPrime(2));
        }

        [TestMethod]
        public void Confirm_3_is_prime()
        {
            Assert.IsTrue(MyMath.IsPrime(3));
        }

        [TestMethod]
        public void Confirm_4_is_not_prime()
        {
            Assert.IsFalse(MyMath.IsPrime(4));
        }

        [TestMethod]
        public void Confirm_11_is_prime()
        {
            Assert.IsTrue(MyMath.IsPrime(11));
        }

        [TestMethod]
        public void Confirm_17_is_prime()
        {
            Assert.IsTrue(MyMath.IsPrime(17));
        }

        [TestMethod]
        public void Confirm_54_is_not_prime()
        {
            Assert.IsFalse(MyMath.IsPrime(54));
        }

        [TestMethod]
        public void Confirm_4999_is_prime()
        {
            Assert.IsTrue(MyMath.IsPrime(4999));
        }

        [TestMethod]
        public void Confirm_179426549_is_prime()
        {
            Assert.IsTrue(MyMath.IsPrime(179426549));
        }

        [TestMethod]
        public void Confirm_1000000000_is_not_prime()
        {
            Assert.IsFalse(MyMath.IsPrime(1000000000));
        }
    }
}
