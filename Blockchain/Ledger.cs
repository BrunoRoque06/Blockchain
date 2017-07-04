using System;
using System.Collections.Generic;
using System.Linq;

namespace Blockchain
{
    public class Ledger
    {
        public List<Block> Blocks { get; }
        private IBlockFactory _blockFactory;

        public Ledger(IBlockFactory blockFactory)
        {
            _blockFactory = blockFactory;
            Blocks = new List<Block>();

            var genesisBlock = _blockFactory.GenerateGenesisBlock();
            Blocks.Add(genesisBlock);
        }

        public void AddBlock(string data)
        {
            var newBlock = _blockFactory.GenerateNextBlock(GetLastBlock(), data);

            Blocks.Add(newBlock);
        }

        public Block GetLastBlock()
        {
            return Blocks.Last();
        }
    }
}
