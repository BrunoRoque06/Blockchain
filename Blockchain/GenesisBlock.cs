using Blockchain.Interfaces;
using System;

namespace Blockchain
{
    public class GenesisBlock : IBlock
    {
        public int Index { get; }
        public DateTime DateTime { get; }
        public string PreviousHash { get; }
        public string Hash { get; }
        public object Data { get; }
        public int Nonce { get; }

        public GenesisBlock()
        {
            Index = 0;
            DateTime = DateTime.Now;
            PreviousHash = string.Empty;
            Hash = string.Empty;
            Data = "Genesis";
            Nonce = 0;
        }
    }
}
