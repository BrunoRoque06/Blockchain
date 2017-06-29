using System;

namespace Blockchain
{
    public class Block
    {
        public int Index { get; set; }
        public string PreviousHash { get; set; }
        public DateTime DateTime { get; set; }
        public double Data { get; set; }
        public string Hash { get; set; }

        public Block(int index, string previousHash, DateTime dateTime, int data)
        {
            Index = index;
            PreviousHash = previousHash;
            DateTime = dateTime;
            Data = data;
        }
    }
}
