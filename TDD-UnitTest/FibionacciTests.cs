using NUnit.Framework;
using System;

namespace TDD_UnitTest
{
    public class FibionacciTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        [TestCase(5, 5)]
        public void TestFibionacci(int expted, int index)
        {
            Assert.AreEqual(expted, GetFibionacci(index));
        }

        private int GetFibionacci(int index)
        {
            if (index == 0) return 0;
            if (index == 1) return 1;
            return GetFibionacci(index - 1) + GetFibionacci (index - 2);
        }
    }
}