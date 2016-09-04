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
    }
}
