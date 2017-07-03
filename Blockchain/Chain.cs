using System.Collections.Generic;

namespace Blockchain
{
    public class Chain
    {
        public List<Block> Blocks;
        private IBlockFactory _blockFactory;

        public Chain(IBlockFactory blockFactory)
        {
            _blockFactory = blockFactory;
            Blocks = new List<Block>();

        }

        public void AddBlock(string data)
        {
        }
    }
}
