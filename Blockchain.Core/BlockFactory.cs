using Blockchain.Interfaces;
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

        public IBlock GenerateGenesisBlock()
        {
            return new GenesisBlock();
        }

        public IBlock GenerateNextBlock(IBlock lastBlock,
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

        public IBlock GenerateVoidBlock()
        {
            return new VoidBlock();
        }

        public string GetBlockHash(IBlock block)
        {
            return _hashEstimator.Estimate(block);
        }
    }
}
