using NUnit.Framework;
using System;

namespace Blockchain.Tests
{
    [TestFixture]
    public class BlockChainTests
    {
        [Test]
        public void Test_contains_index_to_return_false()
        {
            var block = new Block(0,
                new DateTime(),
                string.Empty,
                string.Empty,
                string.Empty,
                0);
            var blockchain = new Blockchain(block);

            var result = blockchain.ContainsIndex(0);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_contains_index_to_return_true()
        {
            var block = new Block(0,
                new DateTime(),
                string.Empty,
                string.Empty,
                string.Empty,
                0);
            var blockchain = new Blockchain(block);

            var result = blockchain.ContainsIndex(1);

            Assert.That(result, Is.False);
        }
    }
}
