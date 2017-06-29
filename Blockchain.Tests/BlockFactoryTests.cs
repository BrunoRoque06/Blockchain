using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Tests
{
    [TestFixture]
    public class BlockFactoryTests
    {
        BlockFactory _blockFactory = new BlockFactory(new HashEstimator());

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
            var block = new Block() { Hash = "Mu" };

            var newBlock = _blockFactory.GenerateNextBlock(block);

            Assert.That(newBlock.PreviousHash, Is.EqualTo("Mu"));
        }
    }
}
