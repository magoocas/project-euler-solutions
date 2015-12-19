using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEulerSolutions.CSharp;

namespace Tests
{
    [TestClass]
    public class CSharpTests
    {
        public void Do<T>(Action<T,T> assert, T a, T b, [CallerMemberName] string testName = "")
        {
            Console.WriteLine($"{testName} asserts '{a}' and '{b}' {assert.Method.Name}.");
            assert(a, b);
        }

        [TestMethod]
        public void TestSolution001() => Do(Assert.AreEqual,Solution001.Answer(), Answers.Problem001);
        [TestMethod]
        public void TestSolution002() => Do(Assert.AreEqual,Solution002.Answer(), Answers.Problem002);
        [TestMethod]
        public void TestSolution003() => Do(Assert.AreEqual,Solution003.Answer(), Answers.Problem003);
        [TestMethod]
        public void TestSolution004() => Do(Assert.AreEqual,Solution004.Answer(), Answers.Problem004);
        [TestMethod]
        public void TestSolution005() => Do(Assert.AreEqual, Solution005.Answer(), Answers.Problem005);
    }
}
