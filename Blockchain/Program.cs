using System;

namespace Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            var blockFactory = new BlockFactory(new HashEstimator());
            var unconfirmedData = new UnconfirmedDataFifo();

            var firstMiner = new Miner(blockFactory, unconfirmedData);
            var secondMiner = new Miner(blockFactory, unconfirmedData, firstMiner);
            var thirdMiner = new Miner(blockFactory, unconfirmedData, secondMiner);

            unconfirmedData.AddData("Hund!");

            firstMiner.MineBlock();

            var blockchainPrinter = new BlockchainPrinter();
            blockchainPrinter.Print(firstMiner.Blockchain);
            blockchainPrinter.Print(secondMiner.Blockchain);
            blockchainPrinter.Print(thirdMiner.Blockchain);
        }
    }
}
