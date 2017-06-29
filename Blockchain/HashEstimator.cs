using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    public class HashEstimator : IHashEstimator
    {
        public string EstimateHash(Block block)
        {
            var hash = Tuple.Create(block.Index,
                block.PreviousHash,
                block.DateTime,
                block.Data).GetHashCode().ToString();

            return hash;
        }
    }
}
