using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeStructures;

namespace UnitTests
{
    [TestClass]
    public class UnitTestTimePeriod
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructor1()
        {
            new TimePeriod(-1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructor2()
        {
            new TimePeriod(23, 60);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructor3()
        {
            new TimePeriod(23, 59, 60);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructorString()
        {
            new TimePeriod("122:59:79");
        }
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructorString2()
        {
            new TimePeriod("12:65:59");
        }
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorString3()
        {
            new TimePeriod("12:1:1");
        }
        [TestMethod]
        public void TestToString()
        {
            string a = (new TimePeriod(10, 1).ToString());
            string b = (new TimePeriod(122, 59, 59).ToString());
            Assert.AreEqual(a, "10:01:00");
            Assert.AreEqual(b, "122:59:59");
        }
        [TestMethod]
        public void TestEquals()
        {
            bool a = new TimePeriod(10, 10, 1).Equals(new TimePeriod(10, 10));
            bool b = new TimePeriod(10, 10).Equals(new TimePeriod("10:10:00"));
            bool c = new TimePeriod(300).Equals(new TimePeriod("00:05:00"));
            Assert.AreEqual(a, false);
            Assert.AreEqual(b, true);
            Assert.AreEqual(c, true);
        }
        [TestMethod]
        public void TestEqualsOverride()
        {
            bool a = new TimePeriod(10, 10).Equals(new Time(10, 10));
            bool b = new TimePeriod(10, 10).Equals(new TimePeriod(10, 10));
            Assert.AreEqual(a, false);
            Assert.AreEqual(b, true);
        }
        [TestMethod]
        public void TestCompareTo()
        {
            int a = new TimePeriod(10, 10, 1).CompareTo(new TimePeriod(10, 10));
            int b = new TimePeriod(10, 10).CompareTo(new TimePeriod(10, 10, 1));
            int c = new TimePeriod(10, 10).CompareTo(new TimePeriod("10:10:00"));
            Assert.AreEqual(a, 1);
            Assert.AreEqual(b, -1);
            Assert.AreEqual(c, 0);
        }
        [TestMethod]
        public void TestOperatorEquals()
        {
            bool a = new TimePeriod(10, 10) == new TimePeriod(10, 10, 01);
            bool b = new TimePeriod(10, 10) == new TimePeriod("10:10:00");
            Assert.AreEqual(a, false);
            Assert.AreEqual(b, true);
        }
        [TestMethod]
        public void TestOperatorNotEquals()
        {
            bool a = new TimePeriod(10, 10) != new TimePeriod(10, 10, 01);
            bool b = new TimePeriod(10, 10) != new TimePeriod("10:10:00");
            Assert.AreEqual(a, true);
            Assert.AreEqual(b, false);
        }
        [TestMethod]
        public void TestOperatorLessThan()
        {
            bool a = new TimePeriod(10, 10) < new TimePeriod(10, 10, 01);
            bool b = new TimePeriod(10, 10) < new TimePeriod("10:10:00");
            Assert.AreEqual(a, true);
            Assert.AreEqual(b, false);
        }
        [TestMethod]
        public void TestOperatorLessOrEquals()
        {
            bool a = new TimePeriod(10, 10) <= new TimePeriod(10, 10, 01);
            bool b = new TimePeriod(10) <= new TimePeriod("10:00:00");
            bool c = new TimePeriod(15, 10) <= new TimePeriod("12:10:00");
            Assert.AreEqual(a, true);
            Assert.AreEqual(b, true);
            Assert.AreEqual(c, false);
        }
        [TestMethod]
        public void TestOperatorMoreThan()
        {
            bool a = new TimePeriod(12, 10) > new TimePeriod(10, 10, 01);
            bool b = new TimePeriod(10, 10) > new TimePeriod("10:10:00");
            Assert.AreEqual(a, true);
            Assert.AreEqual(b, false);
        }
        [TestMethod]
        public void TestOperatorMoreOrEquals()
        {
            bool a = new TimePeriod(10, 10) >= new TimePeriod(10, 10, 01);
            bool b = new TimePeriod(10, 10) >= new TimePeriod("10:10:00");
            bool c = new TimePeriod(15, 10) >= new TimePeriod("12:10:00");
            Assert.AreEqual(a, false);
            Assert.AreEqual(b, true);
            Assert.AreEqual(c, true);
        }
        [TestMethod]
        public void TestOperatorPlus()
        {
            TimePeriod a = new TimePeriod(12, 40) + new TimePeriod(10, 15, 01);
            TimePeriod b = new TimePeriod(12, 40) + new TimePeriod(12, 15, 01);
            Assert.AreEqual(a, new TimePeriod(22, 55, 01));
            Assert.AreEqual(b, new TimePeriod(24, 55, 01));
        }
        [TestMethod]
        public void TestPlus()
        {
            TimePeriod a = new TimePeriod(12, 40).Plus(new TimePeriod(10, 15, 01));
            TimePeriod b = new TimePeriod(12, 40).Plus(new TimePeriod(12, 15, 01));
            Assert.AreEqual(a, new TimePeriod(22, 55, 01));
            Assert.AreEqual(b, new TimePeriod(24, 55, 01));
        }
        [TestMethod]
        public void TestPlusStatic()
        {
            TimePeriod a = TimePeriod.Plus(new TimePeriod(12, 40), (new TimePeriod(10, 15, 01)));
            TimePeriod b = TimePeriod.Plus(new TimePeriod(12, 40), (new TimePeriod(12, 15, 01)));
            Assert.AreEqual(a, new TimePeriod(22, 55, 01));
            Assert.AreEqual(b, new TimePeriod(24, 55, 01));
        }
        [TestMethod]
        public void TestOperatorMultiplication()
        {
            TimePeriod a = new TimePeriod(1, 40) * 5;
            TimePeriod b = new TimePeriod(1, 40) * 25;
            Assert.AreEqual(a, new TimePeriod(8, 20, 0));
            Assert.AreEqual(b, new TimePeriod(41, 40, 0));
        }
    }
}
