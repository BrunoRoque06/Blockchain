using Blockchain.Interfaces;
using System;

namespace Blockchain
{
    public class BlockchainPrinter
    {
        public void Print(Blockchain chain)
        {
            foreach (var block in chain.Blocks)
            {
                PrintBlock(block);
            }
        }

        private void PrintBlock(IBlock block)
        {
            Console.WriteLine("# " + block.Index);
            Console.WriteLine("Date:\t\t" + block.DateTime);
            Console.WriteLine("Data:\t\t" + block.Data);
            Console.WriteLine("Previous Hash:\t" + block.PreviousHash);
            Console.WriteLine("Hash:\t\t" + block.Hash + "\n");
        }
    }
}
