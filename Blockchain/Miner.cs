using System;
using Blockchain.Interfaces;

namespace Blockchain
{
    public class Miner
    {
        public Miner Before;
        public Miner Next;
        public Blockchain Blockchain { get; }
        private IBlockFactory _blockFactory;
        private IFifoStack _unconfirmedDataFifo;
        
        public Miner(IBlockFactory blockFactory, IFifoStack unconfirmedData)
        {
            _blockFactory = blockFactory;
            _unconfirmedDataFifo = unconfirmedData;
            var genesisBlock = _blockFactory.GenerateGenesisBlock();
            Blockchain = new Blockchain(genesisBlock);
        }

        public Miner(IBlockFactory blockFactory, IFifoStack unconfirmedData, Miner minerBefore)
        {
            _blockFactory = blockFactory;
            _unconfirmedDataFifo = unconfirmedData;
            var genesisBlock = _blockFactory.GenerateGenesisBlock();
            Blockchain = new Blockchain(genesisBlock);

            FixPointers(minerBefore);
        }

        private void FixPointers(Miner minerBefore)
        {
            Before = minerBefore;
            Next = minerBefore.Next;
            if (minerBefore.Next != null)
            {
                minerBefore.Next.Before = this;
            }
            minerBefore.Next = this;
        }

        public Block Mine(string data)
        {
            var newBlock = _blockFactory.GenerateNextBlock(Blockchain.GetLastBlock(),
                data, 0);

            if (DoesBlockSolveFunction(newBlock))
            {

            }

            return newBlock;
        }

        public Block SolveFunction(object data)
        {
            var newBlock = _blockFactory.GenerateNextBlock(Blockchain.GetLastBlock(),
                    data, 0);

            for (var i = 1; i < 1000; i++)
            {
                newBlock = _blockFactory.GenerateNextBlock(Blockchain.GetLastBlock(),
                    data, i);

                if (DoesBlockSolveFunction(newBlock))
                {
                    break;
                }
            }

            return newBlock;
        }
        
        public bool DoesBlockSolveFunction(Block block)
        {
            bool result;

            if (Int32.TryParse(block.Hash.Substring(0, 3), out int firstThreeDigits))
            {
                result = firstThreeDigits < 100 ? true : false;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public object GetUnconfirmedData()
        {
            return _unconfirmedDataFifo.GetData();
        }
    }
}
