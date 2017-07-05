using System.Collections.Generic;
using System.Linq;

namespace Blockchain
{
    public class Ledger
    {
        public List<Block> Blocks { get; }

        public Ledger(Block genesisBlock)
        {
            Blocks = new List<Block>();
            AddBlock(genesisBlock);
        }

        public void AddBlock(Block newBlock)
        {
            Blocks.Add(newBlock);
        }

        public Block GetLastBlock()
        {
            return Blocks.Last();
        }
    }
}
