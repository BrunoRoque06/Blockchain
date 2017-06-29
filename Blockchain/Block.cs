using System;

namespace Blockchain
{
    public class Block
    {
        public int Index { get; set; }
        public string PreviousHash { get; set; }
        public DateTime DateTime { get; set; }
        public string Data { get; set; }
        public string Hash { get; set; }

        public Block()
        {
        }

        public Block(int index, string previousHash, DateTime dateTime, string data)
        {
            Index = index;
            PreviousHash = previousHash;
            DateTime = dateTime;
            Data = data;
        }
    }
}
