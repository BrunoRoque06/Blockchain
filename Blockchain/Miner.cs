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
        private IFifoQueue _unconfirmedDataFifo;
        
        public Miner(IBlockFactory blockFactory, IFifoQueue unconfirmedData)
        {
            _blockFactory = blockFactory;
            _unconfirmedDataFifo = unconfirmedData;
            var genesisBlock = _blockFactory.GenerateGenesisBlock();
            Blockchain = new Blockchain(genesisBlock);
        }

        public Miner(IBlockFactory blockFactory, IFifoQueue unconfirmedData, Miner minerBefore)
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

        public void MineBlock()
        {
            var data = GetUnconfirmedData();
            var block = SolveFunction(data);

            if (AddBlockToBlockchain(block))
            {
                BroadCastBlock(block);
            }
        }

        public void BroadCastBlock(IBlock block)
        {
            if (Before != null)
            {
                Before.ReceiveBlock(block);
            }
            if (Next != null)
            {
                Next.ReceiveBlock(block);
            }
        }

        public void ReceiveBlock(IBlock block)
        {
            if(!Blockchain.ContainsIndex(block.Index))
            {
                if (ValidateBlock(block))
                {
                    Blockchain.AddBlock(block);
                    BroadCastBlock(block);
                } else
                {
                    Console.WriteLine("Someone sent an invalid Block!!!");
                }
            }
        }

        private bool ValidateBlock(IBlock block)
        {
            return block.Hash == _blockFactory.GetBlockHash(block);
        }

        public bool AddBlockToBlockchain(IBlock block)
        {
            bool isAdded = false;

            if (block is Block)
            {
                isAdded = true;
                Blockchain.AddBlock(block);
            }

            return isAdded;
        }

        public IBlock SolveFunction(object data)
        {
            IBlock newBlock = new VoidBlock();

            for (var i = 0; i < 100000; i++)
            {
                var block = _blockFactory.GenerateNextBlock(Blockchain.GetLastBlock(),
                    data, i);

                if (DoesBlockSolveFunction(block))
                {
                    newBlock = block;
                    break;
                }
            }

            return newBlock;
        }
        
        public bool DoesBlockSolveFunction(IBlock block)
        {
            bool result;

            if (block.Hash.Length >= 3 &&
                Int32.TryParse(block.Hash.Substring(0, 3), out int firstThreeDigits))
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
