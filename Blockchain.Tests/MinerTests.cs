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
        Mock<IFifoStack> _unconfirmedDataStack;
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
                It.IsAny<string>(), It.IsAny<int>())).Returns(_dummyBlock);

            _unconfirmedDataStack = new Mock<IFifoStack>();
            _unconfirmedDataStack.Setup(e => e.GetData()).Returns(_data);

            _miner = new Miner(_blockFactoryMock.Object,
                _unconfirmedDataStack.Object);
        }

        [Test]
        public void Test_initialization_of_an_individual_to_contain_only_a_genesis_block_in_the_ledger()
        {
            Assert.That(_miner.Blockchain.GetLastBlock().Index, Is.EqualTo(0));
            Assert.That(_miner.Blockchain.GetLastBlock().Data, Is.EqualTo("IsItYouGenesis"));
        }

        [Test]
        public void Test_mine_method_to_add_a_block_if_it_solves_the_function()
        {
            _miner.Mine("NewData");

            var lastBlock = _miner.Blockchain.GetLastBlock();

            Assert.That(lastBlock.Index, Is.EqualTo(1));
            Assert.That(lastBlock.Data, Is.EqualTo("ImDummy"));
        }

        [Test]
        public void Test_the_creation_of_a_miner_to_have_his_pointers_set_to_null()
        {
            var miner = new Miner(_blockFactoryMock.Object,
                _unconfirmedDataStack.Object);

            Assert.That(miner.Before, Is.EqualTo(null));
            Assert.That(miner.Next, Is.EqualTo(null));
        }

        [Test]
        public void Test_the_creation_of_two_miners_to_be_connected()
        {
            var firstMiner = new Miner(_blockFactoryMock.Object,
                _unconfirmedDataStack.Object);
            var secondMiner = new Miner(_blockFactoryMock.Object,
                _unconfirmedDataStack.Object,
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
                _unconfirmedDataStack.Object);
            var thirdMiner = new Miner(_blockFactoryMock.Object,
                _unconfirmedDataStack.Object,
                firstMiner);
            var secondMiner = new Miner(_blockFactoryMock.Object,
                _unconfirmedDataStack.Object,
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
                _unconfirmedDataStack.Object);

            var result = miner.GetUnconfirmedData();

            Assert.That(result, Is.EqualTo(_data));
        }

        [Test]
        public void Test_block_function_to_return_true_since_the_hash_of_the_block_start_with_a_value_lower_than_100()
        {
            var block = new Block(0,
                DateTime.Today,
                string.Empty,
                "050356431354684",
                string.Empty,
                0);

            var result = _miner.DoesBlockSolveFunction(block);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_block_function_to_return_false_since_the_hash_of_the_block_is_higher_than_100()
        {
            var block = new Block(0,
                DateTime.Today,
                string.Empty,
                "80035",
                string.Empty,
                0);

            var result = _miner.DoesBlockSolveFunction(block);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Test_block_function_to_return_true_with_an_hash_of_99()
        {
            var block = new Block(0,
                DateTime.Today,
                string.Empty,
                "09980035",
                string.Empty,
                0);

            var result = _miner.DoesBlockSolveFunction(block);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_solve_function_method_to_get_block_with_nonce_0()
        {
            var hash = "000";
            var block = new Block(1,
                DateTime.MaxValue,
                string.Empty,
                hash,
                "ImDummy",
                0);
            var blockFactoryMock = new Mock<IBlockFactory>();
            blockFactoryMock.Setup(e => e.GenerateNextBlock(It.IsAny<Block>(),
                It.IsAny<string>(), 0)).Returns(block);
            var miner = new Miner(blockFactoryMock.Object,
                _unconfirmedDataStack.Object);

            var newBlock = miner.SolveFunction("data");

            Assert.That(newBlock.Nonce, Is.EqualTo(0));
            Assert.That(newBlock.Hash, Is.EqualTo(hash));
        }

        [Test]
        public void Test_solve_function_method_to_get_block_with_nonce_1()
        {
            var hash = "000";
            var block = new Block(1,
                DateTime.MaxValue,
                string.Empty,
                hash,
                "ImDummy",
                0);
            var blockFactoryMock = new Mock<IBlockFactory>();
            blockFactoryMock.Setup(e => e.GenerateNextBlock(It.IsAny<Block>(),
                It.IsAny<string>(), 0)).Returns(_dummyBlock);
            blockFactoryMock.Setup(e => e.GenerateNextBlock(It.IsAny<Block>(),
                It.IsAny<string>(), 1)).Returns(block);
            var miner = new Miner(blockFactoryMock.Object,
                _unconfirmedDataStack.Object);

            var newBlock = miner.SolveFunction("data");

            Assert.That(newBlock.Nonce, Is.EqualTo(1));
            Assert.That(newBlock.Hash, Is.EqualTo(hash));
        }
    }
}
