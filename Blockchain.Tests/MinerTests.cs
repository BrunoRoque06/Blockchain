using Blockchain.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace Blockchain.Tests
{
    [TestFixture]
    public class MinerTests
    {
        Miner _miner;
        Block _genesisBlock;
        Block _dummyBlock;
        Mock<IBlockFactory> _blockFactoryMock;
        Mock<IFifoStack> _unfonfirmedDataStack;
        string _data = "ThisIsData";

        [SetUp]
        public void BeforeTests()
        {
            _genesisBlock = new Block(0,
                DateTime.MinValue,
                string.Empty,
                string.Empty,
                "IsItYouGenesis",
                0);

            _dummyBlock = new Block(1,
                DateTime.MaxValue,
                string.Empty,
                string.Empty,
                "ImDummy",
                0);

            _blockFactoryMock = new Mock<IBlockFactory>();

            _blockFactoryMock.Setup(e => e.GenerateGenesisBlock()).Returns(_genesisBlock);
            _blockFactoryMock.Setup(e => e.GenerateNextBlock(It.IsAny<Block>(),
                It.IsAny<string>())).Returns(_dummyBlock);

            _unfonfirmedDataStack = new Mock<IFifoStack>();

            _unfonfirmedDataStack.Setup(e => e.GetData()).Returns(_data);

            _miner = new Miner(_blockFactoryMock.Object,
                _unfonfirmedDataStack.Object);
        }

        [Test]
        public void Test_initialization_of_an_individual_to_contain_only_a_genesis_block_in_the_ledger()
        {
            Assert.That(_miner.Blockchain.GetLastBlock().Index, Is.EqualTo(0));
            Assert.That(_miner.Blockchain.GetLastBlock().Data, Is.EqualTo("IsItYouGenesis"));
        }

        [Test]
        public void Test_the_new_block_added_to_be_the_dummy_block_generated_by_the_mock()
        {
            _miner.AddBlock("DoesNotMatter");

            var lastBlock = _miner.Blockchain.GetLastBlock();

            Assert.That(lastBlock.Index, Is.EqualTo(1));
            Assert.That(lastBlock.Data, Is.EqualTo("ImDummy"));
        }

        [Test]
        public void Test_the_creation_of_a_miner_to_have_his_pointers_set_to_null()
        {
            var miner = new Miner(_blockFactoryMock.Object,
                _unfonfirmedDataStack.Object);

            Assert.That(miner.Before, Is.EqualTo(null));
            Assert.That(miner.Next, Is.EqualTo(null));
        }

        [Test]
        public void Test_the_creation_of_two_miners_to_be_connected()
        {
            var firstMiner = new Miner(_blockFactoryMock.Object,
                _unfonfirmedDataStack.Object);
            var secondMiner = new Miner(_blockFactoryMock.Object,
                _unfonfirmedDataStack.Object,
                firstMiner);

            Assert.That(firstMiner.Before, Is.EqualTo(null));
            Assert.That(firstMiner.Next, Is.EqualTo(secondMiner));
            Assert.That(secondMiner.Before, Is.EqualTo(firstMiner));
            Assert.That(secondMiner.Next, Is.EqualTo(null));
        }

        [Test]
        public void Test_the_creation_of_tree_miners_to_be_connected()
        {
            var firstMiner = new Miner(_blockFactoryMock.Object,
                _unfonfirmedDataStack.Object);
            var thirdMiner = new Miner(_blockFactoryMock.Object,
                _unfonfirmedDataStack.Object,
                firstMiner);
            var secondMiner = new Miner(_blockFactoryMock.Object,
                _unfonfirmedDataStack.Object,
                firstMiner);

            Assert.That(firstMiner.Before, Is.EqualTo(null));
            Assert.That(firstMiner.Next, Is.EqualTo(secondMiner));
            Assert.That(secondMiner.Before, Is.EqualTo(firstMiner));
            Assert.That(secondMiner.Next, Is.EqualTo(thirdMiner));
            Assert.That(thirdMiner.Before, Is.EqualTo(secondMiner));
            Assert.That(thirdMiner.Next, Is.EqualTo(null));
        }

        [Test]
        public void Test_get_unconfirmed_data_to_return_the_one_mocked()
        {
            var miner = new Miner(_blockFactoryMock.Object,
                _unfonfirmedDataStack.Object);

            var result = miner.GetUnconfirmedData();

            Assert.That(result, Is.EqualTo(_data));
        }
    }
}
