using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    public class BlockFactory
    {
        IHashEstimator _hashEstimator;

        public BlockFactory(IHashEstimator hashEstimator)
        {
            _hashEstimator = hashEstimator;
        }

        public Block GenerateNextBlock(Block lastBlock)
        {
            var newBlock = new Block();

            newBlock.Index = lastBlock.Index + 1;
            newBlock.DateTime = DateTime.Now;
            newBlock.PreviousHash = lastBlock.Hash;

            return newBlock;
        }
    }
}
