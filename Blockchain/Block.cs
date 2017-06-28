using System;

namespace Blockchain
{
    public class Block
    {
        public int Index { get; set; }
        public byte[] PreviousHash { get; set; }
        public DateTime Timestamp { get; set; }
        public double Data { get; set; }
        public byte[] Hash { get; set; }

        public Block(int index, byte[] previousHash, DateTime timestamp, double data, byte[] hash)
        {
            Index = index;
            PreviousHash = previousHash;
            Timestamp = timestamp;
            Data = data;
            Hash = hash;
        }
    }
}
