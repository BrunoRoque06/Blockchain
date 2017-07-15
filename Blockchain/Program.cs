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

            individual.MineBlock("First Block!");
            individual.MineBlock("Second Block!");
            individual.MineBlock("Third Block!");

            var ledgePrinter = new BlockchainPrinter();
            ledgePrinter.Print(individual.Blockchain);
        }
    }
}
