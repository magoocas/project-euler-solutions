using csharp.Utility;
using NUnit.Framework;

namespace csharp.Tests
{
    [TestFixture]
    public class ToolBoxTests
    {

        [TestCase(1ul, ExpectedResult = 1ul)]
        [TestCase(3ul, ExpectedResult = 3ul)]
        [TestCase(11ul, ExpectedResult = 11ul)]
        [TestCase(123ul, ExpectedResult = 312ul)]
        [TestCase(84934ul, ExpectedResult = 48493ul)]
        public ulong Base10RotateRightUInt64Test(ulong number)
        {
            return ToolBox.Base10RotateRightUInt64(number);
        }
    }
}
