using System;

namespace Blockchain
{
    public class Block
    {
        int Index;
        byte[] PreviousHash;
        DateTime Timestamp;
        double Data;
        byte[] Hash;

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
