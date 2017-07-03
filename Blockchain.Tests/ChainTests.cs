using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace Blockchain.Tests
{
    [TestFixture]
    public class ChainTests
    {
        Chain _chain;
        Block _genesisBlock;
        Block _dummyBlock;

        [SetUp]
        public void BeforeTests()
        {
            _genesisBlock = new Block(0,
                DateTime.MinValue,
                string.Empty,
                string.Empty,
                "IsItYouGenesis");

            _dummyBlock = new Block(1,
                DateTime.MaxValue,
                string.Empty,
                string.Empty,
                "ImDummy");

            Mock<IBlockFactory> blockFactory = new Mock<IBlockFactory>();

            blockFactory.Setup(h => h.GenerateGenesisBlock()).Returns(_genesisBlock);
            blockFactory.Setup(h => h.GenerateNextBlock(It.IsAny<Block>(),
                It.IsAny<string>())).Returns(_dummyBlock);

            _chain = new Chain(blockFactory.Object);
        }

        [Test]
        public void Test_initialization_of_a_chain_to_contain_only_a_genesis_block()
        {
            Assert.That(_chain.GetLastBlock().Index, Is.EqualTo(0));
            Assert.That(_chain.GetLastBlock().Data, Is.EqualTo("IsItYouGenesis"));
        }

        [Test]
        public void Test_the_new_block_to_be_the_dummy_block()
        {
            _chain.AddBlock("DoesNotMatter");

            var lastBlock = _chain.GetLastBlock();

            Assert.That(lastBlock.Index, Is.EqualTo(1));
            Assert.That(lastBlock.Data, Is.EqualTo("ImDummy"));
        }
    }
}
