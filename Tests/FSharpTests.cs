using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEulerSolutions.FSharp;

namespace Tests
{
    [TestClass]
    public unsafe class FSharpTests
    {
        [TestMethod]
        public void TestSolution001() => Assert.AreEqual(Solution001.Answer, Answers.Problem001);

        [TestMethod]
        public void TestSolution002() => Assert.AreEqual(Solution002.Answer, Answers.Problem002);

        [TestMethod]
        public void TestSolution003() => Assert.AreEqual(Solution003.Answer, Answers.Problem003);
    }
}
