using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEulerSolutions.CSharp;

namespace Tests
{
    [TestClass]
    public class CSharpTests
    {
        [TestMethod]
        public void TestSolution001() => Assert.AreEqual(Solution001.Answer, Answers.Problem001);
    }
}
