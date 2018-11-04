using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Test")]
        public void TestMethod1()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        [TestCategory("Test")]
        public void TestMethod2()
        {
            Assert.AreEqual("Pablo", "Pablo");
        }
    }
}
