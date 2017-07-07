using System;

namespace Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            var individual = new Individual(new BlockFactory(new HashEstimator()));

            individual.AddBlock("First Block!");
            individual.AddBlock("Second Block!");
            individual.AddBlock("Third Block!");

            var ledgePrinter = new BlockchainPrinter();
            ledgePrinter.Print(individual.Blockchain);
        }
    }
}
