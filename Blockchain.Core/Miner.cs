using System;
using Blockchain.Interfaces;

namespace Blockchain
{
    public class Miner
    {
        private readonly static int NUMBER_HASH_DIGITS = 3;
        private readonly static int REQUIRED_HASH_VALUE = 100;

        private readonly IBlockFactory _blockFactory;
        private readonly IFifoQueue _unconfirmedDataFifo;
        public Miner Before;
        public Miner Next;
        public Blockchain Blockchain { get; }

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
            if (!Blockchain.ContainsIndex(block.Index))
            {
                if (ValidateBlock(block))
                {
                    Blockchain.AddBlock(block);
                    BroadCastBlock(block);
                }
                else
                {
                    Console.WriteLine("Someone sent an invalid Block!!!");
                }
            }
        }

        public bool ValidateBlock(IBlock block)
        {
            var isBlockValid = false;

            if (block.PreviousHash == Blockchain.GetLastBlock().Hash &&
                block.Hash == _blockFactory.GetBlockHash(block))
            {
                isBlockValid = true;
            }

            return isBlockValid;
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
            IBlock newBlock = _blockFactory.GenerateVoidBlock();

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

            if (block.Hash.Length >= NUMBER_HASH_DIGITS &&
                Int32.TryParse(block.Hash.Substring(0, NUMBER_HASH_DIGITS), out int hashDigits))
            {
                result = hashDigits < REQUIRED_HASH_VALUE ? true : false;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public object GetUnconfirmedData()
        {
            return _unconfirmedDataFifo.GetAndRemoveData();
        }
    }
}
