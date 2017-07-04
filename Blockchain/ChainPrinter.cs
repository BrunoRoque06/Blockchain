using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    public class ChainPrinter
    {
        public void Print(Chain chain)
        {
            foreach (var block in chain.BlockChain)
            {
                PrintBlock(block);
            }
        }

        private void PrintBlock(Block block)
        {
            Console.WriteLine("# " + block.Index);
            Console.WriteLine("Date:\t\t" + block.DateTime);
            Console.WriteLine("Data:\t\t" + block.Data);
            Console.WriteLine("Previous Hash:\t" + block.PreviousHash);
            Console.WriteLine("Hash:\t\t" + block.Hash + "\n");
        }
    }
}
