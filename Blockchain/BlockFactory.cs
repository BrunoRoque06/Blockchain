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

        public Block GenerateNextBlock(Block lastBlock,
            object dataNewBlock,
            int nonce)
        {
            var nextIndex = lastBlock.Index + 1;
            var date = DateTime.Now;

            var dummyBlock = new Block(nextIndex,
                date,
                lastBlock.Hash,
                string.Empty,
                dataNewBlock,
                nonce);

            var newHash = _hashEstimator.Estimate(dummyBlock);

            return new Block(nextIndex,
                date,
                lastBlock.Hash,
                newHash,
                dataNewBlock,
                nonce);
        }
    }
}
