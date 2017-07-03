using System.Collections.Generic;

namespace Blockchain
{
    public class Chain
    {
        IEnumerable<Block> Blocks;
        private IBlockFactory _blockFactory;

        public Chain(IBlockFactory blockFactory)
        {
            _blockFactory = blockFactory;
        }
    }
}
