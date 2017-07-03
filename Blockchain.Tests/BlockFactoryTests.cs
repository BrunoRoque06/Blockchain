using Moq;
using NUnit.Framework;
using System;

namespace Blockchain.Tests
{
    [TestFixture]
    public class BlockFactoryTests
    {
        BlockFactory _blockFactory;
        Block _block;

        [SetUp]
        public void BeforeTests()
        {
            Mock<IHashEstimator> hashEstimator = new Mock<IHashEstimator>();
            hashEstimator.Setup(h => h.Estimate(It.IsAny<Block>())).Returns("Mu");

            _blockFactory = new BlockFactory(hashEstimator.Object);

            _block = new Block(1, DateTime.MinValue, string.Empty, "Queen", "CorrectData");
        }

        [Test]
        public void Test_that_when_creating_a_block_index_should_be_increased_by_one()
        {
            var newBlock = _blockFactory.GenerateNextBlock(_block, string.Empty);

            Assert.That(newBlock.Index, Is.EqualTo(_block.Index + 1));
        }

        [Test]
        public void Test_that_when_creating_a_block_the_previous_hash_of_the_new_block_should_be_the_one_from_last_block()
        {
            var newBlock = _blockFactory.GenerateNextBlock(_block, string.Empty);

            Assert.That(newBlock.PreviousHash, Is.EqualTo("Queen"));
        }

        [Test]
        public void Test_that_the_hash_from_the_new_block_is_obtained_through_HashEstimator()
        {
            var newBlock = _blockFactory.GenerateNextBlock(_block, string.Empty);

            Assert.That(newBlock.Hash, Is.EqualTo("Mu"));
        }

        [Test]
        public void Test_that_data_from_a_new_block_is_correct()
        {
            var newData = "CorrectData";

            var newBlock = _blockFactory.GenerateNextBlock(_block, newData);

            Assert.That(newBlock.Data, Is.EqualTo(newData));
        }
    }
}
