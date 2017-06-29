using System;

namespace Blockchain
{
    public class Block
    {
        public int Index { get; set; }
        public string PreviousHash { get; set; }
        public DateTime Timestamp { get; set; }
        public double Data { get; set; }
        public string Hash { get; set; }

        public Block(int index, string previousHash, DateTime timestamp, double data)
        {
            Index = index;
            PreviousHash = previousHash;
            Timestamp = timestamp;
            Data = data;
            Hash = "1"; 
        }
    }
}
