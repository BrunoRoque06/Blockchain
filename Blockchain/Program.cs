using System;

namespace Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            var chain = new Chain(new BlockFactory(new HashEstimator()));
            var chainPrinter = new ChainPrinter();

            chain.AddBlock("Mu!");

            chain.AddBlock("Agua!");

            chainPrinter.Print(chain);
        }
    }
}
