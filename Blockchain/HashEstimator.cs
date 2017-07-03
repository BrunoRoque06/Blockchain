using System;

namespace Blockchain
{
    public class HashEstimator : IHashEstimator
    {
        public string Estimate(Block block)
        {
            var hash = Tuple.Create(block.Index,
                block.PreviousHash,
                block.DateTime,
                block.Data).GetHashCode().ToString();

            return hash;
        }
    }
}
