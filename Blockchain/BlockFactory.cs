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

        public Block GenerateNextBlock(Block lastBlock, string dataNewBlock)
        {
            var nextIndex = lastBlock.Index + 1;

            var dummyBlock = new Block(nextIndex,
                DateTime.Now,
                lastBlock.Hash,
                string.Empty,
                dataNewBlock);

            var newHash = _hashEstimator.Estimate(dummyBlock);

            return new Block(nextIndex,
                DateTime.Now,
                lastBlock.Hash,
                newHash,
                dataNewBlock);
        }
    }
}
