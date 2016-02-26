using System.IO;
using csharp.Utility;
using NUnit.Framework;

namespace csharp.Tests
{
    [TestFixture]
    public class PrimeTests
    {
        [Test]
        public void PrimeGenerator2PrimesLessThan10000000()
        {
            var primes = PrimeGenerator.PrimeSieve.GetPrimes(10000000);
            var knownPrimes = File.OpenText(Path.Combine("ProblemData", "primes", "firstmillionprimes.txt"));

            var n = 0;
            foreach (var generatedPrime in primes)
            {
                n++;
                var knownPrime = ulong.Parse(knownPrimes.ReadLine());

                Assert.That(generatedPrime, Is.EqualTo(knownPrime), $"Failed at prime n={n}");
                    
            }
        }
    }
}
