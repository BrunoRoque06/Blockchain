using System;

namespace Blockchain.Interfaces
{
    public interface IBlock
    {
        int Index { get; }
        DateTime DateTime { get; }
        string PreviousHash { get; }
        string Hash { get; }
        object Data { get; }
        int Nonce { get; }
    }
}
