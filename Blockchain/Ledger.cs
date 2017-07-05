using System.Collections.Generic;
using System.Linq;

namespace Blockchain
{
    public class Ledger
    {
        public List<Block> Blocks { get; }

        public Ledger()
        {
            Blocks = new List<Block>();
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
