using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeStructures;

namespace UnitTests
{
    [TestClass]
    public class UnitTestTime
    {
        [TestMethod]
        public void TestCompareTo()
        {
            int a = new Time(10, 10, 1).CompareTo(new Time(10, 10));
            int b = new Time(10, 10).CompareTo(new Time(10, 10,1));
            int c = new Time(10, 10).CompareTo(new Time("10:10:00"));
            Assert.AreEqual(a, 1);
            Assert.AreEqual(b, -1);
            Assert.AreEqual(c, 0);
        }
        [TestMethod]
        public void TestEquals()
        {
            bool a = new Time(10, 10, 1).Equals(new Time(10, 10));
            bool b = new Time(10, 10).Equals(new Time("10:10:00"));
            Assert.AreEqual(a, false);
            Assert.AreEqual(b, true);
        }
        [TestMethod]
        public void TestEqualsOverride()
        {
            bool a = new Time(10, 10).Equals(new Time(10, 10));
            bool b = new Time(10, 10).Equals(new TimePeriod(10,10));
            Assert.AreEqual(a, true);
            Assert.AreEqual(b, false);
        }
        [TestMethod]
        public void TestOperatorEquals()
        {
            bool a = new Time(10, 10) == new Time(10, 10, 01);
            bool b = new Time(10, 10) == new Time("10:10:00");
            Assert.AreEqual(a, false);
            Assert.AreEqual(b, true);
        }
        [TestMethod]
        public void TestOperatorNotEquals()
        {
            bool a = new Time(10, 10) != new Time(10, 10, 01);
            bool b = new Time(10, 10) != new Time("10:10:00");
            Assert.AreEqual(a, true);
            Assert.AreEqual(b, false);
        }
        [TestMethod]
        public void TestOperatorLessThan()
        {
            bool a = new Time(10, 10) < new Time(10, 10, 01);
            bool b = new Time(10, 10) < new Time("10:10:00");
            Assert.AreEqual(a, true);
            Assert.AreEqual(b, false);
        }
        [TestMethod]
        public void TestOperatorLessOrEquals()
        {
            bool a = new Time(10, 10) <= new Time(10, 10, 01);
            bool b = new Time(10) <= new Time("10:00:00");
            bool c = new Time(15, 10) <= new Time("12:10:00");
            Assert.AreEqual(a, true);
            Assert.AreEqual(b, true);
            Assert.AreEqual(c, false);
        }
        [TestMethod]
        public void TestOperatorMoreThan()
        {
            bool a = new Time(12, 10) > new Time(10, 10, 01);
            bool b = new Time(10, 10) > new Time("10:10:00");
            Assert.AreEqual(a, true);
            Assert.AreEqual(b, false);
        }
        [TestMethod]
        public void TestOperatorMoreOrEquals()
        {
            bool a = new Time(10, 10) >= new Time(10, 10, 01);
            bool b = new Time(10, 10) >= new Time("10:10:00");
            bool c = new Time(15, 10) >= new Time("12:10:00");
            Assert.AreEqual(a, false);
            Assert.AreEqual(b, true);
            Assert.AreEqual(c, true);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructor1()
        {
            new Time(25);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructor2()
        {
            new Time(23,60);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructor3()
        {
            new Time(23, 59, 60);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorString()
        {
            new Time("122:59:59");
        }
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructorString2()
        {
            new Time("12:65:59");
        }
        [TestMethod]
        public void TestOperatorPlus()
        {
            Time a = new Time(12, 40) + new TimePeriod(10, 15, 01);
            Time b = new Time(12, 40) + new TimePeriod(12, 15, 01);
            Assert.AreEqual(a, new Time(22, 55, 01));
            Assert.AreEqual(b, new Time(00, 55, 01));
        }
        [TestMethod]
        public void TestPlus()
        {
            Time a = new Time(12, 40).Plus(new TimePeriod(10, 15, 01));
            Time b = new Time(12, 40).Plus(new TimePeriod(12, 15, 01));
            Assert.AreEqual(a, new Time(22, 55, 01));
            Assert.AreEqual(b, new Time(00, 55, 01));
        }
        [TestMethod]
        public void TestPlusStatic()
        {
            Time a = Time.Plus(new Time(12, 40),(new TimePeriod(10, 15, 01)));
            Time b = Time.Plus(new Time(12, 40),(new TimePeriod(12, 15, 01)));
            Assert.AreEqual(a, new Time(22, 55, 01));
            Assert.AreEqual(b, new Time(00, 55, 01));
        }
        [TestMethod]
        public void TestToString()
        {
            string a = (new Time(10, 1).ToString());
            string b = (new Time(10, 59, 59).ToString());
            Assert.AreEqual(a, "10:01:00");
            Assert.AreEqual(b, "10:59:59");
        }
    }
}
