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

        public Block GenerateNextBlock(Block lastBlock)
        {
            var newBlock = new Block()
            {
                Index = lastBlock.Index + 1,
                DateTime = DateTime.Now,
                PreviousHash = lastBlock.Hash
            };

            newBlock.Hash = _hashEstimator.EstimateHash(newBlock);

            return newBlock;
        }
    }
}
