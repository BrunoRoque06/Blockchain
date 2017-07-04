using System;

namespace Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            var chain = new Chain(new BlockFactory(new HashEstimator()));

            chain.AddBlock("First Block!");
            chain.AddBlock("Second Block!");
            chain.AddBlock("Third Block!");

            var chainPrinter = new ChainPrinter();
            chainPrinter.Print(chain);
        }
    }
}
