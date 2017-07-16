using Blockchain.Interfaces;
using System;

namespace Blockchain
{
    public class BlockchainPrinter
    {
        public void Print(Blockchain chain)
        {
            PrintHeader();

            foreach (var block in chain.Blocks)
            {
                PrintBlock(block);
            }
        }

        private void PrintHeader()
        {
            Console.WriteLine("\nMiner Blockchain:");
            Console.Write("# {0, 3}", "Ind");
            Console.Write("{0, 15}", "Data");
            Console.Write("{0, 7}", "Nonce");
            Console.Write("{0, 12}", "Hash");
            Console.Write("{0, 12}", "PreviousHash");
            Console.Write("{0, 20}", "DateTime");
            Console.Write("\n");
        }

        private void PrintBlock(IBlock block)
        {
            Console.Write("# {0, 3}", block.Index);
            Console.Write("{0, 15}", block.Data);
            Console.Write("{0, 7}", block.Nonce);
            Console.Write("{0, 12}", block.Hash);
            Console.Write("{0, 12}", block.PreviousHash);
            Console.Write("{0, 20}", block.DateTime);
            Console.Write("\n");
        }
    }
}
