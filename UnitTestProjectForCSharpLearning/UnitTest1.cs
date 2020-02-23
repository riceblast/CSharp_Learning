using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryForTest;

namespace UnitTestProjectForCSharpLearning {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethodForTriangle() {
            Assert.AreEqual("一般三角形", MyTestClass.GetTriangle(new string[] { "4", "6", "5" }));
        }
    }
}
