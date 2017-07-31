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

            var fakeBlock = new Block(10,
                DateTime.MinValue,
                string.Empty,
                string.Empty,
                "I'm not a valid block!!!",
                0);

            unconfirmedData.AddData("I");
            unconfirmedData.AddData("love");
            unconfirmedData.AddData("my");
            unconfirmedData.AddData("dog!");

            firstMiner.MineBlock();
            secondMiner.MineBlock();
            thirdMiner.MineBlock();
            firstMiner.MineBlock();

            secondMiner.BroadCastBlock(fakeBlock);

            var blockchainPrinter = new BlockchainPrinter();
            blockchainPrinter.Print(firstMiner.Blockchain);
            blockchainPrinter.Print(secondMiner.Blockchain);
            blockchainPrinter.Print(thirdMiner.Blockchain);
        }
    }
}
