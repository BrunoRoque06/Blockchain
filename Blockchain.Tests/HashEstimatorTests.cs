using NUnit.Framework;
using System;

namespace Blockchain.Tests
{
    [TestFixture]
    public class HashEstimatorTests
    {
        HashEstimator _hashEstimator = new HashEstimator();
        DateTime _date;
        Block _block;
        Block _equalToBlock;
        Block _differentThanBlock;

        [SetUp]
        public void BeforeTest()
        {
            _date = new DateTime(2017, 6, 3);
            _block = new Block(1, DateTime.MinValue, "O", string.Empty, "Pawn", 0);
            _equalToBlock = new Block(1, DateTime.MinValue, "O", string.Empty, "Pawn", 0);
            _differentThanBlock = new Block(1, DateTime.MinValue, "O", string.Empty, "Mu", 0);
        }

        [Test]
        public void Test_hash_estimation_to_return_the_same_value_for_the_same_inputs()
        {
            var hashOne = _hashEstimator.Estimate(_block);
            var hashTwo = _hashEstimator.Estimate(_equalToBlock);

            Assert.That(hashOne, Is.EqualTo(hashTwo));
        }

        [Test]
        public void Test_hash_estimation_to_return_different_values_for_different_inputs()
        {
            var hashOne = _hashEstimator.Estimate(_block);
            var hashTwo = _hashEstimator.Estimate(_differentThanBlock);

            Assert.That(hashOne, Is.Not.EqualTo(hashTwo));
        }
    }
}
