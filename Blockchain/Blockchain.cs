using System.Collections.Generic;
using System.Linq;

namespace Blockchain
{
    public class Blockchain
    {
        public List<Block> Blocks { get; }

        public Blockchain(Block genesisBlock)
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
