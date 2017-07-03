using System;

namespace Blockchain
{
    public class Block
    {
        public int Index { get; }
        public DateTime DateTime { get; }
        public string PreviousHash { get; }
        public string Hash { get; }
        public string Data { get; }

        public Block(int index,
            DateTime dateTime,
            string previousHash,
            string hash,
            string data)
        {
            Index = index;
            DateTime = dateTime;
            PreviousHash = previousHash;
            Hash = hash;
            Data = data;
        }
    }
}
