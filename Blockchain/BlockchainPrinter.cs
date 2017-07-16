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

            Console.WriteLine();
        }

        private void PrintHeader()
        {
            Console.WriteLine("\nMiner Blockchain:");
            Console.Write("# {0, 3}", "Ind");
            Console.Write("{0, 15}", "Data");
            Console.Write("{0, 10}", "Nonce");
            Console.Write("{0, 15}", "Hash");
            Console.Write("{0, 15}", "PreviousHash");
            Console.Write("{0, 22}", "DateTime");
            Console.Write("\n");
        }

        private void PrintBlock(IBlock block)
        {
            Console.Write("# {0, 3}", block.Index);
            Console.Write("{0, 15}", block.Data);
            Console.Write("{0, 10}", block.Nonce);
            Console.Write("{0, 15}", block.Hash);
            Console.Write("{0, 15}", block.PreviousHash);
            Console.Write("{0, 22}", block.DateTime);
            Console.Write("\n");
        }
    }
}
