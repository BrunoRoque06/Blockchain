using System;

namespace Blockchain
{
    public class BlockFactory : IBlockFactory
    {
        IHashEstimator _hashEstimator;

        public BlockFactory(IHashEstimator hashEstimator)
        {
            _hashEstimator = hashEstimator;
        }

        public Block GenerateGenesisBlock()
        {
            return new Block(0,
                DateTime.Now,
                string.Empty,
                string.Empty,
                "GenesisBlock",
                0);
        }

        public Block GenerateNextBlock(Block lastBlock, string dataNewBlock)
        {
            var nextIndex = lastBlock.Index + 1;

            var dummyBlock = new Block(nextIndex,
                DateTime.Now,
                lastBlock.Hash,
                string.Empty,
                dataNewBlock,
                0);

            var newHash = _hashEstimator.Estimate(dummyBlock);

            return new Block(nextIndex,
                DateTime.Now,
                lastBlock.Hash,
                newHash,
                dataNewBlock,
                0);
        }
    }
}
