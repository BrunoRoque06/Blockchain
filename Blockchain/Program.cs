using System;

namespace Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            var individual = new Miner(
                new BlockFactory(
                    new HashEstimator()),
                    new UnconfirmedDataFifo());

            individual.Mine("First Block!");
            individual.Mine("Second Block!");
            individual.Mine("Third Block!");

            var ledgePrinter = new BlockchainPrinter();
            ledgePrinter.Print(individual.Blockchain);
        }
    }
}
