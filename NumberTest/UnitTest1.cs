using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using NumberStone;

namespace NumberTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNormalize()
        {
            var start = new List<int>() { 1, 11, 22 };
            var end = new List<int>() { 1, 11, 22 };

            var ns = new NumberStone.NumberStone(new List<int>() { 1, 11, 22 });

            Assert.AreEqual(ns.Digits.Count, end.Count);
            for (var i = 0; i < end.Count; i++)
            {
                Assert.AreEqual(ns[i], end[i]);
            }
        }
    }
}
