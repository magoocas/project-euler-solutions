using System.IO;
using System.Linq;
using csharp.Utility;
using NUnit.Framework;

namespace csharp.Tests
{
    [TestFixture]
    public class PrimeTests
    {
        [Test]
        public void PrimeGeneratorFirstMillion()
        {
            var knownPrimes = File.ReadAllLines(Path.Combine("ProblemData", "primes", "firstmillionprimes.txt"))
                .Select(ulong.Parse);

            foreach (var prime in knownPrimes)
                Assert.That(ToolBox.PrimeSieve[prime], $"{prime} detected incorrectly as composite");
        }
        
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(8)]
        [TestCase(10)]
        [TestCase(12)]
        [TestCase(14)]
        [TestCase(15)]
        public void CompositeIsNotPrime(int composite)
        {
            Assert.That(!ToolBox.PrimeSieve[composite], $"{composite} detected as prime");
        }
    }
}
