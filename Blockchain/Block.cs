using Blockchain.Interfaces;
using System;

namespace Blockchain
{
    public class Block : IBlock
    {
        public int Index { get; }
        public DateTime DateTime { get; }
        public string PreviousHash { get; }
        public string Hash { get; }
        public object Data { get; }
        public int Nonce { get; }

        public Block(int index,
            DateTime dateTime,
            string previousHash,
            string hash,
            object data,
            int nonce)
        {
            Index = index;
            DateTime = dateTime;
            PreviousHash = previousHash;
            Hash = hash;
            Data = data;
            Nonce = nonce;
        }
    }
}
