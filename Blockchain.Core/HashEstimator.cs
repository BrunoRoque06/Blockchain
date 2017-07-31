using Blockchain.Interfaces;
using System;

namespace Blockchain
{
    public class HashEstimator : IHashEstimator
    {
        public string Estimate(IBlock block)
        {
            var hash = Tuple.Create(block.Index,
                block.PreviousHash,
                block.DateTime,
                block.Data,
                block.Nonce).GetHashCode().ToString();

            return hash;
        }
    }
}
