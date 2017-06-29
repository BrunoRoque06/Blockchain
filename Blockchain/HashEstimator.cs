using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    public class HashEstimator
    {
        public string EstimateHash(Block block)
        {
            var hash = Tuple.Create(block.Index,
                block.PreviousHash,
                block.Timestamp,
                block.Data).GetHashCode().ToString();

            return hash;
        }
    }
}
