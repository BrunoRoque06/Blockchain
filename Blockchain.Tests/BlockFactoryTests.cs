using Moq;
using NUnit.Framework;

namespace Blockchain.Tests
{
    [TestFixture]
    public class BlockFactoryTests
    {
        BlockFactory _blockFactory;

        [SetUp]
        public void BeforeTests()
        {
            Mock<IHashEstimator> hashEstimator = new Mock<IHashEstimator>();
            hashEstimator.Setup(h => h.EstimateHash(It.IsAny<Block>())).Returns("Mu");

            _blockFactory = new BlockFactory(hashEstimator.Object);
        }

        [Test]
        public void Test_that_when_creating_a_block_index_should_be_increased_by_one()
        {
            var block = new Block() { Index = 1 };

            var newBlock = _blockFactory.GenerateNextBlock(block);

            Assert.That(newBlock.Index, Is.EqualTo(block.Index + 1));
        }

        [Test]
        public void Test_that_when_creating_a_block_the_previous_hash_of_the_new_block_should_be_the_one_from_last_block()
        {
            var block = new Block() { Hash = "Queen" };

            var newBlock = _blockFactory.GenerateNextBlock(block);

            Assert.That(newBlock.PreviousHash, Is.EqualTo("Queen"));
        }

        [Test]
        public void Test_that_the_hash_from_the_new_block_is_obtained_through_HashEstimator()
        {
            var newBlock = _blockFactory.GenerateNextBlock(new Block());

            Assert.That(newBlock.Hash, Is.EqualTo("Mu"));
        }
    }
}
