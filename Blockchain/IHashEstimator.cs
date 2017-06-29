using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain
{
    public interface IHashEstimator
    {
        string EstimateHash(Block block);
    }
}
