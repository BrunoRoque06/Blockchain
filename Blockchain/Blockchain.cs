using Blockchain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blockchain
{
    public class Blockchain
    {
        public IList<IBlock> Blocks { get; }

        public Blockchain(IBlock genesisBlock)
        {
            Blocks = new List<IBlock>();
            AddBlock(genesisBlock);
        }

        public void AddBlock(IBlock newBlock)
        {
            Blocks.Add(newBlock);
        }

        public IBlock GetLastBlock()
        {
            return Blocks.Last();
        }

        public bool ContainsIndex(int index)
        {
            return Blocks.Select(e => e.Index).Contains(index);
        }

        public int Count()
        {
            return Blocks.Count();
        }
    }
}
