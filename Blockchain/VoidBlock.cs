using Blockchain.Interfaces;
using System;

namespace Blockchain
{
    public class VoidBlock : IBlock
    {
        public int Index { get; }
        public DateTime DateTime { get; }
        public string PreviousHash { get; }
        public string Hash { get; }
        public object Data { get; }
        public int Nonce { get; }
    }
}
