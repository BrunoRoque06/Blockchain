using NUnit.Framework;
using System;

namespace Blockchain.Tests
{
    [TestFixture]
    public class HashEstimatorTests
    {
        HashEstimator _hashEstimator = new HashEstimator();

        [Test]
        public void Test_hash_estimation_to_return_the_same_value_for_the_same_inputs()
        {
            var dateOne = new DateTime(2017, 6, 3);
            var dateTwo = new DateTime(2017, 6, 3);

            var blockOne = new Block(1, "Pawn", dateOne, 18);
            var blockTwo = new Block(1, "Pawn", dateTwo, 18);

            var hashOne = _hashEstimator.EstimateHash(blockOne);
            var hashTwo = _hashEstimator.EstimateHash(blockTwo);

            Assert.That(hashOne, Is.EqualTo(hashTwo));
        }

        [Test]
        public void Test_hash_estimation_to_return_different_values_for_different_inputs()
        {
            var dateOne = new DateTime(2017, 6, 3);
            var dateTwo = new DateTime(2017, 6, 3);

            var blockOne = new Block(1, "Pawn", dateOne, 18);
            var blockTwo = new Block(1, "Knight", dateTwo, 18);

            var hashOne = _hashEstimator.EstimateHash(blockOne);
            var hashTwo = _hashEstimator.EstimateHash(blockTwo);

            Assert.That(hashOne, Is.Not.EqualTo(hashTwo));
        }
    }
}
